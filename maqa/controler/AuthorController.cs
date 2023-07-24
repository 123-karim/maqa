using maqa.code;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
namespace maqa.controler
{
    public class AuthorController : Controller
    {
        private readonly IAuthorizationService authorizationService;
        private readonly Idata<Author> data;
        private readonly IWebHostEnvironment webHost;
        private readonly Files files;
        private readonly int PageItem;

        public AuthorController(IAuthorizationService authorizationService,Idata<Author>data,IWebHostEnvironment webHost)
        {
            this.authorizationService = authorizationService;
            this.data = data;
            this.webHost = webHost;
            files = new Files(this.webHost);
            PageItem = 10;
        }
        // GET: AuthorController
        [Authorize("Admin")]
        public ActionResult Index(int?id)
        {
            if (id == 0 || id == null)
            {
                return View(data.Getalldata().Take(PageItem));

            }
            else
            {
                return View(data.Getalldata().Where(x => x.Id > id).Take(PageItem));


            }
        }
        [Authorize("Admin")]
        public ActionResult Search(String SearchItem)
        {
            if (SearchItem == null)
            {
                return View("Index", data.Getalldata());

            }
            else
            {
                return View("Index", data.Searsh(SearchItem));

            }
        }

        // GET: AuthorController/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            var author=data.find(id);
            Controller_view.Authorview authorview = new Controller_view.Authorview
            {
                Id = author.Id,
                Bio = author.Bio,
                Facebook = author.Facebook,
                FullName = author.FullName,
                Instgram = author.Instgram,
                Twitter = author.Twitter,
                UserId = author.UserId,
                UserName = author.UserName,
                
            };

            return View(authorview);
        }

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(int id, Controller_view.Authorview collection)
        {
            try
            {
                var author = new Author
                {
                    Id = collection.Id,
                    Bio=collection.Bio,
                    Facebook=collection.Facebook,
                    FullName=collection.FullName,
                    Instgram=collection.Instgram,
                    Twitter=collection.Twitter,
                    UserId=collection.UserId,
                    UserName=collection.UserName,
                    ProfileImgUrl=files.Uploadfile(collection.ProfileImgUrl,@"wwwroot\images")
                };
                data.edit(id, author);
                var result = authorizationService.AuthorizeAsync(User, "Admin");
                if (result.Result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    return Redirect("/Adminindex");
                }
            }
            catch 
            {
                
                return View();
            }
        }

        // GET: AuthorController/Delete/5
        [Authorize("Admin")]
        public ActionResult Delete(int id)
        {

            var author = data.find(id);
            Controller_view.Authorview authorview = new Controller_view.Authorview
            {
                Id = author.Id,
                Bio = author.Bio,
                Facebook = author.Facebook,
                FullName = author.FullName,
                Instgram = author.Instgram,
                Twitter = author.Twitter,
                UserId = author.UserId,
                UserName = author.UserName,
            };

            return View(authorview);
        }

        // POST: AuthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("Admin")]
        public ActionResult Delete(int id, Author collection)
        {
            try
            {
                data.Delete(id);
                string filepath = "~/ images /" + collection.ProfileImgUrl;
                if (System.IO.File.Exists(filepath))
                {
                    System.IO.File.Delete(filepath);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
