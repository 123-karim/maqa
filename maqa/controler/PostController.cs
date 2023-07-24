using maqa.code;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace maqa.controler
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly Idata<AuthorPost> data;
        private readonly Idata<Author> dataforauthor;
        private readonly Idata<Category> dataforcategory;
        private readonly IWebHostEnvironment webHost;
        private readonly IAuthorizationService authorizationService;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly Files files;
        private readonly int PageItem;
        private Task<AuthorizationResult> result;
        private string UserId;

        public PostController(Idata<AuthorPost> data,
            Idata<Author> dataforauthor,
            Idata<Category> dataforcategory,
            IWebHostEnvironment webHost,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            this.data = data;
            this.dataforauthor = dataforauthor;
            this.dataforcategory = dataforcategory;
            this.webHost = webHost;
            this.authorizationService = authorizationService;
            this.userManager = userManager;
            this.signInManager = signInManager;
            files = new Files(this.webHost);
            PageItem = 10;
            
        }
        // GET: PostController
        public ActionResult Index(int? id)
        {
            setuser();
            if (result.Result.Succeeded)
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
            else
            {
                if (id == 0 || id == null)
                {
                    return View(data.Getdatabyuser(UserId).Take(PageItem));

                }
                else
                {
                    return View(data.Getdatabyuser(UserId).Where(x => x.Id > id).Take(PageItem));


                }
            }
           
        }
        public ActionResult Search(String SearchItem)
        {
            setuser();
            if (result.Result.Succeeded)
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
            else
            {
                if (SearchItem == null)
                {
                    return View("Index", data.Getdatabyuser(UserId));

                }
                else
                {
                    return View("Index", data.Searsh(SearchItem).Where(x=>x.UserId==UserId).ToList());

                }

            }
               
        }


        // GET: PostController/Details/5
        public ActionResult Details(int id)
        {
            setuser();
            return View(data.find(id));
            
        }

        // GET: PostController/Create
        public ActionResult Create()
        {
            setuser();
            return View();
        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuthorPostView collection)
        {
            setuser();
            try
            {
               

                var post = new AuthorPost
                {
                    AddeddDate = DateTime.Now,
                    Author = collection.Author,
                    AuthorId = dataforauthor.Getalldata().Where(x => x.UserId == UserId).Select(x => x.Id).First(),
                    category = collection.category,
                    CategoryId = dataforcategory.Getalldata().Where(x => x.Name == collection.PostCategory).Select(x => x.Id).First(),
                    FullName = dataforauthor.Getalldata().Where(x => x.UserId == UserId).Select(x => x.FullName).First(),
                    PostCategory = collection.PostCategory,
                    PostDiscription = collection.PostDiscription,
                    Posttitle = collection.Posttitle,
                    UserId = UserId,
                    UserName = dataforauthor.Getalldata().Where(x => x.UserId == UserId).Select(x => x.UserName).First(),
                    PostImgUrl = files.Uploadfile(collection.PostImgUrl, @"wwwroot\images")

                };
                data.Add(post);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostController/Edit/5
        public ActionResult Edit(int id)
        {
            var authorpost = data.find(id);
            AuthorPostView authorPostView = new AuthorPostView
            {
                AddeddDate = authorpost.AddeddDate,
                Author = authorpost.Author,
                AuthorId = authorpost.AuthorId,
                category = authorpost.category,
                CategoryId = authorpost.CategoryId,
                FullName = authorpost.FullName,
                PostCategory = authorpost.PostCategory,
                PostDiscription = authorpost.PostDiscription,
                Posttitle = authorpost.Posttitle,
                UserId = authorpost.UserId,
                UserName = authorpost.UserName,
                Id = authorpost.Id
            };
            return View(authorPostView);
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AuthorPostView collection)
        {
            setuser();
            try
            {


                var post = new AuthorPost
                {
                    AddeddDate = DateTime.Now,
                    Author = collection.Author,
                    AuthorId = dataforauthor.Getalldata().Where(x => x.UserId == UserId).Select(x => x.Id).First(),
                    category = collection.category,
                    CategoryId = dataforcategory.Getalldata().Where(x => x.Name == collection.PostCategory).Select(x => x.Id).First(),
                    FullName = dataforauthor.Getalldata().Where(x => x.UserId == UserId).Select(x => x.FullName).First(),
                    PostCategory = collection.PostCategory,
                    PostDiscription = collection.PostDiscription,
                    Posttitle = collection.Posttitle,
                    UserId = UserId,
                    UserName = dataforauthor.Getalldata().Where(x => x.UserId == UserId).Select(x => x.UserName).First(),
                    PostImgUrl = files.Uploadfile(collection.PostImgUrl, @"wwwroot\images"),
                    Id = collection.Id
                };
                data.edit(id,post);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostController/Delete/5
        public ActionResult Delete(int id)
        {
            
                return View(data.find(id));

                         

        }

        // POST: PostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AuthorPost collection)
        {
            try
            {
                data.Delete(id);
                string filepath = "~/ images /" + collection.PostImgUrl;
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
        public void setuser()
        {
            result = authorizationService.AuthorizeAsync(User, "Admin");
            UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }

}
