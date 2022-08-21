using Data.Library.Data;
using Data.Library.Data.Posts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Library;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PostApiController : ControllerBase
    {
        private readonly IPostData postData;

        public PostApiController(IPostData _postData)
        {
            postData = _postData;
        }

        // GET: PostApiController
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> Get()
        {
            var posts = await postData.GetPosts();
            return Ok(posts);
        }


        // GET: PostApiController/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var post = await postData.GetPost(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }


        // GET: PostApiController/Create
        [HttpPost]
        public async Task<ActionResult<Post>> Post([FromBody] Post post)
        {
            if (ModelState.IsValid)
            {
                await postData.InsertPost(post);
                return Ok(post);
            }
            return BadRequest(post);
        }



        // GET: PostApiController/Edit/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Post>> Put(int id, [FromBody] Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    
                    await postData.UpdatePost(post);
                    return Ok(post);
                }
                catch
                {
                    return StatusCode(409);
                }

            }
            return BadRequest(post);
        }



        // GET: PostApiController/Delete/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await postData.DeletePost(id);
            return Ok();
        }
       
    }
}
