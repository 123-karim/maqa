using maqa.code;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace maqa.controler
{
    [Authorize("Admin")]
    public class CategoryController : Controller
    {
        private readonly Idata<Category> data;
        private readonly int PageItem;
        public CategoryController(Idata<Category>data)
        {
            this.data = data;
            PageItem = 10;
        }
        // GET: CategoryController
        public ActionResult Index(int?id)
        {
            if (id==0||id==null)
            {
                return View(data.Getalldata().Take(PageItem));

            }
            else
            {
                return View(data.Getalldata().Where(x=>x.Id>id).Take(PageItem));
               

            }
        }
        public ActionResult Search(String SearchItem)
        {
            if (SearchItem==null)
            {
                return View("Index",data.Getalldata());

            }
            else
            {
                return View("Index",data.Searsh(SearchItem));

            }
        }


        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category collection)
        {
            try
            {
                var result=data.Add(collection);
                if (result==1)
                {
                  return RedirectToAction(nameof(Index));

                }
                else
                {
                    return View();

                }
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(data.find(id));
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category collection)
        {
            try
            {
                var result = data.edit(id,collection);
                if (result == 1)
                {
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    return View();

                }
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Category collection)
        {
            try
            {
                var result = data.Delete(id);
                if (result == 1)
                {
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    return View();

                }
            }
            catch
            {
                return View();
            }
        }
    }
}
