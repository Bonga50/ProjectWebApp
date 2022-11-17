using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebApp.classes;
using System;

namespace ProjectWebApp.Pages
{
    public class LoginModel : PageModel
    {
        public string errorMsg = "";
        public void OnGet()
        {
        }
        public void OnPost()
        {
            Employee em = new Employee();
            int empNum = Convert.ToInt32(Request.Form["txtuserID"]);
            string pass = Request.Form["txtPass"];

            em.getEmployee(empNum);
            if (em.EmployeeNum == empNum && pass.Equals(em.Password))
            {
                ViewData["empID"] = em.EmployeeNum;
               
                Response.Redirect("/ViewProjects");
            }
            else
            {
                Response.Redirect("/Login"); errorMsg = "invalid details";
            }
            
        }
    }
}
