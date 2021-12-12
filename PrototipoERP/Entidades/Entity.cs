using Newtonsoft.Json;

namespace PrototipoERP.Entidades
{
    public class Entity
    {
        [JsonProperty(Required = Required.Default)]
        public long Id { get; set; }
    }
}
