using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CentricTeam2.Models
{

    public class UserDetails
    {
        
    




    [Required]
        public Guid ID { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Display(Name = "Primary Phone")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Display(Name = "Office")]
        public string Office { get; set; }

        [Display(Name = "Current position")]
        public string Position { get; set; }

        [Display(Name = "Hire Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime hireDate { get; set; }

        public string photo { get; set; }

        [Display(Name = "Business Unit")]
        public string businessUnit { get; set; }


    }
    //public async Task<ActionResult> Register(RegisterViewModel model)
    //{
    //    //****this is probably not saving the phone, office and position info
    //    if (ModelState.IsValid)
    //    {
    //        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
    //        var result = await UserManager.CreateAsync(user, model.Password);
    //        if (result.Succeeded)
    //        {
    //            await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

    //            //comments removed
    //            //Assign Role to user Here   
    //            await this.UserManager.AddToRoleAsync(user.Id, model.UserRoles);
    //            //redirect to your user create view
    //            return RedirectToAction("Create", "userDetails");
    //        }
    //        // these lines will only be executed if the model is invalid
    //        // meaning the system isn’t able to create an account
    //        ViewBag.Name = new SelectList(context.Roles.Where(u => !u.Name.Contains("Admin"))
    //                                  .ToList(), "Name", "Name");
    //        AddErrors(result);
    //    }

    }