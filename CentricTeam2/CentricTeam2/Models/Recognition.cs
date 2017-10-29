using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace CentricTeam2.Models
{
    public class Recognition
    {
        [Required]
        public Guid ID { get; set; }
        [Display(Name = "Core value recognized")]
        public CoreValue award { get; set; }
        [Display(Name = "Person giving the recognition")]
        public string recognizor { get; set; }
        [Display(Name = "Person receiving the recognition")]
        public string fullName { get { return lastName + ", " + firstName; }}

        [Display(Name = "Date recognition given")]
        public DateTime recognizationDate { get; set; }
        public string firstName { get; private set; }
        public string lastName { get; private set; }
        public virtual UserDetails UserDetails { get; set; }

        public enum CoreValue
        {
            Excellence = 1,
            Integrity = 2,
            Stewardship = 3,
            Innovate = 4,
            Balance = 5
        }
    }

}
