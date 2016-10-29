using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public interface IBlogRepo {
    void add(Post p); // CREATE
    IEnumerable<Post> getAll(); // READ
    Post get(int postID); // READ  get 1
    Post update(int postID, Post p); // UPDATE
    void delete(int postID); // DELETE
}

public class Post {
    public int postID {get; set;}  //whereas postID isn't visible...internal use.
    public int postNumber{get; set;}  //Not req. per homework:  seq. # for ea. nxt added post that's visible
    public string title {get; set;}
    public string content {get; set;}

    public Post(){
        postID = new Random().Next();       //postNumber = new Int32().Next();  func for assign next blog as postNumber
    }
}

public class Blog : IBlogRepo {

    private List<Post> posts = new List<Post>();

    public Blog(){
        posts.Add(new Post { postID = 1, title = "P1" });
        posts.Add(new Post { postID = 2, title = "P2" });
        posts.Add(new Post { postID = 3, title = "P3" });
        posts.Add(new Post { postID = 4, title = "P4" });
        posts.Add(new Post { postID = 5, title = "P5" });
        posts.Add(new Post { postID = 6, title = "P6" });
        posts.Add(new Post { postID = 7, title = "P7" });
        posts.Add(new Post { postID = 8, title = "P8" });
        posts.Add(new Post { postID = 9, title = "P9" });
        posts.Add(new Post { postID = 10, title = "P10" });
    }

    public void add(Post p){
        posts.Add(p);
    }
    public IEnumerable<Post> getAll(){
        return posts;
    }
    public Post get(int postID){
        return posts.First(p => p.postID == postID);
    }
    public Post update(int postID, Post p){
        Post toUpdate = posts.First(x => x.postID == postID);
        if(toUpdate != null){
            posts.Remove(toUpdate);
            posts.Add(p);
            return p;
        }
        return null;
    }
    public void delete(int postID){
        Post p = posts.First(x => x.postID == postID);
        if(p != null){
            posts.Remove(p);
        }
    }
}