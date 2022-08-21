using Data.Library.Data.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Library;

namespace WebApi.Controllers
{
    
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsuarioApiController : ControllerBase
    {
        private readonly IUsuarioData usuarioData;

        public UsuarioApiController(IUsuarioData _usuarioData)
        {
            usuarioData = _usuarioData;
        }

        // GET: UsuarioApiController
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> Get()
        {
            var users = await usuarioData.GetUsuarios();
            return Ok(users);
        }
       
        // GET: UsuarioApiController/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var user = await usuarioData.GetUsuario(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        
        // GET: UsuarioApiController/Create
        [HttpPost]
        public async Task<ActionResult<Usuario>> Post([FromBody] Usuario user)
        {
            if (ModelState.IsValid)
            {
                await usuarioData.InsertUsuario(user);
                return Ok(user);
            }
            return BadRequest(user);
        }

        // GET: UsuarioApiController/Edit/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> Put(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await usuarioData.UpdateUsuario(usuario);
                    return Ok(usuario);
                }
                catch
                {
                    return StatusCode(409);
                }

            }
            return BadRequest(usuario);
        }

        // GET: UsuarioApiController/Delete/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
                await usuarioData.DeleteUsuario(id);
            return Ok();
        }




    }
}
