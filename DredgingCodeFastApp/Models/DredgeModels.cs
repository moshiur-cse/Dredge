using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DredgingCodeFastApp.Models
{
    public class DredgeModels
    {
        public int Id { get; set; }
        [DisplayName("Dredger Name")]
        public string Name { get; set; }
    }
}