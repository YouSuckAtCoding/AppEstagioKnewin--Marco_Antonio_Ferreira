
using AppEstagioKnewin.Models;
using AppEstagioKnewin.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AppEstagioKnewin.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioHttpService usuarioHttpService;

        public UsuarioController(IUsuarioHttpService _usuarioHttpService)
        {
            usuarioHttpService = _usuarioHttpService;
        }


        // GET: UsuarioController
        public async Task<IActionResult> Index()
        {
            var users = await usuarioHttpService.GetAll();
            return View(users);
        }

        // GET: UsuarioController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View(await usuarioHttpService.GetById(id));
        }

        // GET: UsuarioController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsuarioPresentationModel user)
        {
            try
            {
                UsuarioPresentationModel usuario = new UsuarioPresentationModel();
                usuario.Name = user.Name;
                usuario.EmailAddress = user.EmailAddress;
                await usuarioHttpService.Create(usuario);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var user = await usuarioHttpService.GetById(id);
            return View(user);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UsuarioPresentationModel user)
        {
            UsuarioPresentationModel updated = new UsuarioPresentationModel();
            updated.Id = id;
            updated.Name = user.Name;
            updated.EmailAddress = user.EmailAddress;
            try
            {
                await usuarioHttpService.Edit(user);
                
            }
            catch
            {
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: UsuarioController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return View(await usuarioHttpService.GetById(id));
            }
            catch
            {
                return View("Error");
            }
        }

        // POST: UsuarioController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, UsuarioPresentationModel user)
        {
            try
            {
                await usuarioHttpService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
