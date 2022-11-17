using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebApp.classes;

namespace ProjectWebApp.Pages
{
    public class ViewProjectsModel : PageModel
    {
        public List<Projects> prList = new List<Projects>();
        Projects objProject = new Projects();
        public void OnGet()
        {
            //On form load
            int emnum = Convert.ToInt32(ViewData["empID"]);
            prList = objProject.AllProjects();
        }
    }
}
