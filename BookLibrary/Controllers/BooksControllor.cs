using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksControllor : ControllerBase
    {
        IDatabase db = new Database();

        
        public string SearchParam { get; set; }
        
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(JsonConvert.SerializeObject(db.GetBooks(SearchParam)));
        }

        [HttpGet]
        public JsonResult GetByID(int id)
        {
            return new JsonResult(JsonConvert.SerializeObject(db.GetBook(id)));
        }

        [HttpPost]
        public JsonResult AddBook(Book book)
        {
            return new JsonResult(JsonConvert.SerializeObject(db.InsertBook(book)));
        }

        [HttpPatch]
        public JsonResult UpdateBook(Book book)
        {
            return new JsonResult(JsonConvert.SerializeObject(db.UpdateBook(book)));
        }

        [HttpDelete]
        public OkResult DeleteBook(int id)
        {
            return new OkResult();
        }
    }
}
