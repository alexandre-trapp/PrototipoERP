namespace PrototipoERP.Entidades
{
    public class LembreteCriadoResponse
    {
        public long Id { get; set; }
        public DateTime DataHora { get; set; }
        public string Texto { get; set; }
        public UsuarioCriadoResponse Usuario { get; set; }
    }
}
