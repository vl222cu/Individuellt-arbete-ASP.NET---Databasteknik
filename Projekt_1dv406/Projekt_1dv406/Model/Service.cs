using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Projekt_1dv406.Model.DAL;

namespace Projekt_1dv406.Model
{
    public class Service
    {
        // Fält
        private ActionDAL _actionDAL;
        private CaseDAL _caseDAL;
        private DepartmentDAL _departmentDAL;

        // Egenskaper
        private ActionDAL ActionDAL
        {
            get
            {
                return _actionDAL ?? (_actionDAL = new ActionDAL());
            }
        }

        private CaseDAL CaseDAL
        {
            get
            {
                return _caseDAL ?? (_caseDAL = new CaseDAL());
            }
        }

        private DepartmentDAL DepartmentDAL
        {
            get
            {
                return _departmentDAL ?? (_departmentDAL = new DepartmentDAL());
            }
        }

        // Raderar vald åtgärd från databasen
        public void DeleteAction(int actionId)
        {
            ActionDAL.DeleteAction(actionId);
        }

        // Hämtar vald åtgärd från databasen
        public Action GetAction(int actionId)
        {
            return ActionDAL.GetAction(actionId);
        }

        // Hämtar vald åtgärd från databasen med FelanmID
        public List<Action> GetActionByCaseId(int caseId)
        {
           return ActionDAL.GetActionByCaseId(caseId);
        }

        // Hämtar alla åtgärder som finns lagrade i databasen
        public IEnumerable<Action> GetActions()
        {
            return ActionDAL.GetActionList();
        }

        // Uppdaterar ändringar för vald åtgärd i databasen
        public void UpdateAction(Action action)
        {
            // Validering
            ICollection<ValidationResult> validationResults;
            if (!action.Validate(out validationResults))
            {
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }

            ActionDAL.UpdateAction(action);
        }

        public void DeleteCase(int caseId)
        {
            CaseDAL.DeleteCase(caseId);
        }

        // Hämtar alla felanmälningar som finns lagrade i databasen
        public IEnumerable<Case> GetCases()
        {
            return CaseDAL.GetCases();
        }

        // Hämtar vald felanmälan som finns lagrade i databasen
        public Case GetCase(int errorCaseId)
        {
            return CaseDAL.GetCase(errorCaseId);
        }

        // Lägger till ny felanmälan i databasen
        public void SaveCase(Case errorCase)
        {
            // Validering
            ICollection<ValidationResult> validationResults;
            if (!errorCase.Validate(out validationResults))
            {
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }

            if (errorCase.FelanmID == 0)
            {
                CaseDAL.InsertCase(errorCase);
            }
            else
            {
                CaseDAL.UpdateCase(errorCase);
            }
        }

        // Hämtar lista med avdelningar och cachar alla 
        // Departmentobjekt i 10 min
        public IEnumerable<Department> GetDepartments()
        {
            var departments = HttpContext.Current.Cache["departments"] as IEnumerable<Department>;
            if (departments == null)
            {
                departments = DepartmentDAL.GetDepartments();
                HttpContext.Current.Cache.Insert("departments", departments, null, DateTime.Now.AddMinutes(10), TimeSpan.Zero);
            }
            return departments;
        }
    }
}