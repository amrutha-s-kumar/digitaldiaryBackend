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
    public class EventController : ControllerBase
    {


        public AppDbContext Diary { get; set; }
        public EventController(AppDbContext contextClass)
        {
            this.Diary = contextClass;

        }
        [HttpPost("insEntry")]
        public async Task<ActionResult> insEntry(Event cu)
        {

            Diary.tblEvent.Add(cu);
            await Diary.SaveChangesAsync();
            return Ok(cu);
        }
        [HttpGet("viewdata")]
        public async Task<List<Event>> ViewData()
        {
            return Diary.tblEvent.ToList();
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Event cu)
        {

            Diary.tblEvent.Remove(cu);
            Diary.SaveChanges();
            return Ok(cu);
        }
        [HttpGet("ViewdataByid/{id}")]
        public IActionResult ViewCourseByid(int id)
        {
            return Ok(Diary.tblEvent.Find(id));
        }
        [HttpPost("eventDelete")]
        public IActionResult evDelete(Event cu)
        {

            Diary.tblEvent.Remove(cu);
            Diary.SaveChanges();
            return Ok(cu);
        }
    }
}

