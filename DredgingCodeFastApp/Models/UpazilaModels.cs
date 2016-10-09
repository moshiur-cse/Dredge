using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DredgingCodeFastApp.Models
{
    public class UpazilaModels
    {
        [Column(TypeName = "varchar")]
        public string District_id { get; set; }
        [Column(TypeName = "varchar")]
        public string Id { get; set; }
        [Column(TypeName = "varchar")]
        public string Upazila_name { get; set; }   
    }
}