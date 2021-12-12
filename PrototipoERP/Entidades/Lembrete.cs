using System.Text.Json.Serialization;

namespace PrototipoERP.Entidades
{
    public class Lembrete
    {
        public long Id { get; set; }
        public long UsuarioId { get; set; }

        [JsonIgnore]
        public Usuario Usuario { get; set; }

        public DateTime DataHora { get; set; }
        public string TextoLembrete { get; set; }
    }
}
