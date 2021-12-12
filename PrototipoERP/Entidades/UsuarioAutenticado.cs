namespace PrototipoERP.Entidades
{
    public class UsuarioAutenticado
    {
        public long UsuarioId { get; set; }
        public string UsuarioNome { get; set; }
        public string Token { get; set; }
    }
}
