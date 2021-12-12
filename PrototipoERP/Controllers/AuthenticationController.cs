using Microsoft.AspNetCore.Mvc;
using PrototipoERP.Configuration;
using PrototipoERP.Entidades;

namespace PrototipoERP.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost]
        [Route("auth")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Lembrete))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(object))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(object))]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] Usuario usuario)
        {
            try
            {
                // Recupera o usuário
                //var user = UserRepository.Get(usuario.Username, usuario.Password);

                // Verifica se o usuário existe
                if (usuario == null)
                    return NotFound(new { message = "Usuário ou senha inválidos" });

                // Gera o Token
                var token = TokenService.GenerateToken(usuario);

                // Oculta a senha
                usuario.Senha = string.Empty;

                // Retorna os dados
                return new
                {
                    user = usuario,
                    token = token
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { message = ex.Message });
            }
        }
    }
}
