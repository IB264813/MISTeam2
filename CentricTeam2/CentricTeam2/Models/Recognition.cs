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
        [Required]
        [Key]
        [Display(Name = "Person giving the recognition")]
        public Guid EmployeeGivingRecog { get; set; }

        [Display(Name = "Core value recognized")]        
        [Required]
        public CoreValue RecognitionId { get; set; }

        [Required]
        [Display(Name = "Person receiving the recognition")]
        public Guid ID { get; set; }
        public virtual UserDetails UserDetails { get; set; }


        [Display(Name = "Date recognition given")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime recognizationDate
        {
            get { return DateTime.Now; }
        }


        [Display(Name = "Comments")]
        public string RecognitionComments { get; set; }


        public enum CoreValue
        {
            Excellence = 1,
            Integrity = 2,
            Stewardship = 3,
            Innovate = 4,
            Balance = 5
        }
        //public ICollection<EmployeeRecognition> EmployeeRecognitions { get; set; }

    }

}
