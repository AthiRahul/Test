using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoredProcedureAdo.Models;
using StoredProcedureAdo.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoredProcedureAdo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentService student;
        public StudentsController(IStudentService students)
        {
            student = students;
        }
        // GET: api/values
        [HttpGet]
        public IActionResult GetStudents([FromQuery]int age)
        {
           var stud=student.GetStudents(age);
            return Ok(stud);

        }
        [HttpPost]
        public IActionResult newmetod()
        {
            return Ok();
        }
    }
}

