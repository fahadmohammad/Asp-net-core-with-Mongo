using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWithMongo.Api.Models;
using AspNetCoreWithMongo.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AspNetCoreWithMongo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly BookService _bookService;
        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult<List<Book>> Get()
        {
            var books = _bookService.Get();

            return books;
        }
           

        [HttpGet("{id:length(24)}",Name = "GetBook")]
        public ActionResult<Book> Get(string id)

        {
            var book = _bookService.Get(id);

            if(book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public ActionResult<Book> Create([FromBody] Book book)
        {
            _bookService.Create(book);

            return CreatedAtRoute("GetBook", new { id = book.Id.ToString() }, book);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id,[FromBody]Book bookToUpdate)
        {
            var book = _bookService.Get(id);

            if(book == null)
            {
                return NotFound();
            }

            _bookService.Update(id, bookToUpdate);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var book = _bookService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _bookService.Remove(book.Id);

            return NoContent();
        }
    }
}