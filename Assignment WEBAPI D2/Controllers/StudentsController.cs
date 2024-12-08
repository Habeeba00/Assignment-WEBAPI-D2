using Assignment_WEBAPI_D2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_WEBAPI_D2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        ISchoolContext db = new ISchoolContext();

        [HttpGet]
        public ActionResult GetAll()
        {
            List<Student> sts = db.Students.ToList();
            if (sts.Count > 0)
                return Ok(sts);
            else
                return NotFound();
        }
        [HttpGet("{id:int}")]
        public ActionResult GetById(int id) 
        {
            Student s = db.Students.Where(n=>n.St_Id==id).FirstOrDefault();
            if(s== null)
                return NotFound();
            else 
                return Ok(s);
        }
         
        [HttpGet("{name}")]
        public ActionResult GetByName(string name) 
        {
            Student s = db.Students.Where(n=>n.St_Fname== name).FirstOrDefault();
            if(s== null) 
                return NotFound();
            else 
                return Ok(s);
        }


        [HttpPost]
        public ActionResult Post(Student student)
        {
            if (student == null) BadRequest();
            db.Students.Add(student);
            db.SaveChanges();
            return CreatedAtAction("GetById",new { id=student.St_Id},student);
        }


        [HttpPut]
        public ActionResult Put(Student student, int  id ) 
        { 
            if(student==null )return BadRequest();
            if(id !=student.St_Id) return BadRequest();
            db.Entry(student).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return NoContent();

        }
        [HttpDelete("{id}")]
        public ActionResult delete(int id) 
        {
            Student s = db.Students.Where(n=>n.St_Id ==id).FirstOrDefault();
            if(s==null) return NotFound();
            db.Students.Remove(s);
            db.SaveChanges();
            return Ok(s);
        }


    }
}
