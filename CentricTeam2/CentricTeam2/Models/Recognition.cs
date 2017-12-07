using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentricTeam2.Models
{
    public class Recognition
    {

        [Key]
        public int EmployeeRecognitionID { get; set; }

        [Display(Name = "Core value recognized")]
        [Required]
        public CoreValue RecognitionId { get; set; }

        public enum CoreValue
        {
            Excellence = 1,
            Integrity = 2,
            Stewardship = 3,
            Innovate = 4,
            Balance = 5
        }

        [Display(Name = "Date recognition given")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime recognizationDate
        {
            get { return DateTime.Now; }
        }


        [Required]
        [Key]
        [Display(Name = "Person giving the recognition")]
        public Guid EmployeeGivingRecog { get; set; }

        [ForeignKey("EmployeeGivingID")]
        public virtual UserDetails Giver { get; set; }


        [Required]
        [Display(Name = "Person receiving the recognition")]
        public Guid EmployeeGivingID { get; set; }
        public virtual UserDetails UserDetails { get; set; }




        [Display(Name = "Comments")]
        public string RecognitionComments { get; set; }

        [Display(Name = "Employee Being Recognized")]
        public Guid ID { get; set; }
        [ForeignKey("ID")]
        public virtual UserDetails UserDetail { get; set; }

        //public ICollection<EmployeeRecognition> EmployeeRecognitions { get; set; }

    }

}
