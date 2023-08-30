using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Project.Models.Repositories;
using Project.Models;
using Microsoft.AspNetCore.Authorization;


namespace Project.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private  UserManager<ApplicationUser> userManager;
        private  SignInManager<ApplicationUser> signInManager;
        
        

        public AccountController(UserManager<ApplicationUser> _userManager,SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
           
          
        }

        public UserManager<ApplicationUser> UserManager { get; }

        [HttpGet]
        public IActionResult RegisterPatient()
        {
            Constants con = new Constants();
            RegisterViewModel register = new RegisterViewModel() { Type = con.Patient ,Status=con.Active};

            return View("~/Views/Home/Register.cshtml", register);
        }
        [HttpGet]
        public IActionResult RegisterAdmin()
        {
            Constants con = new Constants();
            RegisterViewModel register = new RegisterViewModel() { Type = con.Admin,Status=con.Active };

            return View("Register-mil",register);
        }
        [HttpGet]
        public IActionResult RegisterPharmacist()
        {
            Constants con = new Constants();
            RegisterViewModel register = new RegisterViewModel() { Type = con.Pharmacist, Status = con.Active };

            return View("~/Views/Home/Register.cshtml", register);
        }
        [HttpGet]
        public IActionResult RegisterDoctor()
        {
            Constants con = new Constants();
            RegisterViewModel register = new RegisterViewModel() { Type = con.Doctor, Status = con.Active };

            return View("~/Views/Home/Register.cshtml", register);
        }
     
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            Constants con = new Constants();
            if (ModelState.IsValid)
            {
                
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                  
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                   
                    if (model.Type == con.Admin)
                    {
                        await userManager.AddToRoleAsync(user, con.Admin);
                        ApplicationUser USER1 = await userManager.FindByEmailAsync(model.Email);
                   //     Admin admin = new Admin() {  = USER1.Id, ContactNo = model.PhoneNumber };

                        return RedirectToAction("Apply", "Client");
                    }
                    else if (model.Type == con.Doctor)
                    {
                        await userManager.AddToRoleAsync(user, con.Doctor);
                       

                        return RedirectToAction("Index", "Drlanding");
                    }
                    else if (model.Type == con.Patient)
                    {
                        await userManager.AddToRoleAsync(user,con.Patient);
                        ApplicationUser USER1 = await userManager.FindByEmailAsync(model.Email);
                        Patient patient = new Patient() { UserId = USER1.Id, ContactNo = model.PhoneNumber };

                        return RedirectToAction("Addd", "RegionalCoordinator", patient);
                    }
                    else if (model.Type == con.Pharmacist)
                    {
                        await userManager.AddToRoleAsync(user, con.Pharmacist);
                        ApplicationUser USER1 = await userManager.FindByEmailAsync(model.Email);
                        Pharmacist pharmacist = new Pharmacist() { UserId = USER1.Id, ContactNo = model.PhoneNumber };

                        return RedirectToAction("Index", "Pharmacistlanding", pharmacist);
                    }
                 
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();

        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View("~/Views/Home/Login.cshtml");
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel model)
        {
            if (ModelState.IsValid)
            {

                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {

                    Constants con = new Constants();
                    ApplicationUser user = await userManager.FindByEmailAsync(model.Email);
                  
                        var checkRole = await userManager.IsInRoleAsync(user, con.Patient);
                        if (checkRole)
                        {

                            return RedirectToAction("PatientLanding");

                        }
                        checkRole = await userManager.IsInRoleAsync(user,con.Pharmacist);
                        if (checkRole)
                        {

                            return RedirectToAction("Index","Pharmacistlanding");
                        }
                        checkRole = await userManager.IsInRoleAsync(user,con.Doctor);
                        if (checkRole)
                        {
                           
                            return RedirectToAction("Index", "Drlanding");
                        }
                        checkRole = await userManager.IsInRoleAsync(user, con.Admin);
                        if (checkRole)
                        {
                            return RedirectToAction("Adminlanding");
                        }
                        checkRole = await userManager.IsInRoleAsync(user, "Administrator");
                        if (checkRole)
                        {
                            return RedirectToAction("ListRoles", "Role");
                        }
                    }
                else
                    {
                        return View("Denied");
                    }


     
               
                ModelState.AddModelError("", "Invalid Login Attempt");
             
            }
            return View("~/Views/Home/Login.cshtml");

        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("LogIn", "Account");
        }

        public ViewResult ForgotPassword()
        {
            return View("ForgotPassword");
        }
    }
}
