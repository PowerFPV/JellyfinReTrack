using MediaBrowser.Model.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Jellyfin.Plugin.ReTrack
{
    public class AudioTrackService : IHostedService
    {
        private readonly ITaskManager _taskManager;

        public AudioTrackService(ITaskManager taskManager)
        {
            _taskManager = taskManager;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Start the background task to periodically check audio tracks
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            // Stop any active background tasks
            return Task.CompletedTask;
        }
    }
}
