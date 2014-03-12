using Projekt_1dv406.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projekt_1dv406.Pages
{
    public partial class CaseListing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Hämtar alla felanmälningar från databasen
        public IEnumerable<Case> CaseListView_GetData()
        {
            try
            {
                Service service = new Service();
                return service.GetCases();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då felanmälningar skulle hämtas.");
                return null;
            }
        }
    }
}