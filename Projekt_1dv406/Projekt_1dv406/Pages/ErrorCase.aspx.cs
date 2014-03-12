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
        public void ErrorCaseFormView_InsertItem(Case errorCase)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service service = new Service();
                    service.SaveCase(errorCase);
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då felanmälan skulle läggas till.");
                }
            }
        }

        
    }
}