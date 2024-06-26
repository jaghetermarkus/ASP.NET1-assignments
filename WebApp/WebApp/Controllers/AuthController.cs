﻿using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers;

public class AuthController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;

    #region SignIn
    [HttpGet]
    [Route("/signin")]
    public IActionResult SignIn()
    {
        ViewData["SuccessMessage"] = TempData["SuccessMessage"];
        ViewData["ErrorMessage"] = TempData["ErrorMessage"];

        return View();
    }

    [HttpPost]
    [Route("/signin")]
    public async Task<IActionResult> SignIn(SignInViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(viewModel.Email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, viewModel.Password, viewModel.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Details", "Account");
                }
            }
        }

        ViewData["ErrorMessage"] = "Incorrect email or password";

        return View(viewModel);
    }
    #endregion

    #region SignUp
    [Route("/signup")]
    [HttpGet]
    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    [Route("/signup")]
    public async Task<IActionResult> SignUp(SignUpViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            if (!await _userManager.Users.AnyAsync(x => x.Email == viewModel.Email))
            {
                var userEntity = UserFactory.Create(viewModel);
                var result = await _userManager.CreateAsync(userEntity, viewModel.Password);

                if (result.Succeeded)
                {
                    TempData["SuccessMessage"] = "Your new account was successfully created.";
                    return RedirectToAction("SignIn", "Auth");
                }
                else
                {
                    ViewData["StatusError"] = "Something went wrong, please try again.";
                }
            }
            else
            {
                ViewData["StatusError"] = "User with this email already exists.";
            }
        }

        return View(viewModel);
    }
    #endregion

    #region SignOut
    [Route("/signout")]
    public new async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("SignIn", "Auth");
    }
    #endregion



}
