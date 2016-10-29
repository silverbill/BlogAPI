using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

[Route("/posts")]
public class PostController : Controller {
    private IBlogRepo blog;
    public PostController(IBlogRepo b){
        blog = b;
    }

    [HttpGet]
    public IActionResult ReadAll(){
        return View(blog);
    }

    [HttpGet("{postID}")]
    public IActionResult ReadOne(int postID){
        var post = blog.get(postID);
        if(post == null)
            return NotFound(); //404
        
        return View(post);
    }

    [HttpGet("{postID}/edit")]
    public IActionResult Edit(int postID){
        var p = blog.get(postID);
        if(p == null)
            return Redirect("/posts");

        return View(p);
    }

    [HttpPost("{postID}/edit")]
    
    public IActionResult Upsert([FromForm] Post post, int postID){
        
        
        var p = blog.get(postID);
        if(p != null) {
            blog.delete(postID);
        }

        // make sure that the postID is the same as 
        post.postID = postID;
        blog.add(post);
        return RedirectToAction("ReadAll");
    }

    [HttpGet("new")]
    public IActionResult Create(){
        return View();
    }

    [HttpPost("new")]
    
    public IActionResult HandleCreate([FromForm] Post p){
        blog.add(p);
        return RedirectToAction("ReadAll");
    }

    [HttpPost("delete/{postID}")]
    // 
    public IActionResult Delete(int postID){
        blog.delete(postID);
        return RedirectToAction("ReadAll");
    }
}