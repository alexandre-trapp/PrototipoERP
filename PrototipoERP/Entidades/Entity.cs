using Newtonsoft.Json;

namespace PrototipoERP.Entidades
{
    public class Entity
    {
        [System.Text.Json.Serialization.JsonIgnore]
        [JsonProperty(Required = Required.Default)]
        public long Id { get; set; }
    }
}
