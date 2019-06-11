using JetBrains.Annotations;
using NFive.Health.Server.Storage;
using NFive.SDK.Server.Migrations;

namespace NFive.Health.Server.Migrations
{
	[UsedImplicitly]
	public sealed class Configuration : MigrationConfiguration<StorageContext> { }
}
