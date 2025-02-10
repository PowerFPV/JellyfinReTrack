using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Plugins;
using Jellyfin.Plugin.ReTrack;
using MediaBrowser.Model.Serialization;
using MediaBrowser.Model.Services;
using MediaBrowser.Model.Tasks;

namespace Jellyfin.Plugin.ReTrack
{
    public class Plugin : BasePlugin<PluginConfiguration>, IHasWebPages
    {
        public Plugin(IApplicationPaths applicationPaths, IXmlSerializer xmlSerializer)
            : base(applicationPaths, xmlSerializer)
        {
            Instance = this;
        }

        public override string Name => "ReTrack";

        public override Guid Id => Guid.Parse("bf4117e3-9d46-4671-97a0-01d11802eddf");

        public static Plugin? Instance { get; private set; }

        // Register services for background tasks and library post-scan tasks
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ILibraryPostScanTask, AudioTrackPostScanTask>();
            services.AddSingleton<IHostedService, AudioTrackService>();
        }

        public IEnumerable<PluginPageInfo> GetPages()
        {
            return new[]
            {
                new PluginPageInfo
                {
                    Name = Name,
                    EmbeddedResourcePath = string.Format(CultureInfo.InvariantCulture, "{0}.Configuration.configPage.html", GetType().Namespace)
                }
            };
        }
    }
}
