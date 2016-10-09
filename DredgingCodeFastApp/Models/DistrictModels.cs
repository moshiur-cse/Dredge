using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DredgingCodeFastApp.Models
{
    public class DistrictModels
    {
        [Column(TypeName = "varchar")]
        public string Division_id { get; set; }
        [Column(TypeName = "varchar")]
        public string Id { get; set; }
        [Column(TypeName = "varchar")]
        [DisplayName("District Name")]
        public string District_name { get; set; }

    }
}