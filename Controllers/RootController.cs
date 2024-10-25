using Microsoft.AspNetCore.Mvc;

namespace SimpleVote.Controllers;

public class RootController: Controller
{
    public IActionResult Index()
    {
        return View();
    }
}