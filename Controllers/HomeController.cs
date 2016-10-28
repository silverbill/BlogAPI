using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

[Route("/")]
public class HomeController : Controller {
    public HomeController(){
    }

    [HttpGet]
    public IActionResult Home(){
        return Redirect("/students");
    }
}