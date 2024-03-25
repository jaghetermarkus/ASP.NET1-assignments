using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;

namespace WebApp.Controllers;

[Authorize]
public class AccountController : Controller
{
    #region Account Basic
    [HttpGet]
    [Route("/account/basic")]
    public IActionResult BasicInfo()
    {
        return View();
    }

    [HttpPost]
    [Route("/account/basic")]
    public IActionResult BasicInfo(BasicInfoViewModel viewModel)
    {
        if (ModelState.IsValid)
        {

        }

        return View(viewModel);
    }
    #endregion

    #region Address
    [HttpGet]
    [Route("/account/address")]
    public IActionResult Address()
    {
        return View();
    }

    [HttpPost]
    [Route("/account/address")]
    public IActionResult Address(BasicInfoViewModel viewModel)
    {
        if (ModelState.IsValid)
        {

        }

        return View(viewModel);
    }
    #endregion


    #region Details
    [HttpGet]
    [Route("/account/details")]
    public IActionResult Details()
    {
        return View();
    }
    #endregion


    #region Security
    [HttpGet]
    [Route("/account/security")]
    public IActionResult Security()
    {
        return View();
    }
    #endregion

        #region Password
    [HttpGet]
    [Route("/security/password")]
    public IActionResult Password()
    {
        return View();
    }

    [HttpPost]
    [Route("/security/password")]
    public IActionResult Password(PasswordViewModel viewModel)
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
