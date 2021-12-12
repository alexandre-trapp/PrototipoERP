using Microsoft.AspNetCore.Mvc;
using PrototipoERP.Entidades;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrototipoERP.Controllers
{
    [Route("api")]
    [ApiController]
    public class LembretesController : ControllerBase
    {
        // GET: api/lembretes
        [HttpGet("lembretes")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Lembrete))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<ActionResult<IEnumerable<Lembrete>>> ObterLembretes()
        {
            try
            {
                return Ok(new List<Lembrete>
                {
                    new Lembrete
                    {
                        UsuarioId = 1,
                        DataHora = DateTime.Now,
                        TextoLembrete = "lembrete do ronaldo"
                    },
                    new Lembrete
                    {
                        UsuarioId = 2,
                        DataHora = DateTime.Now,
                        TextoLembrete = "lembrete do trapp"
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

        // GET: api/lembretes
        [HttpGet("usuario/{id}/lembretes")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Lembrete))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<ActionResult<IEnumerable<Lembrete>>> ObterLembretesPorUsuario(long id)
        {
            try
            {
                return Ok(new List<Lembrete>
                {
                    new Lembrete
                    {
                        UsuarioId = 1,
                        DataHora = DateTime.Now,
                        TextoLembrete = "lembrete do ronaldo"
                    },
                    new Lembrete
                    {
                        UsuarioId = 1,
                        DataHora = DateTime.Now,
                        TextoLembrete = "lembrete 2 do ronaldo"
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

        // POST: api/lembretes
        [HttpPost("lembretes")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Lembrete))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<ActionResult<Lembrete>> CadastrarLembrete([FromBody] Lembrete lembrete)
        {
            try
            {
                return Created("api/lembretes/1",
                    new Lembrete
                    {
                        UsuarioId = 1,
                        DataHora = DateTime.Now,
                        TextoLembrete = "lembrete do ronaldo"
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

        // PUT: api/lembretes/1
        [HttpPut("lembretes/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Lembrete))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponse))]
        public async Task<ActionResult<Lembrete>> AtualizarLembrete(
            long id, [FromBody] Lembrete lembrete)
        {
            try
            {
                return Ok(
                    new Lembrete
                    {
                        UsuarioId = 1,
                        DataHora = DateTime.Now,
                        TextoLembrete = "lembrete do trapp 2"
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
