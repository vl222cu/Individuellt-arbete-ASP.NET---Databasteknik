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

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
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
                    Response.RedirectToRoute("CaseListing", new { id = errorCase.FelanmID });
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då felanmälan skulle uppdateras.");
            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<Projekt_1dv406.Model.Action> ActionListView_GetData()
        {
            var actionId = ((Case)(EditErrorCaseFormView.DataItem)).FelanmID;
            return Service.GetActionByCaseId(actionId);
        }

        public IEnumerable<Department> DepartmentDropDownList_GetData()
        {
            return Service.GetDepartments();
        }

        // The id parameter name should match the DataKeyNames value set on the control
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
                    Service.UpdateAction(action);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då åtgärdinformationen skulle uppdateras.");
            }
        }
    }
}