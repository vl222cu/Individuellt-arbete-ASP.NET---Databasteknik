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
        public string Avdelning { get; set; }
    }
}