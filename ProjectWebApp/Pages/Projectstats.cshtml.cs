using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using ProjectWebApp.classes;
namespace ProjectWebApp.Pages
{
    public class ProjectstatsModel : PageModel
    {
        public List<Projects> lsp = new List<Projects>();
        public Projects pr = new Projects();
        public void OnGet()
        {
            this.S
            lsp = pr.AllProjects();
        }
    }
}
