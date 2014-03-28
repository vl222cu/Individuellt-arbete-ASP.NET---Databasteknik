using Projekt_1dv406.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projekt_1dv406.Pages
{
    public partial class CaseEdit : System.Web.UI.Page
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

        public int FelanmID { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
   
        }

        // Hämtar vald felanmälan som finns lagrad i databasen
        public Projekt_1dv406.Model.Case EditErrorCaseFormView_GetItem([RouteData]int id)
        {
            try
            {
                return Service.GetCase(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade vid hämtning av felanmälan för redigering.");
                return null;
            }
        }

        // Uppdaterar ändringar gjorda på vald felanmälan
        public void EditErrorCaseFormView_UpdateItem(int felanmId)
        {
            try
            {
                var errorCase = Service.GetCase(felanmId);

                if (errorCase == null)
                {
                    ModelState.AddModelError(String.Empty,
                        String.Format("Felanmälan med felanmälannummer {0} hittades inte", felanmId));
                    return;
                }

                if (TryUpdateModel(errorCase))
                {
                    Service.SaveCase(errorCase);
                    Page.SetTempData("Success", String.Format("Felanmälan med ärendenummer {0} är uppdaterad.", errorCase.FelanmID));
                    Response.RedirectToRoute("CaseListing", new { id = errorCase.FelanmID });
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då felanmälan skulle uppdateras.");
            }
        }

        // Hämtar åtgärd från vald felanmälan
        public IEnumerable<Projekt_1dv406.Model.Action> ActionListView_GetData()
        {
            var actionId = ((Case)(EditErrorCaseFormView.DataItem)).FelanmID;
            return Service.GetActionByCaseId(actionId);
        }

        // Hämtar alla avdelningar från databasen
        public IEnumerable<Department> DepartmentDropDownList_GetData()
        {
            return Service.GetDepartments();
        }

        // Uppdaterar ändringar på åtgärd i databasen
        public void ActionListView_UpdateItem(int ÅtgID)
        {
            try
            {
                var action = Service.GetAction(ÅtgID);

                if (action == null)
                {
                    ModelState.AddModelError(String.Empty,
                        String.Format("Felanmälan med åtgärd {0} hittades inte", ÅtgID));
                    return;
                }

                if (TryUpdateModel(action))
                {
                    Service.SaveAction(action);
                    Page.SetTempData("Success", String.Format("Åtgärd tillhörande felanmälan med ärendenummer {0} är uppdaterad.", action.FelanmID));
                    Response.RedirectToRoute("CaseListing");
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då åtgärdinformationen skulle uppdateras.");
            }
        }

        // Skapar ny åtgärd i databasen
        public void ActionListView_InsertItem(Projekt_1dv406.Model.Action action, [RouteData] int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    action.FelanmID = id;
                    Service.SaveAction(action);
                    Page.SetTempData("Success", String.Format("Åtgärd för felanmälan med ärendenummer {0} är sparad.", id));
                    Response.RedirectToRoute("CaseListing");
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då åtgärden skulle läggas till.");
                }
            }
        }

        // Raderar åtgärd i databasen
        // The id parameter name should match the DataKeyNames value set on the control
        public void ActionListView_DeleteItem(int åtgId)
        {
            try
            {
                Service.DeleteAction(åtgId);
                Page.SetTempData("Success", String.Format("Åtgärden är raderad."));
                Response.RedirectToRoute("CaseListing");
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då åtgärden skulle tas bort.");
            }
        }
    }
}