﻿using Entities.Concrete.Dtos.Membership;
using Entities.Concrete.TableModels.Membership;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Restoran.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async  Task<IActionResult> Login(LoginDto dto)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new();

                user = await _userManager.FindByEmailAsync(dto.Email);
                if (user == null)
                {
                    ViewBag.Message = "Email və ya şifrə yalnışdır";
                }
                var result= await _signInManager.PasswordSignInAsync(user, dto.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home", new { area = "Dashboard" });
                }
               
            }
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser user = new()
                {
                    UserName = dto.UserName,
                    Email = dto.Email,
                    Name = dto.Name,
                    Surname = dto.Surname,
                    EmailConfirmed = true,
                };
                var result= await _userManager.CreateAsync(user,dto.Password);

                if (!result.Succeeded)
                {
                    ViewBag.Message = "Xəta baş verdi";

                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }

                    return View(dto);
                }
                return RedirectToAction("Login");
            }
            return View();
        }
    }
}
