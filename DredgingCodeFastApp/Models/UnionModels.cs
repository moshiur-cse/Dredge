using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DredgingCodeFastApp.Models
{
    public class UnionModels
    {

        [Column(TypeName = "varchar")]
        public string Upazila_id { get; set; }
        [Column(TypeName = "varchar")]
        public string Id { get; set; }
        [Column(TypeName = "varchar")]
        public string Union_name { get; set; }
         
    }
}