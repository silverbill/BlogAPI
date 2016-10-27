using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;

[Route("/api/students")]
public class StudentAPIController : Controller {

    private IClassroom classroom;

    public StudentAPIController(IClassroom c){
        classroom = c;
    }

    [HttpGet("{id?}")] // handles /students and /students/:id:
    public IActionResult Read(int id){
        if(id == default(int))
            return Ok(classroom.getAll());
        
        return Ok(classroom.get(id));
    }

    [HttpGet("{id}/learnyou")]
    public IActionResult LearnYou(int id){
        classroom.get(id).IKnowCSharp = true;
        return Redirect("/students");
    }

    [HttpPost]
    public IActionResult Create([FromBody]Student s){
        classroom.add(s);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        classroom.delete(id);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromBody]Student s, int id){
        if(classroom.update(id, s) == null){
            return NotFound();
        }
        return Ok();
    }

}
