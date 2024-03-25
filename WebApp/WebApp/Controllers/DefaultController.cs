using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;

namespace WebApp.Controllers;

public class DefaultController : Controller
{
    [Route("/")]
    public IActionResult Index()
    {
        return View();
    }

    [Route("/error")]
    public IActionResult Error()
    {
        return View();
    }

    public IActionResult Error(int? statusCode)
    {
        if (statusCode.HasValue && statusCode.Value == 404)
        {
            // Visa en särskild vy för 404-fel (sidan hittades inte)
            return View("Error");
        }

        // Visa standard error-sidan för andra typer av fel
        return View("Error");
    }

    #region Contact
    [Route("/contact")]
    [HttpGet]
    public IActionResult Contact()
    {
        return View();
    }

    [Route("/contact")]
    [HttpPost]
    public IActionResult Contact(ContactUsViewModel viewModel)
    {
        if (ModelState.IsValid)
        {

        }

        return View(viewModel);
    }
    #endregion
}
