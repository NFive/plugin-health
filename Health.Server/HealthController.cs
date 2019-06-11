using JetBrains.Annotations;
using NFive.Health.Shared;
using NFive.SDK.Core.Diagnostics;
using NFive.SDK.Server.Controllers;
using NFive.SDK.Server.Events;
using NFive.SDK.Server.Rcon;
using NFive.SDK.Server.Rpc;

namespace NFive.Health.Server
{
	[PublicAPI]
	public class HealthController : ConfigurableController<Configuration>
	{
		public HealthController(ILogger logger, IEventManager events, IRpcHandler rpc, IRconManager rcon, Configuration configuration) : base(logger, events, rpc, rcon, configuration)
		{
			// Send configuration when requested
			this.Rpc.Event(HealthEvents.Configuration).On(e => e.Reply(this.Configuration));
		}

		public override void Reload(Configuration configuration)
		{
			// Update local configuration
			base.Reload(configuration);

			// Send out new configuration
			this.Rpc.Event(HealthEvents.Configuration).Trigger(this.Configuration);
		}
	}
}
