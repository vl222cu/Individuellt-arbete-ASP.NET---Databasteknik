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

        [Required(ErrorMessage = "Textfältet Ämne får inte vara tomt.")]
        [StringLength(50, ErrorMessage = "Textfältet får bestå av max 50 tecken.")]
        public string Ämne { get; set; }

        [Required(ErrorMessage = "Textfältet Beskrivning får inte vara tomt.")]
        [StringLength(500, ErrorMessage="Textfältet får bestå av max 500 tecken.")]
        public string Felanmälan { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "Datumet har ogiltigt format.")]
        public DateTime Datum { get; set; }
    }
}