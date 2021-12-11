using Microsoft.AspNetCore.Mvc;
using PrototipoERP.Entidades;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrototipoERP.Controllers
{
    [Route("api")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        // GET: api/usuarios
        [HttpGet("usuarios")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Usuarios))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<ActionResult<IEnumerable<Usuarios>>> ObterUsuarios()
        {
            try
            {
                return Ok(new List<Usuarios>
                {
                    new Usuarios
                    {
                        Id = 1,
                        Nome = "ronaldo",
                        Senha = "123"
                    },
                    new Usuarios
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

                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ErrorResponse
                    {
                        Status = StatusCodes.Status500InternalServerError,
                        Message = ex.Message
                    });
            }
        }

        // GET: api/usuarios/{1}
        [HttpGet("usuarios/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Usuarios))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<ActionResult<Usuarios>> ObterUsuarioPorId(long id)
        {
            try
            {
                return Ok(new Usuarios
                {
                    Id = 1,
                    Nome = "ronaldo",
                    Senha = "123"
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ErrorResponse
                    {
                        Status = StatusCodes.Status500InternalServerError,
                        Message = ex.Message
                    });
            }
        }

        // POST: api/usuarios
        [HttpPost("usuarios")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Usuarios))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<ActionResult<Usuarios>> CadastrarUsuario([FromBody] Usuarios usuario)
        {
            try
            {
                return Created("api/usuarios/1",
                    new Usuarios
                    {
                        Id = 1,
                        Nome = "ronaldo",
                        Senha = "123"
                    });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ErrorResponse
                    {
                        Status = StatusCodes.Status500InternalServerError,
                        Message = ex.Message
                    });
            }
        }

        // PUT: api/usuarios/1
        [HttpPut("usuarios/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Usuarios))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<ActionResult<Usuarios>> AtualizarUsuario(
            long id, [FromBody] Usuarios usuario)
        {
            try
            {
                return Ok(
                    new Usuarios
                    {
                        Id = 1,
                        Nome = "teste",
                        Senha = "123"
                    });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ErrorResponse
                    {
                        Status = StatusCodes.Status500InternalServerError,
                        Message = ex.Message
                    });
            }
        }
    }
}
