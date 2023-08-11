using AUG2023_WEBAPI_IBM_AfternoonREACT.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AUG2023_WEBAPI_IBM_AfternoonREACT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoAppController : ControllerBase
    {
        Models.ToDoDbContext _db;
        public ToDoAppController( Models.ToDoDbContext db  )
        {
            _db = db;
        }


        // GET: api/<ToDoAppController>
        [HttpGet]
        public IEnumerable<ToDoItem> Get()
        {
            return _db.ToDoItems.ToList();
        }

     
    }
}
