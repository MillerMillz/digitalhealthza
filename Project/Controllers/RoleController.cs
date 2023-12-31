﻿using Project.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models;

namespace Project.Controllers
{
    
    public class RoleController : Controller
    {
        private  RoleManager<IdentityRole> roleManager;
        private  UserManager<ApplicationUser> userManager;

        public RoleController(RoleManager<IdentityRole> roleManager,UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
      public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model )
        {
            if(ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                }; 
                var result =await roleManager.CreateAsync(identityRole);
                if(result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }
                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
          

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if(role==null)
            {
                ViewBag.ErrorMessage = $"Role with ID = {id} cannot  be found";
                return View("NotFound");
            }
            var result = await roleManager.DeleteAsync(role);
            if(result.Succeeded)
            {
                return RedirectToAction("ListRoles");
            }
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View("ListRoles");

        }
        [HttpGet]
        public IActionResult ListRoles()
        {
            List<IdentityRole> roles = roleManager.Roles.ToList();
            return View(roles);
        }
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if(role == null)
            {
                ViewBag.ErrorMessage = $"Role with id = {id} cannot be found";
                return View("NotFound");
            }
            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name
            };
            foreach(var user in userManager.Users)
            {
               if(await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                role.Name = model.RoleName;
                var result = await roleManager.UpdateAsync(role);
                if(result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
           
           
        }
        [HttpGet]
        public async Task<IActionResult> EditUserInRole(string roleID)
        {
            ViewBag.roleID = roleID;
            var role = await roleManager.FindByIdAsync(roleID);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with id = {roleID} cannot be found";
                return View("NotFound");
            }
            var model = new List<UserRoleViewModel>();
            foreach(var user in userManager.Users)
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };
                if(await userManager.IsInRoleAsync(user,role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else { userRoleViewModel.IsSelected = false; }
                model.Add(userRoleViewModel);
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditUserInRole(List<UserRoleViewModel> model,string roleID)
        {
            var role = await roleManager.FindByIdAsync(roleID);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with id = {roleID} cannot be found";
                return View("NotFound");
            }
            for(int i = 0;i< model.Count;i++)
            {
                var user = await userManager.FindByIdAsync(model[i].UserId);
                IdentityResult result = null;
                if(model[i].IsSelected && !(await userManager.IsInRoleAsync(user,role.Name)))
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                }
                else if(!model[i].IsSelected && (await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name); 
                }
                else
                {
                    continue;
                }
                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                        continue;
                    else
                        return RedirectToAction("EditRole", new { Id = roleID });
                }
            }
            return RedirectToAction("EditRole", new { Id = roleID });

        }
    }
}
