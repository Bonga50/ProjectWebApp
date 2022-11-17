using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebApp.classes;

namespace ProjectWebApp.Pages
{
    public class NewProjectModel : PageModel
    {
       
        public void OnGet()
        {
           
        }

        public void OnPost()
        {
            string code = Request.Form["txtCode"];
            string name = Request.Form["txtPrName"];
            DateTime startDate = Convert.ToDateTime(Request.Form["txtStartDate"]);
            DateTime endDate = Convert.ToDateTime(Request.Form["txtEndDate"]);

            Projects newProj = new Projects(code, name, startDate, endDate);
            newProj.calcEstimatedCost(150);
            Employee em = new Employee();
            newProj.Emp.EmployeeNum = 1000;
            newProj.AddProject();
        }
        
    }
}
