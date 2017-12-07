using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentricTeam2.Models
{

    public class UserDetails
    {

        [Required]
        public Guid ID { get; set; }

        [Display(Name = " Email address ")]
        [Required]
        [EmailAddress(ErrorMessage = "Enter email address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = " First Name ")]
        public string firstName { get; set; }

        [Required]
        [Display(Name = " Last Name ")]
        public string lastName { get; set; }
        public string fullName { get { return lastName + ", " + firstName; } }

        [Required]
        [Display(Name = " Phone ")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\(\d{3}\) |\d{3}-)\d{3}-\d{4}$", ErrorMessage = "Phone number must be entered in correct format. (xxx-xxx-xxxx)")]
        public string PhoneNumber { get; set; }



        [Display(Name = " Skills ")]
        public string Position { get; set; }

        [Display(Name = " Centric Anniversary ")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime hireDate { get; set; }

        [Display(Name = " Number of years with Centric ")]
        public int centicAnniversary { get; set; }
        public string photo { get; set; }

        [Display(Name = " Business Unit ")]
        public location businessUnit { get; set; }
       
        


        public enum location
        {
            Boston = 1,
            Charlotte = 2,
            Cincinnati = 3,
            Columbus = 4,
            Cleveland = 5,
            India = 6,
            Indianapolis = 7,
            Miami = 8,
            Seattle = 9,
            StLouis = 10,
            Tampa = 11
        }


        public ICollection<Recognition> Recognition { get; set; }


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
}