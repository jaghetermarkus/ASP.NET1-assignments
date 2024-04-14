using System.Diagnostics;
using System.Text;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApp.Controllers;

public class NewsletterController(HttpClient http) : Controller
{
    private readonly HttpClient _http = http;


    [HttpPost]
    public async Task<ActionResult> Subscribe(SubscriberFormModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                //HTTP
                var createResponse = await _http.PostAsync("http://localhost:5027/api/Subscribers", content);

                //HTTPS
                // var response = await _http.PostAsync("https://localhost:7186/api/Subscribers", content);
                if (createResponse.IsSuccessStatusCode)
                {
                    TempData["StatusSuccess"] = "Welcome to the subscribe list!";
                    return RedirectToAction("Index", "Default", "newsletter");
                }
                else if (createResponse.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    var updateResponse = await _http.PutAsync("http://localhost:5027/api/Subscribers", content);
                    if (updateResponse.IsSuccessStatusCode)
                    {
                        TempData["StatusSuccess"] = "Your subscription is updated";
                        return RedirectToAction("Index", "Default", "newsletter");
                    }
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            TempData["StatusError"] = "Opps.. something went wrong :(";
            return RedirectToAction("Index", "Default", "newsletter");
        }
        TempData["StatusError"] = "Wrong input, try again!";
        return RedirectToAction("Index", "Default", "newsletter");
    }
}
