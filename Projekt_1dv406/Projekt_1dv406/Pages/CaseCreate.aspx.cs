﻿using Projekt_1dv406.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projekt_1dv406.Pages
{
    public partial class CaseCreate : System.Web.UI.Page
    {
        public int FelanmID { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        public void CaseCreateFormView_InsertItem(Case errorCase)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service service = new Service();
                    service.SaveCase(errorCase);
                    Page.SetTempData("Success", String.Format("Felanmälan är registrerad med ärendenummer {0}.", errorCase.FelanmID));
                    Response.RedirectToRoute("CaseAssignments", new { id = errorCase.FelanmID });
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då felanmälan skulle läggas till.");
                }
            }
        }
    }
}