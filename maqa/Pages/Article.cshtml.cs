using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maqa.code;
using maqa.controler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace maqa.Pages
{
    public class ArticleModel : PageModel
    {
        private readonly Idata<AuthorPost> dataforpost;
        public AuthorPost authorPost;

        public ArticleModel(Idata<controler.AuthorPost> dataforpost)
        {
            this.dataforpost = dataforpost;
            authorPost = new AuthorPost();
            
        }
        
        public void OnGet()
        {
            var id = HttpContext.Request.RouteValues["id"];
            authorPost = dataforpost.find(Convert.ToInt32(id));
        }
    }
}
