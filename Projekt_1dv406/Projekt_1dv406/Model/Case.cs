using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekt_1dv406.Model
{
    // Klass för hantering av felanmälan
    public class Case
    {
        public int FelanmID { get; set; }

        [Required(ErrorMessage = "Textfältet får inte vara tomt.")]
        [StringLength(500, ErrorMessage="Textfältet får bestå av max 500 tecken.")]
        public string Felanmälan { get; set; }

        public int KatID { get; set; }
        public int PrioID { get; set; }
        public DateTime Datum { get; set; }
    }
}