using Newtonsoft.Json;

namespace PrototipoERP.Entidades
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }
        public string Senha { get; set; }

        [JsonIgnore]
        public List<Lembrete> Lembretes { get; set; }
    }
}
