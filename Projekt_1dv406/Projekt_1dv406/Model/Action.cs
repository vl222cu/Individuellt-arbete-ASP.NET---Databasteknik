using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekt_1dv406.Model
{
    public class Action
    {
        public int ÅtgID { get; set; }
        public int FelanmID { get; set; }
        public int AvdID { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime SlutDatum { get; set; }
    }
}