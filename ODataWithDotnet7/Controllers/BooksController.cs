using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ODataWithDotnet7.Models;

namespace ODataWithDotnet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookStoreContext _bookStoreContext;

        public BooksController(BookStoreContext bookStoreContext)
        {
            _bookStoreContext = bookStoreContext;

            if (bookStoreContext.Books.Count() == 0)
            {
                foreach (var book in DataSource.GetBooks())
                {
                    bookStoreContext.Books.Add(book);
                    bookStoreContext.presses.Add(book.Press);
                }
                bookStoreContext.SaveChanges();
            }
        }

        [EnableQuery]
        [HttpGet("getBooks")]
        public IActionResult Get()
        {
            return Ok(_bookStoreContext.Books);
        }

        [EnableQuery]
        [HttpGet("getBook")]
        public IActionResult Get(int key)
        {
            return Ok(_bookStoreContext.Books.FirstOrDefault(c => c.Id == key));
        }

        [EnableQuery]
        [HttpPost("postBook")]
        public IActionResult Post([FromBody] Book book)
        {
            _bookStoreContext.Books.Add(book);
            _bookStoreContext.SaveChanges();

            return StatusCode(201, book);

        }
    }
}
