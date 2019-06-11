using CitizenFX.Core;
using CitizenFX.Core.Native;
using JetBrains.Annotations;
using NFive.Health.Shared;
using NFive.Health.Shared.Events;
using NFive.SDK.Client.Commands;
using NFive.SDK.Client.Events;
using NFive.SDK.Client.Interface;
using NFive.SDK.Client.Rpc;
using NFive.SDK.Client.Services;
using NFive.SDK.Core.Diagnostics;
using NFive.SDK.Core.Models.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeaponHash = CitizenFX.Core.WeaponHash;

namespace NFive.Health.Client
{
	[PublicAPI]
	public class HealthService : Service
	{
		private Configuration config;
		private List<string> damages = new List<string>();
		private string lastDamage = string.Empty;

		public HealthService(ILogger logger, ITickManager ticks, IEventManager events, IRpcHandler rpc, ICommandManager commands, OverlayManager overlay, User user) : base(logger, ticks, events, rpc, commands, overlay, user) { }

		public override async Task Started()
		{
			// Request server configuration
			this.config = await this.Rpc.Event(HealthEvents.Configuration).Request<Configuration>();

			// Update local configuration on server configuration change
			this.Rpc.Event(HealthEvents.Configuration).On<Configuration>((e, c) => this.config = c);

			this.Events.On<string, List<object>>("gameEventTriggered", OnGameEventTriggered);

			// Attach a tick handler
			this.Ticks.Attach(OnTick);
		}

		private void OnGameEventTriggered(string @event, List<object> args)
		{
			if (@event != "CEventNetworkEntityDamage") return;

			var victim = Entity.FromHandle(int.Parse(args[0].ToString()));
			if (!(victim is Ped)) return;

			var attacker = Entity.FromHandle(int.Parse(args[1].ToString()));
			if (attacker == null) return;

			var victimKilled = int.Parse(args[3].ToString()) == 1;
			var weaponHash = (uint)int.Parse(args[4].ToString());
			var isMeleeDamage = int.Parse(args[9].ToString()) != 0;

			EntityType attackerType;

			switch (attacker)
			{
				case Vehicle _:
					attackerType = EntityType.Vehicle;
					break;
				case Ped p:
					attackerType = p.IsPlayer ? EntityType.Player : EntityType.Ped;
					break;
				default:
					attackerType = EntityType.World;
					break;
			}

			if (victimKilled)
			{
				this.Events.Raise(HealthEvents.PedKilled, new PedKilled
				{
					VictimHandle = victim.Handle,
					KillerHandle = attacker.Handle,
					KillerType = attackerType,
					Weapon = weaponHash,
					IsMelee = isMeleeDamage
				});
			}
			else
			{
				this.Events.Raise(HealthEvents.PedDamaged, new PedDamaged
				{
					VictimHandle = victim.Handle,
					AttackerHandle = attacker.Handle,
					AttackerType = attackerType,
					Weapon = weaponHash,
					IsMelee = isMeleeDamage,
					VictimHealth = victim.Health
				});
			}
		}

		private async Task OnTick()
		{
			var ped = Game.PlayerPed;

			//ped.MaxHealth = 1000;
			//ped.Health = ped.MaxHealth;

			ped.Weapons.Give(WeaponHash.APPistol, int.MaxValue, true, true);

			var bone = GetDamagedBone(ped);
			var bodyPart = GetDamagedBodyPart(bone);

			if (bone != Bone.SKEL_ROOT)
			{
				this.Logger.Debug($"Damage to: {bone} {bodyPart}");

				var hash = CheckPedWasDamagedBy(Enum.GetValues(typeof(DamageSource)).Cast<uint>(), ped);

				var damageString = $"{bone} {bodyPart}";
				if (hash.HasValue) damageString += $" {(DamageSource)hash.Value}";

				if (this.lastDamage != damageString)
				{
					this.Logger.Debug(damageString);

					this.lastDamage = damageString;
					this.damages.Add(damageString);
				}
			}

			//ped.Bones.ClearLastDamaged();
			//API.ClearEntityLastDamageEntity(ped.Handle);
			//ped.ClearLastWeaponDamage();

			if (ped.IsDead)
			{
				this.Logger.Debug("Dead");

				var killer = ped.GetKiller();

				if (killer.Model.IsPed) this.Logger.Debug($"Killed by ped: {killer.Handle} {Enum.GetName(typeof(PedHash), killer.Model.Hash)}");
				else if (killer.Model.IsVehicle) this.Logger.Debug($"Killed by veh: {killer.Handle} {Enum.GetName(typeof(VehicleHash), killer.Model.Hash)}");
				else this.Logger.Debug($"Killed by unknown: {killer.Handle} {killer.Model.Hash}");

				ped.Resurrect();
			}

			await Delay(TimeSpan.FromSeconds(1));
		}

		private uint? CheckPedWasDamagedBy(IEnumerable<uint> hashes, Ped target)
		{
			foreach (var hash in hashes)
			{
				if (!API.HasPedBeenDamagedByWeapon(target.Handle, hash, 0)) continue;

				return hash;
			}

			return null;
		}

		public BodyPart GetDamagedBodyPart(Bone bone)
		{
			switch (bone)
			{
				case Bone.SKEL_Head:
					return BodyPart.Head;
				case Bone.SKEL_Neck_1:
					return BodyPart.Neck;
				case Bone.SKEL_Spine2:
				case Bone.SKEL_Spine3:
					return BodyPart.UpperBody;
				case Bone.SKEL_Pelvis:
				case Bone.SKEL_Spine_Root:
				case Bone.SKEL_Spine0:
				case Bone.SKEL_Spine1:
					//case Bone.SKEL_ROOT:
					return BodyPart.LowerBody;
				case Bone.SKEL_L_Thigh:
				case Bone.SKEL_R_Thigh:
				case Bone.SKEL_L_Toe0:
				case Bone.SKEL_R_Toe0:
				case Bone.SKEL_R_Foot:
				case Bone.SKEL_L_Foot:
				case Bone.SKEL_L_Calf:
				case Bone.SKEL_R_Calf:
					return BodyPart.Leg;
				case Bone.SKEL_L_Clavicle:
				case Bone.SKEL_R_Clavicle:
				case Bone.SKEL_L_Forearm:
				case Bone.SKEL_R_Forearm:
				case Bone.SKEL_L_Hand:
				case Bone.SKEL_R_Hand:
					return BodyPart.Arm;
				default:
					return BodyPart.None;
			}
		}

		public Bone GetDamagedBone(Ped target)
		{
			var bone = new OutputArgument();

			if (Function.Call<bool>(Hash.GET_PED_LAST_DAMAGE_BONE, target.Handle, bone)) return (Bone)bone.GetResult<int>();

			return Bone.SKEL_ROOT;
		}
	}
}
