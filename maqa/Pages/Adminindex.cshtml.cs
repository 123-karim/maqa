using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maqa.code;
using maqa.controler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace maqa.Pages
{
    [Authorize]
    public class AdminindexModel : PageModel
    {
        private readonly Idata<AuthorPost> data;

        public AdminindexModel(Idata<AuthorPost> data)
        {
            this.data = data;
        }
        public int AllPOst { get; set; }
        public int PostLastMounth { get; set; }
        public int PostThisyear { get; set; }
        public void OnGet()
        {
            var datem = DateTime.Now.AddMonths(-1);
            var datey = DateTime.Now.AddYears(-1);
            var Userid = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            AllPOst = data.Getdatabyuser(Userid).Count;
            PostLastMounth = data.Getdatabyuser(Userid).Where(x => x.AddeddDate >= datem).Count();
            PostThisyear = data.Getdatabyuser(Userid).Where(x => x.AddeddDate >= datey).Count();


        }
    }
}
