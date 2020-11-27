using gasmaTools.Abstraction.Events;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace gasmaTools.Infra.CrossCutting.Logger
{
    public class InConsoleEventStore : IEventStore
    {
        private readonly ILogger logger;

        public InConsoleEventStore(ILogger<InConsoleEventStore> logger)
        {
            this.logger = logger;
        }

        public void Save<T>(T @event) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(@event);
            var storeEvent = new StoredEvent(@event, serializedData, "System");
            logger.LogTrace(JsonConvert.SerializeObject(storeEvent));
        }
    }
}
