using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;

[Route("/api/posts")]
public class PostAPIController : Controller {

    private IBlogRepo blog;

    public PostAPIController(IBlogRepo b){
        blog = b;
    }

    [HttpGet("{postID?}")] // handles /posts and /posts/:postID:
    public IActionResult Read(int postID){
        if(postID == default(int))
            return Ok(blog.getAll());
        
        return Ok(blog.get(postID));
    }

    [HttpPost]
    public IActionResult Create([FromBody]Post p){
        blog.add(p);
        return Ok();
    }

    [HttpDelete("{postID}")]
    public IActionResult Delete(int postID){
        blog.delete(postID);
        return Ok();
    }

    [HttpPut("{postID}")]
    public IActionResult Update([FromBody]Post p, int postID){
        if(blog.update(postID, p) == null){
            return NotFound();
        }
        return Ok();
    }

}
