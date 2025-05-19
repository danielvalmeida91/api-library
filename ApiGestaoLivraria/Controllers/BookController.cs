using System.Data.Common;
using ApiGestaoLivraria.Communication.Requests;
using ApiGestaoLivraria.Communication.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGestaoLivraria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        //[ProducesResponseType(typeof(ResponseGetAllBookJson), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var books = await _context.Books.ToListAsync();
            if (books.Count == 0)
            {
                return NoContent();
            }

            return Ok(books.Select(b => new
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Genre = b.GenreString,
            }));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredBookJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> AddBook([FromBody] RequestRegisterBookJson request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Title) || request.Price <= 0)
            {
                return BadRequest("Invalid request");
            }

            var book = new Book()
            {
                Title = request.Title,
                Author = request.Author,
                Genre = request.Genre,
                Price = request.Price,
                Stock = request.Stock
            };

            _context.Books.Add(book);

            await _context.SaveChangesAsync();

            var response = new ResponseRegisteredBookJson
            {
                Id = book.Id,
                Message = "Book registered successfully"
            };

            return Created(string.Empty, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] RequestRegisterBookJson request)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }
            book.Title = request.Title;
            book.Author = request.Author;
            book.Genre = request.Genre;
            book.Price = request.Price;
            book.Stock = request.Stock;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
