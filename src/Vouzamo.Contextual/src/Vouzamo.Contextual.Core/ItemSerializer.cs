using System;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Vouzamo.Contextual.Common.Interfaces;

namespace Vouzamo.Contextual.Core
{
    public class ItemSerializer : IItemSerializer
    {
        private static JsonSerializerSettings JsonSerializerSettings => new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
        private ILogger<ItemSerializer> Logger { get; set; }

        public ItemSerializer(ILogger<ItemSerializer> logger)
        {
            Logger = logger;
        }

        public T Serialize<T>(IItem item)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(item.CustomData, JsonSerializerSettings);
            }
            catch (Exception exception)
            {
                Logger.LogError(1000, exception, $"Could not deserialize {item.Id} into {typeof(T).Name}");

                return default(T);
            }
        }
    }
}
