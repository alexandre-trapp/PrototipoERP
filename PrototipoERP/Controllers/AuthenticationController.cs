using PrototipoERP.Entidades;
using Microsoft.AspNetCore.Mvc;
using PrototipoERP.Configuracoes.Criptografia;

namespace PrototipoERP.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost]
        [Route("auth")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TokenInfo))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseError))]
        public ActionResult<dynamic> Authenticate([FromBody] Usuario usuario)
        {
            try
            {
                // Recupera o usuário
                //var user = UserRepository.Get(usuario.Username, usuario.Password);

                // Verifica se o usuário existe
                if (usuario == null)
                    return NotFound(new { message = "Usuário ou senha inválidos" });

                // Gera o Token
                var tokenInfo = TokenService.GenerateToken(usuario);

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
