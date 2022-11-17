using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebApp.classes;
using System;

namespace ProjectWebApp.Pages
{
    public class EditProjectModel : PageModel
    {
        public Projects pr = new Projects();
        public void OnGet()
        {
            string code = Request.Query["PrCode"];

            pr.GetProjects(code);
        }
        public void OnPost() {
            string code = Request.Query["PrCode"];
            string name = Request.Form["txtPrName"];
            DateTime startDate = Convert.ToDateTime(Request.Form["txtStartDate"]);
            DateTime endDate = Convert.ToDateTime(Request.Form["txtEndDate"]);


            int rate = Convert.ToInt32(Request.Form["txtRate"]);
            Projects projects = new Projects(code,name,startDate,endDate);
            projects.calcEstimatedCost(rate);
            projects.UpdateProject(code);
        }
    }
}
