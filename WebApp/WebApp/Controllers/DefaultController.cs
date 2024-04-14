using System.Text;
using Infrastructure.Entities;
using Infrastructure.Models;
using Infrastructure.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Newtonsoft.Json;

namespace WebApp.Controllers;

public class DefaultController(HttpClient http) : Controller
{
    private readonly HttpClient _http = http;

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
            return View("Error");
        }

        return View("Error");
    }

    #region Contact
    [Route("/contact")]
    [HttpGet]
    public async Task<IActionResult> Contact()
    {
        try
        {
            var response = await _http.GetAsync("http://localhost:5094/api/Services");

            if (response.IsSuccessStatusCode)
            {
                var servicesJson = await response.Content.ReadAsStringAsync();
                var services = JsonConvert.DeserializeObject<List<ServiceModel>>(servicesJson);

                var model = new ContactUsViewModel
                {
                    Services = services
                };
                TempData["StatusSuccess"] = "Thanks for your message, we'll get back to you as soon as possible!";
                return View(model);
            }
        }
        catch { }
        return View(new ContactUsViewModel());
    }

    [Route("/contact")]
    [HttpPost]
    public async Task<IActionResult> Contact(ContactUsViewModel viewModel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var formModel = new ContactFormModel
                {
                    Email = viewModel.Email,
                    FullName = viewModel.FullName,
                    ServiceId = viewModel.ServiceId,
                    Message = viewModel.Message,
                };

                var content = new StringContent(JsonConvert.SerializeObject(formModel), Encoding.UTF8, "application/json");
                //HTTP
                var createResponse = await _http.PostAsync("http://localhost:5094/api/Contacts", content);

                if (createResponse.IsSuccessStatusCode)
                {
                    TempData["StatusSuccess"] = "Thanks for your message, we'll get back to you as soon as possible!";
                    return RedirectToAction("Contact", viewModel);
                }
                else
                {
                    TempData["StatusError"] = "Something went wrong :/ please try again!";
                    return View();
                }
            }
        }
        catch { }

        TempData["StatusError"] = "Something went wrong :/ please try again!";
        return View(viewModel);
    }
    #endregion
}
