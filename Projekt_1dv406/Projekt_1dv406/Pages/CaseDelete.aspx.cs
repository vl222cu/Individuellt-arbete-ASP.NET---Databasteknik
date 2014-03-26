using Projekt_1dv406.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projekt_1dv406.Pages
{
    public partial class CaseDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Raderar felanmälan och återgår till startsidan
        protected void DeleteLinkButton_Command(object sender, CommandEventArgs e)
        {
            try
            {
                Service service = new Service();
                var id = int.Parse(e.CommandArgument.ToString());
                service.DeleteAction(id);
                Page.SetTempData("Success", String.Format("Felanmälan med ärendenummer {0} är borttagen.", id));
                Response.RedirectToRoute("CaseListing", null);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade vid hämtning av felanmälan för borttag.");
            }
        }
    }
}