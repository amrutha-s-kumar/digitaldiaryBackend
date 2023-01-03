using digitaldiaryBackend.Context;
using digitaldiaryBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace digitaldiaryBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        public AppDbContext Diary { get; set; }
        public TodoController(AppDbContext contextClass)
        {
            this.Diary = contextClass;

        }
        [HttpPost("insEntry")]
        public async Task<ActionResult> insEntry(Todo cu)
        {

            Diary.tblTodo.Add(cu);
            await Diary.SaveChangesAsync();
            return Ok(cu);
        }
        [HttpGet("viewdata")]
        public async Task<List<Todo>> ViewData()
        {
            return Diary.tblTodo.ToList();
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Todo cu)
        {

            Diary.tblTodo.Remove(cu);
            Diary.SaveChanges();
            return Ok(cu);
        }
        [HttpGet("ViewdataByid/{id}")]
        public IActionResult ViewCourseByid(int id)
        {
            return Ok(Diary.tblTodo.Find(id));
        }
    }
}
