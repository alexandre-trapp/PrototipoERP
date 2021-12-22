using PrototipoERP.Dtos;
using PrototipoERP.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PrototipoERP.Infraestrutura.Criptografia;
using PrototipoERP.Infraestrutura.Database.Daos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrototipoERP.Controllers
{
    [Route("api")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public IUsuarioDao<Usuario> _usuarioDao { get; }

        public UsuariosController(IUsuarioDao<Usuario> usuarioDao) =>
            _usuarioDao = usuarioDao;

        // GET: api/usuarios
        [HttpGet("usuarios")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Usuario))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseError))]
        public async Task<ActionResult<IEnumerable<Usuario>>> ObterUsuarios()
        {
            try
            {
                var usuarios = await _usuarioDao.GetAll();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new ResponseError { Message = ex.Message });
            }
        }

        // GET: api/usuarios
        [HttpGet("usuarios/id")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsuarioIdDto))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseError))]
        public async Task<ActionResult<UsuarioIdDto>> ObterUsuarioId([FromQuery] UsuarioDto usuario)
        {
            try
            {
                var usuarioId = await _usuarioDao.ObterUsuarioIdPorNomeSenha(usuario.Nome, usuario.Senha);
                return Ok(new UsuarioIdDto
                {
                    Id = usuarioId
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
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Usuario))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseError))]
        public async Task<ActionResult<Usuario>> ObterUsuarioPorId(long id)
        {
            try
            {
                var usuario = await _usuarioDao.GetById(id);
                return Ok(usuario);
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

        // POST: api/usuarios
        [HttpPost("usuarios")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UsuarioCriadoResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseError))]
        public async Task<ActionResult<Usuario>> CadastrarUsuario([FromBody] UsuarioDto usuario)
        {
            try
            {
                var hash = Argon2EncryptHash.HashPassword(usuario.Senha);
                var hashSenhaBase64 = Convert.ToBase64String(hash);

                Console.WriteLine($"hash password {usuario.Senha}: {hashSenhaBase64}");

                var novoUsuario = new Usuario
                {
                    Nome = usuario.Nome,
                    Senha = hashSenhaBase64
                };

                await _usuarioDao.Create(novoUsuario);

                return Created($"api/usuarios/{novoUsuario.Id}",
                    new UsuarioCriadoResponse
                    {
                        Id = novoUsuario.Id,
                        Nome = usuario.Nome
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
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Usuario))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseError))]
        public async Task<ActionResult<Usuario>> AtualizarUsuario(long id, [FromBody] UsuarioDto usuario)
        {
            try
            {
                var usuarioExistente = await _usuarioDao.GetById(id) as Usuario;

                var hash = Argon2EncryptHash.HashPassword(usuario.Senha);
                var hashSenhaBase64 = Convert.ToBase64String(hash);

                usuarioExistente.Senha = hashSenhaBase64;
                usuarioExistente.Nome = usuario.Nome;

                await _usuarioDao.Update(usuarioExistente);
                return Ok(usuarioExistente);
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
