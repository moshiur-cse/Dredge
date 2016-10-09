using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DredgingCodeFastApp.Models
{
    public class MauzaModels
    {
        [Column(TypeName = "varchar")]
        public string Union_id { get; set; }
        [Column(TypeName = "varchar")]
        public string Id { get; set; }
        [Column(TypeName = "varchar")]
        public string Mauza_name { get; set; }
        public int Dredger_id { get; set; }
         
    }
}