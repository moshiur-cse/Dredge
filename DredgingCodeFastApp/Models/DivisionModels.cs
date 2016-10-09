using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DredgingCodeFastApp.Models
{
    public class DivisionModels
    {
        [Column(TypeName = "varchar")]
       
        public string Id { get; set; }
        [Column(TypeName = "varchar")]
        [DisplayName("Division Name")]
        public string Division_name { get; set; }
  
    }
}