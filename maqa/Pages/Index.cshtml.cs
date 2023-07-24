using maqa.code;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maqa.controler;

namespace maqa.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Idata<controler.Category> dataforcategory;
        private readonly Idata<AuthorPost> dataforpost;
        public readonly int noofpost;

        public IndexModel(
            ILogger<IndexModel> logger,
            Idata<controler.Category> dataforcategory,
        Idata<controler.AuthorPost> dataforpost
            )
        {
            _logger = logger;
            this.dataforcategory = dataforcategory;
            this.dataforpost = dataforpost;
            noofpost = 4;
            listcategory = new List<controler.Category>();
            listPost=new List<AuthorPost>();
        }
        public List<controler.Category> listcategory { get; set; }
        public List<AuthorPost> listPost { get; set; }
        


        public void OnGet(string getcategorypost,string categoryname,string search,int id)
        {
            GetAllCategory();
           
            if (getcategorypost==null||getcategorypost=="All")
            {
                GetAllPost();

            }
            else if(getcategorypost=="Category") 
            {
                GetCategoryPost(categoryname);
            }
            else if(getcategorypost=="Search")
            {
                GetCategoryPostsearch(search);
            }
            else if (getcategorypost=="Next")
            {
                GetNextData(id);
            }
            else if (getcategorypost==("back"))
            {
                GetNextData(id-noofpost);
            }

        }
        private void GetAllCategory()
        {
            listcategory = dataforcategory.Getalldata();
        }
        private void GetAllPost() 
        {
            listPost = dataforpost.Getalldata().Take(noofpost).ToList();
        }
        private void GetCategoryPost(string Categoryname)
        {
            listPost = dataforpost.Getalldata().Where(c=>c.PostCategory==Categoryname).Take(noofpost).ToList();
        }
        private void GetCategoryPostsearch(string Categoryname)
        {
            listPost = dataforpost.Getalldata().Where(c => c.PostCategory == Categoryname).Take(noofpost).ToList();
        }
        private void GetNextData(int id)
        {
            listPost = dataforpost.Getalldata().Where(x => x.Id > id).Take(noofpost).ToList();
        }
        
    }
}
