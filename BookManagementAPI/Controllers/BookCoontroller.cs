using Microsoft.AspNetCore.Mvc;
using BookManagementAPI.Data;
using BookManagementAPI.Models;

namespace BookManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookContext _context;

        public BooksController(BookContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(_context.Books);
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(Guid id)
        {
            var book = _context.Books.Find(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            book.Id = Guid.NewGuid();
            _context.Books.Add(book);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(Guid id, Book updatedBook)
        {
            var book = _context.Books.Find(id);
            if (book == null) return NotFound();

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.ISBN = updatedBook.ISBN;
            book.PublicationDate = updatedBook.PublicationDate;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(Guid id)
        {
            var book = _context.Books.Find(id);
            if (book == null) return NotFound();

            _context.Books.Remove(book);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
