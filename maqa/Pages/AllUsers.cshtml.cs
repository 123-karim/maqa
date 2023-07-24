using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maqa.code;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace maqa.Pages
{
    public class AllUsersModel : PageModel
    {
      
        
        private readonly Idata<controler.Author> dataAuthor;
        public readonly int noofpost;

        public AllUsersModel(
            Idata<controler.Author> dataauthor
            )
        {
            
            this.dataAuthor = dataauthor;
            
            noofpost = 4;
            listAutor=new List<controler.Author>();
        }
       
        public List<controler.Author> listAutor { get; set; }
        


        public void OnGet(string getcategorypost,string search,int id)
        {
                      
            if (getcategorypost==null||getcategorypost=="All")
            {
                GetAllAuthors();

            }
           
            else if(getcategorypost=="Search")
            {
                GetAUTHORsearch(search);
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
      
        private void GetAllAuthors() 
        {
            listAutor = dataAuthor.Getalldata().Take(noofpost).ToList();
        }
     
        private void GetAUTHORsearch(string SEARSHITEM)
        {
            listAutor = dataAuthor.Searsh(SEARSHITEM).Take(noofpost).ToList();
        }
        private void GetNextData(int id)
        {
            listAutor = dataAuthor.Getalldata().Where(x => x.Id > id).Take(noofpost).ToList();
        }
        
    }
    
}
