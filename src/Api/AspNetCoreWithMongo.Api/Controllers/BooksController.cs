using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWithMongo.Api.Models;
using AspNetCoreWithMongo.Api.Services;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<List<Book>> Get() =>
            _bookService.Get();

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
    }
}