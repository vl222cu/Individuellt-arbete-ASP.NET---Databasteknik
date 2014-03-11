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

        // Hämtar alla åtgärder som finns lagrade i databasen
        public IEnumerable<Action> GetActions()
        {
            return ActionDAL.GetActionList();
        }

        // Uppdaterar ändringar för vald åtgärd i databasen
        public void UpdateAction(Action action)
        {
            ActionDAL.UpdateAction(action);
        }

        public void DeleteCase(int caseId)
        {
            CaseDAL.DeleteCase(caseId);
        }

        // Hämtar alla åtgärder som finns lagrade i databasen
        public IEnumerable<Case> GetCases()
        {
            return CaseDAL.GetCases();
        }

        // Lägger till ny felanmälan i databasen
        public void SaveCase(Case errorCase)
        {
            if (errorCase.FelanmID == 0)
            {
                CaseDAL.InsertCase(errorCase);
            }
            else
            {
                CaseDAL.UpdateCase(errorCase);
            }
        }

        public Department GetDepartment(int depId)
        {
            return DepartmentDAL.GetDepartment(depId);
        }
    }
}