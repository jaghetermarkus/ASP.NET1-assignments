using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;
using Infrastructure.Models.ViewModels;

namespace WebApp.Controllers;

public class SecurityController : Controller
{
    #region Password
    [HttpGet]
    [Route("/security/password")]
    public IActionResult Password()
    {
        return View();
    }

    [HttpPost]
    [Route("/security/password")]
    public IActionResult ChangePassword(PasswordViewModel viewModel)
    {
        if (ModelState.IsValid)
        {

        }

        return View(viewModel);
    }
    #endregion


    #region Delete account
    [HttpGet]
    [Route("/security/deleteaccount")]
    public IActionResult DeleteAccount()
    {
        return View();
    }

    [HttpPost]
    [Route("/security/deleteaccount")]
    public IActionResult DeleteAccount(PasswordViewModel viewModel)
    {
        if (ModelState.IsValid)
        {

        }

        return View(viewModel);
    }
    #endregion
}
