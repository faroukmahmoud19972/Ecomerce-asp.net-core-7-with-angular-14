using Ecom.infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public BugController(ApplicationDBContext context)
        {
            _context = context;
        }
        [HttpGet("Not-Found")]
        public ActionResult GetNotFound()
        {
            var category = _context.Categories.Find(50);
            if (category is null)
                   return NotFound();
            return Ok(category);

        }
        [HttpGet("server-error")]
        public ActionResult GetServerError()
        {
            var category = _context.Categories.Find(50);
            category.Name = "Error";
            return Ok();

        }
        [HttpGet("Bad-Request/{id}")]
        public ActionResult GetBadRequest(int id)
        {
            return Ok();

        }
        [HttpGet("Bad-Request")]
        public ActionResult GetBadRequest()
        {
            return Ok();

        }

    }
}
