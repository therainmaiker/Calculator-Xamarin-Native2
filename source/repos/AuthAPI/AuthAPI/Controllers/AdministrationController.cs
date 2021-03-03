using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthAPI.Data;
using AuthAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace AuthAPI.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
       private readonly UserManager<IdentityUser> _userManager;
       private  readonly ApplicationDbContext _context; 


        public AdministrationController(RoleManager<IdentityRole> roleManager , UserManager<IdentityUser> userManager , ApplicationDbContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }
        [HttpGet]
        public IActionResult CreateRole()
        {


            return View();

        }
        
        
        // receive create view model
        [HttpPost]
        
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateRole(CreateRole model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {

                    Name = model.RoleName

                };
                IdentityResult result = await _roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {


                    return RedirectToAction("listofroles", "Administration");
                }
                    
            }

            return View(model);

        }


        public IActionResult ListOfRoles()
        {
            var roles = _roleManager.Roles;
            
            return View(roles);


        }


        // Role ID is passed from the URL to the action
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            // Find the role by Role ID
            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("ListOfRoles");
            }

            var model = new EditRole
            {
                Id = role.Id,
                RoleName = role.Name
            };

            // Retrieve all the Users
            foreach (var user in _userManager.Users)
            {
                // If the user is in this role, add the username to
                // Users property of EditRoleViewModel. This model
                // object is then passed to the view for display
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }

            return View(model);
        }

        // This action responds to HttpPost and receives EditRoleViewModel
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRole model)
        {
            var role = await _roleManager.FindByIdAsync(model.Id);

           
                role.Id = model.Id;
                role.Name = model.RoleName;

                // Update the Role using UpdateAsync
                var result = await _roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListOfRoles");
                }

               
                return View(model);
            
        }

        // assign role to user get users list and role list
        
        [HttpGet]
        public IActionResult AssignRoleToUser()
        {
            var model = new AssignRoleToUser();

            var allroles = (from roles in _context.Roles.ToList()
                            select new SelectListItem
                            {
                                Value = roles.Id,
                                Text = roles.Name
                            }).ToList();


            allroles.Insert(0, (new SelectListItem()
            {
                Text = "Select",
                Value = "",
                Selected = true
            }));

            model.ListRole = allroles;
            return View(model);
        }


        ///  getting lists

        public ActionResult GetAllUsers(string username)
        {
            try
            {
                var allUsers = (from user in _context.Users.ToList()
                                where user.UserName.Contains(username)
                                select new SelectListItem
                                {
                                    Value = user.Id,
                                    Text = user.UserName
                                }).ToList();

                return Json(allUsers);

            }
            catch (Exception)
            {
                throw;
            }
        }


        //[HttpGet]
        //public async Task<IActionResult> EditRole(string id , EditRole modelRole)
        //{


        //    var role = await _roleManager.FindByIdAsync(id);

        //    modelRole = new EditRole
        //    {

        //        RoleName = role.Name,
        //        Id = role.Id

        //    };

        //    foreach (var user in _userManager.Users)
        //    {
        //        if (await _userManager.IsInRoleAsync(user, role.Name))
        //        {
        //            modelRole.Users.Add(user.UserName);
        //        }
        //    }

        //    return View(modelRole);
        //}



        //[HttpPost]
        //public async Task<IActionResult> EditRole(EditRole modelRole)
        //{


        //    var role = await roleManager.FindByIdAsync(modelRole.Id);

        //    role.Name = modelRole.RoleName;
        //    var result = await roleManager.UpdateAsync(role);
        //    var resut3 = await userManager.


        //    return View(modelRole);
        //}




    }
}

