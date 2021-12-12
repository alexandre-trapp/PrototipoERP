using Microsoft.AspNetCore.Mvc;
using PrototipoERP.Configuration;
using PrototipoERP.Entidades;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrototipoERP.Controllers
{
    [Route("api")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private static byte[] Salt = Argon2EncryptHash.CreateSalt();

        // GET: api/usuarios
        [HttpGet("usuarios")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Usuario))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseError))]
        public async Task<ActionResult<IEnumerable<Usuario>>> ObterUsuarios()
        {
            try
            {
                return Ok(new List<Usuario>
                {
                    new Usuario
                    {
                        Id = 1,
                        Nome = "ronaldo",
                        Senha = "123"
                    },
                    new Usuario
                    {
                        Id = 2,
                        Nome = "trapp",
                        Senha = "456"
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new ResponseError { Message = ex.Message });
            }
        }

        // GET: api/usuarios/{1}
        [HttpGet("usuarios/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Usuario))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseError))]
        public async Task<ActionResult<Usuario>> ObterUsuarioPorId(long id)
        {
            try
            {
                return Ok(new Usuario
                {
                    Id = 1,
                    Nome = "ronaldo",
                    Senha = "123"
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new ResponseError { Message = ex.Message });
            }
        }

        // POST: api/usuarios
        [HttpPost("usuarios")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UsuarioCriadoResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseError))]
        public async Task<ActionResult<Usuario>> CadastrarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                var hash = Argon2EncryptHash.HashPassword(usuario.Senha, Salt);

                Console.WriteLine($"salt: {Convert.ToBase64String(Salt)}");
                Console.WriteLine($"hash password {usuario.Senha}: {Convert.ToBase64String(hash)}");

                return Created("api/usuarios/1",
                    new UsuarioCriadoResponse
                    {
                        Id = 1,
                        Nome = "ronaldo"
                    });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { message = ex.Message });
            }
        }

        // PUT: api/usuarios/1
        [HttpPut("usuarios/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Usuario))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseError))]
        public async Task<ActionResult<Usuario>> AtualizarUsuario(
            long id, [FromBody] Usuario usuario)
        {
            try
            {
                return Ok(
                    new Usuario
                    {
                        Id = 1,
                        Nome = "teste",
                        Senha = "123"
                    });
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
