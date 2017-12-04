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
        [Key]
        public int EmployeeRecognitionID { get; set; }

        [Display(Name = "Date Recognition is Given")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime CurentDateTime { get; set; }


        [Display(Name = "Comments")]
        public string RecognitionComments { get; set; }

        [Display(Name = "Employee Giving Recognition")]
        [Required]
        public Guid EmployeeGivingRecog { get; set; }

        [ForeignKey("EmployeeGivingRecog")]
        public virtual UserDetails Giver { get; set; }

        [Required]
        [Display(Name = "Centric Core Value")]
        public int RecognitionId { get; set; }
        public virtual Recognition Recognition { get; set; }

        [Required]

        [Display(Name = "Employee Being Recognized")]
        public Guid ID { get; set; }

        [ForeignKey("ID")]
        public virtual UserDetails UserDetails { get; set; }









    }
}