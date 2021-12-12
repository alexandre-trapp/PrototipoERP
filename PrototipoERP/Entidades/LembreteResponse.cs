namespace PrototipoERP.Entidades
{
    public class LembreteResponse
    {
        public long Id { get; set; }
        public DateTime DataHora { get; set; }
        public string Texto { get; set; }
        public UsuarioCriadoResponse Usuario { get; set; }
    }
}
