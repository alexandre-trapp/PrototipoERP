using System.Text.Json.Serialization;

namespace PrototipoERP.Entidades
{
    public class Lembretes
    {
        public long UsuarioId { get; set; }

        [JsonIgnore]
        public Usuarios Usuario { get; set; }

        public DateTime DataHora { get; set; }
        public string Lembrete { get; set; }
    }
}
