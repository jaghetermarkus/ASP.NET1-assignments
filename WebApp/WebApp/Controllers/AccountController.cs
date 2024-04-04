using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;
using DataStore.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using WebApp.Services;
using WebApp.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApp.Controllers;

[Authorize]
public class AccountController(UserManager<UserEntity> userManager, AccountService accountService) : Controller
{

    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly AccountService _accountService = accountService;


    #region Account Basic
    [HttpGet]
    [Route("/account/basic")]
    public IActionResult BasicInfo()
    {
        return View();
    }

    [HttpPost]
    [Route("/account/basic")]
    public async Task<IActionResult> BasicInfo(AccountDetailsViewModel viewModel)
    {

        try
        {
            if (viewModel.BasicInfo != null)
            {
                if (!string.IsNullOrEmpty(viewModel.BasicInfo.FirstName) && !string.IsNullOrEmpty(viewModel.BasicInfo.LastName))
                {
                    var updateResult = await _accountService.UpdateBasicInfoAsync(User, viewModel.BasicInfo);
                }
            }
        }
        catch { }

        return RedirectToAction("Details", "Account");
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
    public async Task<IActionResult> Address(AccountDetailsViewModel viewModel)
    {
        try
        {
            if (viewModel.AddressInfo != null)
            {
                if (!string.IsNullOrEmpty(viewModel.AddressInfo.AddressLine_1) && !string.IsNullOrEmpty(viewModel.AddressInfo.PostalCode) && !string.IsNullOrEmpty(viewModel.AddressInfo.City))
                {
                    var updateResult = await _accountService.UpdateAddressAsync(User, viewModel.AddressInfo);
                }
            }
        }
        catch { }

        return RedirectToAction("Details", "Account");
    }
    #endregion


    #region Details
    [HttpGet]
    [Route("/account/details")]
    public async Task<IActionResult> Details()
    {
        var user = await _accountService.GetUserAsync(User);

        var viewModel = new AccountDetailsViewModel
        {
            BasicInfo = new BasicInfoViewModel
            {
                FirstName = user.FirstName!,
                LastName = user.LastName!,
                Email = user.Email!,
                PhoneNumber = user.PhoneNumber,
                Biography = user.Biography
            },
            AddressInfo = new AddressModel
            {
                AddressLine_1 = user.AddressLine_1!,
                AddressLine_2 = user.AddressLine_2!,
                PostalCode = user.PostalCode!,
                City = user.City!
            }
        };

        return View(viewModel);
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


    [HttpPost]
    public async Task<IActionResult> ProfileImageUpload(IFormFile file)
    {
        var result = await _accountService.UploadUserProfileImageAsync(User, file);

        return RedirectToAction("Details", "Account");
    }
}