using ApiGestaoLivraria.Communication.Requests;
using ApiGestaoLivraria.Communication.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestaoLivraria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok("List of books");
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredBookJson), StatusCodes.Status201Created)]
        public IActionResult AddBook([FromBody] RequestRegisterBookJson request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request");
            }
            var response = new ResponseRegisteredBookJson
            {
                Id = 1,
                Message = "Book registered successfully"
            };

            return Created(string.Empty, response);
        }
    }

}
