using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace NFive.Health.Shared
{
	[PublicAPI]
	public static class Damage
	{
		public static List<uint> SmallCaliberWeaponHashes = new List<uint>(new[]
		{
			(uint) WeaponHash.Pistol,
			(uint) WeaponHash.CombatPistol,
			(uint) WeaponHash.APPistol,
			(uint) WeaponHash.CombatPDW,
			(uint) WeaponHash.MachinePistol,
			(uint) WeaponHash.MicroSMG,
			(uint) WeaponHash.MiniSMG,
			(uint) WeaponHash.PistolMk2,
			(uint) WeaponHash.SNSPistol,
			//(uint) WeaponHash.SNSPistolMk2,
			(uint) WeaponHash.VintagePistol
		});

		public static List<uint> MediumCaliberWeaponHashes = new List<uint>(new[]
		{
			(uint) WeaponHash.AdvancedRifle,
			(uint) WeaponHash.AssaultSMG,
			(uint) WeaponHash.BullpupRifle,
			//(uint) WeaponHash.BullpupRifleMk2,
			(uint) WeaponHash.CarbineRifle,
			(uint) WeaponHash.CarbineRifleMk2,
			(uint) WeaponHash.CompactRifle,
			//(uint) WeaponHash.DoubleActionRevolver,
			(uint) WeaponHash.Gusenberg,
			(uint) WeaponHash.HeavyPistol,
			(uint) WeaponHash.MarksmanPistol,
			(uint) WeaponHash.Pistol50,
			(uint) WeaponHash.Revolver,
			//(uint) WeaponHash.RevolverMk2,
			(uint) WeaponHash.SMG,
			(uint) WeaponHash.SMGMk2,
			(uint) WeaponHash.SpecialCarbine
			//(uint) WeaponHash.SpecialCarbineMk2,
		});

		public static List<uint> HighCaliberWeaponHashes = new List<uint>(new[]
		{
			(uint) WeaponHash.AssaultRifle,
			(uint) WeaponHash.AssaultRifleMk2,
			(uint) WeaponHash.CombatMG,
			(uint) WeaponHash.CombatMGMk2,
			(uint) WeaponHash.HeavySniper,
			(uint) WeaponHash.HeavySniperMk2,
			(uint) WeaponHash.MarksmanRifle,
			//(uint) WeaponHash.MarksmanRifleMk2,
			(uint) WeaponHash.MG,
			(uint) WeaponHash.Minigun,
			(uint) WeaponHash.Musket,
			(uint) WeaponHash.Railgun
		});

		public static List<uint> ShotgunsWeaponHashes = new List<uint>(new[]
		{
			(uint) WeaponHash.AssaultShotgun,
			(uint) WeaponHash.BullpupShotgun,
			(uint) WeaponHash.DoubleBarrelShotgun,
			(uint) WeaponHash.HeavyShotgun,
			(uint) WeaponHash.PumpShotgun,
			//(uint) WeaponHash.PumpShotgunMk2,
			(uint) WeaponHash.SawnOffShotgun,
			(uint) WeaponHash.SweeperShotgun
		});

		public static List<uint> CuttingWeaponHashes = new List<uint>(new uint[]
		{
            //Animal    Cougar     BarbedWire
            4194021054, 148160082, 1223143800,
			(uint) WeaponHash.BattleAxe,
			(uint) WeaponHash.Bottle,
			(uint) WeaponHash.Dagger,
			(uint) WeaponHash.Hatchet,
			(uint) WeaponHash.Knife,
			(uint) WeaponHash.Machete,
			(uint) WeaponHash.SwitchBlade
		});

		public static List<uint> LightImpactWeaponHashes = new List<uint>(new uint[]
		{
            //GarbageBug Briefcase  Briefcase2
            3794977420, 2294779575, 28811031,
			(uint) WeaponHash.Ball,
			(uint) WeaponHash.Flashlight,
			(uint) WeaponHash.KnuckleDuster,
			(uint) WeaponHash.Nightstick,
			(uint) WeaponHash.Snowball,
			(uint) WeaponHash.Unarmed,
			(uint) WeaponHash.Parachute,
			(uint) WeaponHash.NightVision
		});

		public static List<uint> HeavyImpactWeaponHashes = new List<uint>(new[]
		{
			(uint) WeaponHash.Bat,
			(uint) WeaponHash.Crowbar,
			(uint) WeaponHash.FireExtinguisher,
			(uint) WeaponHash.Firework,
			(uint) WeaponHash.GolfClub,
			(uint) WeaponHash.Hammer,
			(uint) WeaponHash.PetrolCan,
			(uint) WeaponHash.PoolCue,
			(uint) WeaponHash.Wrench
		});

		public static List<uint> ExplosiveWeaponHashes = new List<uint>(new uint[]
		{
            //Explosion
            539292904,
			(uint) WeaponHash.Grenade,
			(uint) WeaponHash.CompactGrenadeLauncher,
			(uint) WeaponHash.GrenadeLauncher,
			(uint) WeaponHash.HomingLauncher,
			(uint) WeaponHash.PipeBomb,
			(uint) WeaponHash.ProximityMine,
			(uint) WeaponHash.RPG,
			(uint) WeaponHash.StickyBomb
		});

		public static List<uint> FireWeaponHashes = new List<uint>(new[]
		{
            //ElectricFence Fire
            2461879995, 3750660587,
			(uint) WeaponHash.StunGun,
			(uint) WeaponHash.Molotov,
			(uint) WeaponHash.Flare,
			(uint) WeaponHash.FlareGun
		});

		public static List<uint> SuffocatingWeaponHashes = new List<uint>(new uint[]
		{
            //Drowning  DrowningVeh Exhaust
            4284007675, 1936677264, 910830060,
			(uint) WeaponHash.BZGas,
			(uint) WeaponHash.SmokeGrenade,
			(uint) WeaponHash.GrenadeLauncherSmoke
		});
	}

	[PublicAPI]
	public enum DamageSource : uint
	{
		Animal = 4194021054,
		BarbedWire = 1223143800,
		Cougar = 148160082,
		Drowning = 4284007675,
		DrowningVeh = 1936677264,
		ElectricFence = 2461879995,
		Exhaust = 910830060,
		Explosion = 539292904,
		Fall = 3452007600,
		Fire = 3750660587,
		HelicopterCrash = 341774354,
		Rammed = 133987706,
		RanOver = 2741846334,
		WaterCannon = 3425972830
	}

	[PublicAPI]
	public enum BleedingStates : ushort
	{
		None,
		Light,
		Medium,
		Heavy,
		Deadly
	}

	[PublicAPI]
	public enum WoundStates : ushort
	{
		None,
		Light,
		Medium,
		Heavy,
		Deadly
	}

	[PublicAPI]
	public enum WeaponClasses : ushort
	{
		SmallCaliber,
		MediumCaliber,
		HighCaliber,
		Shotgun,
		Cutting,
		LightImpact,
		HeavyImpact,
		Explosive,
		Fire,
		Suffocating,
		Other,
		None
	}

	public enum BodyPart : ushort
	{
		Head,
		Neck,
		UpperBody,
		LowerBody,
		Arm,
		Leg,
		None
	}

	[PublicAPI]
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public enum WeaponHash : uint
	{
		Knife = 2578778090u,
		Nightstick = 1737195953u,
		Hammer = 1317494643u,
		Bat = 2508868239u,
		GolfClub = 1141786504u,
		Crowbar = 2227010557u,
		Bottle = 4192643659u,
		SwitchBlade = 3756226112u,
		Pistol = 453432689u,
		CombatPistol = 1593441988u,
		APPistol = 584646201u,
		Pistol50 = 2578377531u,
		FlareGun = 1198879012u,
		MarksmanPistol = 3696079510u,
		Revolver = 3249783761u,
		MicroSMG = 324215364u,
		SMG = 736523883u,
		AssaultSMG = 4024951519u,
		CombatPDW = 171789620u,
		AssaultRifle = 3220176749u,
		CarbineRifle = 2210333304u,
		AdvancedRifle = 2937143193u,
		CompactRifle = 1649403952u,
		MG = 2634544996u,
		CombatMG = 2144741730u,
		PumpShotgun = 487013001u,
		SawnOffShotgun = 2017895192u,
		AssaultShotgun = 3800352039u,
		BullpupShotgun = 2640438543u,
		DoubleBarrelShotgun = 4019527611u,
		StunGun = 911657153u,
		SniperRifle = 100416529u,
		HeavySniper = 205991906u,
		GrenadeLauncher = 2726580491u,
		GrenadeLauncherSmoke = 1305664598u,
		RPG = 2982836145u,
		Minigun = 1119849093u,
		Grenade = 2481070269u,
		StickyBomb = 741814745u,
		SmokeGrenade = 4256991824u,
		BZGas = 2694266206u,
		Molotov = 615608432u,
		FireExtinguisher = 101631238u,
		PetrolCan = 883325847u,
		SNSPistol = 3218215474u,
		SpecialCarbine = 3231910285u,
		HeavyPistol = 3523564046u,
		BullpupRifle = 2132975508u,
		HomingLauncher = 1672152130u,
		ProximityMine = 2874559379u,
		Snowball = 126349499u,
		VintagePistol = 137902532u,
		Dagger = 2460120199u,
		Firework = 2138347493u,
		Musket = 2828843422u,
		MarksmanRifle = 3342088282u,
		HeavyShotgun = 984333226u,
		Gusenberg = 1627465347u,
		Hatchet = 4191993645u,
		Railgun = 1834241177u,
		Unarmed = 2725352035u,
		KnuckleDuster = 3638508604u,
		Machete = 3713923289u,
		MachinePistol = 3675956304u,
		Flashlight = 2343591895u,
		Ball = 600439132u,
		Flare = 1233104067u,
		NightVision = 2803906140u,
		Parachute = 4222310262u,
		SweeperShotgun = 317205821u,
		BattleAxe = 3441901897u,
		CompactGrenadeLauncher = 125959754u,
		MiniSMG = 3173288789u,
		PipeBomb = 3125143736u,
		PoolCue = 2484171525u,
		Wrench = 419712736u,
		PistolMk2 = 0xBFE256D4,
		AssaultRifleMk2 = 0x394F415C,
		CarbineRifleMk2 = 0xFAD1F1C9,
		CombatMGMk2 = 0xDBBD7280,
		HeavySniperMk2 = 0xA914799,
		SMGMk2 = 0x78A97CD0
	}

	[PublicAPI]
	public enum VehicleWeaponHash
	{
		Invalid = -1,
		Tank = 1945616459,
		SpaceRocket = -123497569,
		PlaneRocket = -821520672,
		PlayerLaser = -268631733,
		PlayerBullet = 1259576109,
		PlayerBuzzard = 1186503822,
		PlayerHunter = -1625648674,
		PlayerLazer = -494786007,
		EnemyLaser = 1566990507,
		SearchLight = -844344963,
		Radar = -764006018
	}

	[PublicAPI]
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public enum AmmoType : uint
	{
		Melee = 0,
		FireExtinguisher = 0x5106B43C,
		Flare = 0x6BCCF76F,
		FlareGun = 0x45F0E965,
		PetrolCan = 0xCA6318A1,
		Shotgun = 0x90083D3B,
		Pistol = 0x743D4F54,
		Ball = 0xFF956666,
		Snowball = 0x8218416D,
		Sniper = 0x4C98087B,
		AssaultRifle = 0xD05319F,
		SMG = 0x6C7D23B8,
		Molotov = 0x5633F9D5,
		StunGun = 0xB02EADE0,
		MG = 0x6AA1343F,
		GrenadeLauncher = 0x3BCCA5EE,
		RPG = 0x67DD81F2,
		Minigun = 0x9FC5C882,
		Firework = 0xAF23EE0F,
		Railgun = 0x794446FD,
		HomingLauncher = 0x99150E2D,
		Grenade = 0x3BD313B1,
		StickyBomb = 0x5424B617,
		ProximityMine = 0xAF2208A7,
		PipeBomb = 0x155663F8,
		SmokeGrenade = 0xE60E08A6,
		BZGas = 0x9B747EA4
	}
}
