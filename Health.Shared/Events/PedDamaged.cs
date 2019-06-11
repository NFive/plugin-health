namespace NFive.Health.Shared.Events
{
	public class PedDamaged
	{
		public int VictimHandle { get; set; }
		public int AttackerHandle { get; set; }
		public EntityType AttackerType { get; set; }
		public uint Weapon { get; set; }
		public bool IsMelee { get; set; }
		public int VictimHealth { get; set; }
	}
}
