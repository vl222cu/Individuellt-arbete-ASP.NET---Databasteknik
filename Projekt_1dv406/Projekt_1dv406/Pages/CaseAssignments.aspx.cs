using Projekt_1dv406.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projekt_1dv406.Pages
{
    public partial class CaseAssignments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StatusLabel.Text = Page.GetTempData("Success") as String;
            StatusLabel.Visible = !String.IsNullOrWhiteSpace(StatusLabel.Text);

        }

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

        public int caseId { get; set; }

        // Hämtar vald felanmälan från databasen
        public Case DetailsFormView_GetItem([RouteData] int id)
        {
            try
            {
                return Service.GetCase(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då felanmälningar skulle hämtas.");
                return null;
            }
        }

        // Hämtar rätt åtgärd för vald felanmälan
        public IEnumerable<Projekt_1dv406.Model.Action> ActionListView_GetData()
        {
            var actionId = ((Case)(DetailsFormView.DataItem)).FelanmID;
            return Service.GetActionByCaseId(actionId);
        }

        // Hämtar namnet på vald avdelning från databasen
        protected void ActionListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var action = (Projekt_1dv406.Model.Action)e.Item.DataItem;
            if (action != null)
            {
                var department = Service.GetDepartments()
                    .Single(dp => dp.AvdID == action.AvdID);
                var literal = e.Item.FindControl("DepartmentLiteral") as Literal;
                literal.Text = String.Format(department.Avdelning);
            }

        }
    }
}