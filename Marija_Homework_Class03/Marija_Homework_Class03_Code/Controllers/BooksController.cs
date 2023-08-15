using Marija_Homework_Class03_Code.Data;
using Marija_Homework_Class03_Code.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using static System.Net.Mime.MediaTypeNames;
using static System.Reflection.Metadata.BlobBuilder;

namespace Marija_Homework_Class03_Code.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Book> GetAllBooks()
        {
            try
            {
                var bookDb = StaticDb.Books;
                var book = bookDb.Select(b => new Book
                {
                    Author = b.Author,
                    Title = b.Title
                }).ToList();
                return Ok(book);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured, contact the admin!");
            }
        }
        [HttpGet("queryString")]
        public ActionResult<Book> FindByQueryString(int? index)
        {
            try
            {
                if (index == null)
                {
                    return BadRequest("Index is a required paramter.");
                }
                if (index < 0)
                {
                    return BadRequest("Index can not be a negative value.");
                }
                if (index >= StaticDb.Books.Count)
                {
                    return NotFound($"There is no resource with an index of {index}");
                }

                return Ok(StaticDb.Books[index.Value]);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "A server error occured, please contact the support team.");
            }
        }
        [HttpGet("book")]
        public ActionResult<List<Book>> FilterBooksByAuthorOrTitle(string? author, string? title)
        {
            try
            {
                if (string.IsNullOrEmpty(author) || string.IsNullOrEmpty(title))
                {
                    return BadRequest("Filter parameters are required");
                }
                List<Book> books = StaticDb.Books.Where(a => a.Author.ToLower() == author.ToLower() && a.Title.ToLower() == title.ToLower()).ToList();

                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "A server error occured, please contact the support team.");
            }
        }
        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            try
            {
                if (string.IsNullOrEmpty(book.Author))
                {
                    return BadRequest("Insert the author of the book.");
                }
                if (string.IsNullOrEmpty(book.Title))
                {
                    return BadRequest("Insert the title off the book.");
                }

                StaticDb.Books.Add(book);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "A server error occured, please contact the support team.");
            }
        }
        [HttpPost("getTitlesFromBooks")]
        public ActionResult<List<string>> GetTitlesFromBooks([FromBody] List<Book> books)
        {
            try
            {
                if (books == null || !books.Any())
                {
                    return BadRequest("A list of books is required.");
                }

                var bookTitles = books.Select(b => b.Title).ToList();
                return Ok(bookTitles);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "A server error occured, please contact the support team.");
            }

        }
    }
}
