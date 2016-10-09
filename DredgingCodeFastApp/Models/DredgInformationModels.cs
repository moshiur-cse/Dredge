using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DredgingCodeFastApp.Models
{
    public class DredgInformationModels
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public double Density { get; set; }
        public double Velocity { get; set; }
        public double Production { get; set; }
        public int DredgerId { get; set; }

    }

}