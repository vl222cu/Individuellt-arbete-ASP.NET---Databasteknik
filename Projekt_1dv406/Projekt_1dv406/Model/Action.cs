using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekt_1dv406.Model
{
    // Klass för hantering av åtgärder på felanmälan
    public class Action
    {
        public int ÅtgID { get; set; }
        public int FelanmID { get; set; }
        public int AvdID { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "Datumet har ogiltigt format.")]
        public DateTime StartDatum { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "Datumet har ogiltigt format.")]
        public DateTime SlutDatum { get; set; }
    }
}