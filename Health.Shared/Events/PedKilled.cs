namespace NFive.Health.Shared.Events
{
	public class PedKilled
	{
		public int VictimHandle { get; set; }
		public int KillerHandle { get; set; }
		public EntityType KillerType { get; set; }
		public uint Weapon { get; set; }
		public bool IsMelee { get; set; }
	}
}
