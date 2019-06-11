using NFive.SDK.Core.Models.Player;
using NFive.SDK.Server.Storage;
using System.Data.Entity;

namespace NFive.Health.Server.Storage
{
	public class StorageContext : EFContext<StorageContext>
	{
		public DbSet<User> Users { get; set; }
	}
}
