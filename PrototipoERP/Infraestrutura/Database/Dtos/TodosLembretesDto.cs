using Newtonsoft.Json;
using PrototipoERP.Entidades;

namespace PrototipoERP.Infraestrutura.Database.Dtos
{
    public class TodosLembretesDto : Entity
    {
        [JsonProperty("usuario_id")]
        public long UsuarioId { get; set; }

        [JsonProperty("usuario")]
        public string Usuario { get; set; }

        [JsonProperty("data_hora")]
        public DateTime DataHora { get; set; }

        [JsonProperty("texto")]
        public string Texto { get; set; }
    }
}
