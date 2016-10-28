using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

[Route("/students")]
public class StudentController : Controller {
    private IClassroom classroom;
    public StudentController(IClassroom c){
        classroom = c;
    }

    [HttpGet]
    public IActionResult ReadAll(){
        return View(classroom);
    }

    [HttpGet("{id}")]
    public IActionResult ReadOne(int id){
        var student = classroom.get(id);
        if(student == null)
            return NotFound(); //404
        
        return View(student);
    }

    [HttpGet("{id}/edit")]
    public IActionResult Edit(int id){
        var s = classroom.get(id);
        if(s == null)
            return Redirect("/students");

        return View(s);
    }

    [HttpPost("{id}/edit")]
    public IActionResult Upsert([FromForm] Student student, int id){
        Request.Form.Log();
        id.Log();
        student.Log();

        // var s = classroom.get(id);
        // if(s != null) {
        //     classroom.delete(id);
        // }

        // student.StudentId = id;
        // classroom.add(student);
        return Ok("student currently is default");
    }
}