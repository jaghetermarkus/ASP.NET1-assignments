using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;
using DataStore.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using WebApp.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Diagnostics;
using Infrastructure.Models.ViewModels;

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
            if (TryValidateModel(viewModel.BasicInfo!))
            {
                if (!string.IsNullOrEmpty(viewModel.BasicInfo!.FirstName) && !string.IsNullOrEmpty(viewModel.BasicInfo.LastName))
                {
                    var updateResult = await _accountService.UpdateBasicInfoAsync(User, viewModel.BasicInfo);
                    TempData["StatusSuccess"] = "Your information is updated!";
                    return RedirectToAction("Details", "Account");
                }
            }
            return View("Details", viewModel);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        TempData["StatusError"] = "Opps.. something went wrong :(";
        return View("Details", viewModel);
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
                if (TryValidateModel(viewModel.AddressInfo))
                {
                    if (!string.IsNullOrEmpty(viewModel.AddressInfo.AddressLine_1) && !string.IsNullOrEmpty(viewModel.AddressInfo.PostalCode) && !string.IsNullOrEmpty(viewModel.AddressInfo.City))
                    {
                        var updateResult = await _accountService.UpdateAddressAsync(User, viewModel.AddressInfo);
                        TempData["AddressStatusSuccess"] = "Your address is updated!";
                        return RedirectToAction("Details", "Account");
                    }
                }
            }
            return View("Details", viewModel);
        }
        catch { }

        TempData["AddressStatusError"] = "Opps.. something went wrong :(";
        return View("Details", viewModel);
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
                // Email = user.Email!,
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
    [Route("/account/password")]
    public IActionResult Password()
    {


        return View();
    }

    [HttpPost]
    [Route("/account/password")]
    public async Task<IActionResult> Password(AccountSecurityViewModel viewModel)
    {
        try
        {
            if (viewModel.Password != null)
            {
                if (TryValidateModel(viewModel.Password))
                {
                    var updateResult = await _accountService.UpdatePasswordAsync(User, viewModel.Password!);
                    if (updateResult)
                    {
                        TempData["StatusSuccess"] = "Password is successfully updated.";
                        // return RedirectToAction("Details", "Account");
                        return View("Security", viewModel);
                    }
                }
            }
            return View("Security", viewModel);
        }
        catch { }

        TempData["StatusError"] = "Something went wrong, password isn´t updated.";
        // return RedirectToAction("Security", "Account");
        return View("Security", viewModel);
    }
    #endregion


    #region Delete account
    [HttpGet]
    [Route("/account/deleteaccount")]
    public IActionResult DeleteAccount()
    {
        return View();
    }

    [HttpPost]
    [Route("/account/deleteaccount")]
    public async Task<IActionResult> DeleteAccount(DeleteAccountViewModel viewModel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var deleteResult = await _accountService.DeleteUserAsync(User);

                if (deleteResult)
                {
                    return RedirectToAction("SignOut", "Auth");
                }
                else
                {
                    return RedirectToAction("Security", "Account");
                }
            }
            TempData["StatusError"] = "You must confirm to delete your account";
            return RedirectToAction("Security", "Account");
        }
        catch { }

        TempData["StatusError"] = "Something went wrong, please try again.";
        return RedirectToAction("Security", "Account");

    }
    #endregion


    [HttpPost]
    public async Task<IActionResult> ProfileImageUpload(IFormFile file)
    {
        var result = await _accountService.UploadUserProfileImageAsync(User, file);

        return RedirectToAction("Details", "Account");
    }
}