using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Models
{
    public class VolunteerViewModel : Controller
    {
        public class UpdateVolunteerProfile
        {
            [Display(Name = "Total Hours")]
            public int Hours { get; set; }

            [Range(1, 5)]
            [Display(Name = "Rating (1-5)")]
            public int Rating { get; set; }

            [Display(Name = "Short description")]
            public string ShortDescription { get; set; }
        }
    }
}