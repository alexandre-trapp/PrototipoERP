using PrototipoERP.Dtos;
using PrototipoERP.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PrototipoERP.Infraestrutura.Database.Daos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrototipoERP.Controllers
{
    [Route("api")]
    [ApiController]
    public class LembretesController : ControllerBase
    {
        private readonly IUsuarioDao<Usuario> _usuarioDao;
        public readonly ILembreteDao<Lembrete> _lembreteDao;

        public LembretesController(
            IUsuarioDao<Usuario> usuarioDao,
            ILembreteDao<Lembrete> lembreteDao)
        {
            _usuarioDao = usuarioDao;
            _lembreteDao = lembreteDao;
        }

        // GET: api/lembretes
        [HttpGet("lembretes")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Lembrete))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseError))]
        public async Task<ActionResult<IEnumerable<Lembrete>>> ObterLembretes()
        {
            try
            {
                var lembretes = await _lembreteDao.GetAll();
                return Ok(lembretes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new ResponseError { Message = ex.Message });
            }
        }

        // GET: api/usuario/1/lembretes
        [HttpGet("usuario/{id}/lembretes")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Lembrete))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseError))]
        public async Task<ActionResult<IEnumerable<Lembrete>>> ObterLembretesPorUsuario(long id)
        {
            try
            {
                if (!await _usuarioDao.Exists(id))
                    return StatusCode(
                        StatusCodes.Status400BadRequest,
                        new ResponseError 
                        {
                            Message = $"Usuário com id {id} não encontrado na base de dados para pesquisa dos lembretes." 
                        });

                var lembretes = await _lembreteDao.ListarLembretesPorUsuario(id);
                return Ok(lembretes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new ResponseError { Message = ex.Message });
            }
        }

        // GET: api/lembretes/1
        [HttpGet("lembretes/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Lembrete))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseError))]
        public async Task<ActionResult<Lembrete>> ObterLembretePorId(long id)
        {
            try
            {
                var lembrete = await _lembreteDao.GetById(id);
                return Ok(lembrete);
            }
            catch (OperationCanceledException opx)
            {
                Console.WriteLine(opx);

                return StatusCode(
                    StatusCodes.Status404NotFound,
                    new ResponseError { Message = opx.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new ResponseError { Message = ex.Message });
            }
        }

        // POST: api/lembretes
        [HttpPost("lembretes")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(LembreteResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseError))]
        public async Task<ActionResult<Lembrete>> CadastrarLembrete([FromBody] LembreteDto lembrete)
        {
            try
            {
                if (!await _usuarioDao.Exists(lembrete.UsuarioId))
                    return StatusCode(
                        StatusCodes.Status400BadRequest,
                        new ResponseError
                        {
                            Message = $"Usuário com id {lembrete.UsuarioId} não encontrado na base de dados para cadastro do lembrete."
                        });

                var novoLembrete = new Lembrete
                {
                    UsuarioId = lembrete.UsuarioId,
                    Texto = lembrete.Texto,
                    DataHora = DateTime.Now,
                };

                await _lembreteDao.Create(novoLembrete);

                return Created("api/lembretes/1",
                    new LembreteResponse
                    {
                        Id = novoLembrete.Id,
                        Texto = novoLembrete.Texto,
                        DataHora = novoLembrete.DataHora,
                        Usuario = new UsuarioCriadoResponse
                        {
                            Id = novoLembrete.UsuarioId,
                            Nome = novoLembrete.Usuario.Nome
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

        // PUT: api/lembretes/1
        [HttpPut("lembretes/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseError))]
        public async Task<ActionResult> AtualizarLembrete([FromBody] Lembrete lembrete)
        {
            try
            {
                if (!await _usuarioDao.Exists(lembrete.UsuarioId))
                    return StatusCode(
                        StatusCodes.Status400BadRequest,
                        new ResponseError
                        {
                            Message = $"Usuário com id {lembrete.UsuarioId} não encontrado na base de dados para atualização do lembrete."
                        });

                await _lembreteDao.Update(lembrete);

                return NoContent();
            }
            catch (OperationCanceledException opx)
            {
                Console.WriteLine(opx);

                return StatusCode(
                     StatusCodes.Status400BadRequest,
                     new ResponseError { Message = opx.Message });
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
