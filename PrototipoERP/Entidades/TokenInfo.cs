namespace PrototipoERP.Entidades
{
    public class TokenInfo
    {
        public long UsuarioId { get; set; }
        public string UsuarioNome { get; set; }
        public string Token { get; set; }
        public DateTime? DataExpiracao { get; set; } 
    }
}
