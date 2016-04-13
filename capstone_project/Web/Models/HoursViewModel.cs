using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GVSU.Contracts;

namespace Web.Models
{
    public class HoursViewModel
    {
        public IHour Hour { get; set; }
    }
}