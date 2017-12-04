using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentricTeam2.Models
{
    public class EmployeeRecognition
    {
        public Guid EmployeeRecognitionID { get; set; }

        [Display(Name = "Employee Getting Recognition")]
        [Required(ErrorMessage = "Please select an employee")]

        public Guid employeeId { get; set; }
        [ForeignKey("Employeeid")]

        public virtual UserDetails Employee { get; set; }
        [Display(Name = "Employee Giving Recognition")]

        public Guid recognizerId { get; set; }
        [ForeignKey("Recognizerid")]

        public virtual UserDetails Recognizer { get; set; }
        [Display(Name = "Recogniton Awarded")]

        public Guid recognitionId { get; set; }
        [ForeignKey("recognitionId")]

        public virtual Recognition Recognition { get; set; }
        [Display(Name = "Date Awarded")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode =true)]

        public Nullable<System.DateTime> awardDate { get; set; }
        [Display(Name = "Why is this person getting this award")]
        [Required(ErrorMessage = "Please enter why this person is getting this award")]

        public string description { get; set; }









    }
}