
using AppEstagioKnewin.Models;
using AppEstagioKnewin.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Text.Json;
using X.PagedList;

namespace AppEstagioKnewin.Controllers
{
    public class PostController : Controller
    {

        
        private readonly IPostHttpService postHttpService;
        private readonly IUsuarioHttpService usuarioHttpService;

        public PostController(IPostHttpService _postHttpService, IUsuarioHttpService _usuarioHttpService)
        {
            postHttpService = _postHttpService;
            usuarioHttpService = _usuarioHttpService;
        }
        // GET: PostController
        public async Task<IActionResult> Index(int pagina = 1)
        {
            var allposts = await postHttpService.GetAll();
            var page = allposts.ToPagedList(pagina, 5);

            //var allposts = await postHttpService.GetAll();
            //var page = allposts.Skip(2).Take(5); //This is awesome
            
            
            return View(page);
        }
        public async Task<IActionResult> GetUser(string Author)
        {
            var users = await usuarioHttpService.GetAll();
            foreach(var user in users)
            {
                if(Author == user.Name)
                {
                    var selecteruser = await usuarioHttpService.GetById(user.Id);
                    return View("UserDetails", selecteruser);
                }
            }

            return RedirectToAction(nameof(Index));
        }
        // GET: PostController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View(await postHttpService.GetById(id));
        }

        // GET: PostController/Create
        public async Task<IActionResult> Create()
        {
            await Authors();
            return View();
        }

        private async Task Authors()
        {
            var authors = await usuarioHttpService.GetAll();
            List<string> authorsNames = new List<string>();
            foreach (var author in authors)
            {
                authorsNames.Add(author.Name);
            }
            ViewBag.Authors = new SelectList(authorsNames);
        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostPresentationModel post)
        {
            try
            {
                PostPresentationModel _post = new PostPresentationModel();
                _post.Title = post.Title;
                _post.Author = post.Author;
                _post.PublishDate = DateTime.Now;
                _post.Content = post.Content;
                await postHttpService.Create(_post);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var post = await postHttpService.GetById(id);
            return View(post);
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PostPresentationModel post)
        {
            PostPresentationModel updated = new PostPresentationModel();
            updated.Id = id;
            if (post.Title.Contains("(Edited)"))
            {
                updated.Title = post.Title;
            }
            else
            {
                updated.Title = post.Title + "(Edited)";
            }
            updated.Author = post.Author;
            updated.PublishDate = DateTime.Now;
            updated.Content = post.Content;
            
            
                try
                {
                    await postHttpService.Edit(updated);    
                    
                }
                catch
                {
                    return View();
                }
            
            return RedirectToAction(nameof(Index));
        }

        // GET: PostController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try{
                return View(await postHttpService.GetById(id));
            }
            catch
            {
                return View("Error");
            }

           


        }

        // POST: PostController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                await postHttpService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
