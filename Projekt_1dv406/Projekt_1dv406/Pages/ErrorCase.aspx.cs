using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projekt_1dv406.Model;

namespace Projekt_1dv406.Pages
{
    public partial class ErrorCase : System.Web.UI.Page
    {
        // Fält
        private Service _service;

        // Egenskap
        private Service Service
        {
            get
            {
                return _service ?? (_service = new Service());
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ErrorCaseFormView_InsertItem(Case errorCase)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service.SaveCase(errorCase);
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då felanmälan skulle läggas till.");
                }
            }
        }

        
    }
}