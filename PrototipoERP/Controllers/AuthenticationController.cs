using PrototipoERP.Entidades;
using Microsoft.AspNetCore.Mvc;
using PrototipoERP.Infraestrutura.Criptografia;
using PrototipoERP.Infraestrutura.Database.Daos;

namespace PrototipoERP.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUsuarioDao<Usuario> _usuarioDao;

        public AuthenticationController(IUsuarioDao<Usuario> usuarioDao) =>
            _usuarioDao = usuarioDao;

        [HttpPost]
        [Route("auth")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TokenInfo))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseError))]
        public async Task<ActionResult<TokenInfo>> Authenticate([FromBody] UsuarioAutenticacao usuario)
        {
            try
            {
                // Recupera o usuário
                var senhaCriptografada = Convert.ToBase64String(Argon2EncryptHash.HashPassword(usuario.Senha));
                var usuarioExistente = await _usuarioDao.ObterUsuarioPorNomeSenha(usuario.Nome, senhaCriptografada);

                // Verifica se o usuário existe
                if (usuarioExistente == null)
                    return NotFound(new ResponseError { Message = "Usuário ou senha inválidos" });

                // Gera o Token
                var tokenInfo = TokenService.GenerateToken(usuarioExistente);

                // Retorna os dados
                return tokenInfo;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new ResponseError { Message = ex.Message });
            }
        }
    }
}
