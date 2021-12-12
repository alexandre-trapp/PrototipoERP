using Newtonsoft.Json;

namespace PrototipoERP.Entidades
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }
        public string Senha { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        [JsonProperty(Required = Required.Default)]
        public List<Lembrete> Lembretes { get; set; }
    }
}
