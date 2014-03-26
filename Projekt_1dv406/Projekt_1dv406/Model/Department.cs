using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekt_1dv406.Model
{
    // Klass för hantering av avdelningar
    public class Department
    {
        public int AvdID { get; set; }

        [Required(ErrorMessage = "En avdelning måste anges.")]
        [StringLength(25, ErrorMessage = "Avdelningen får bestå av max 25 tecken.")]
        public string Avdelning { get; set; }
    }
}