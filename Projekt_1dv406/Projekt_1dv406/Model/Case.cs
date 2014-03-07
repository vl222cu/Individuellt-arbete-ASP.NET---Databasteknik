using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekt_1dv406.Model
{
    public class Case
    {
        public int FelanmID { get; set; }
        public string Felanmälan { get; set; }
        public int KatID { get; set; }
        public int PrioID { get; set; }
        public DateTime Datum { get; set; }
    }
}