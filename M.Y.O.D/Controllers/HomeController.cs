using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using M.Y.O.D.Models;
using System.Data.Entity;
using System.IO;
using System.Web.WebPages;
using System.Threading.Tasks;

namespace Graduated.Controllers
{
    public class HomeController : Controller
    {
        readonly Context acc = new Context();

        // GET: Home
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            var menu = acc.Menu_items.ToList();
            var Cats = acc.Categories.ToList();

            var model = new ViewModel { Menu_Items = menu, Categories = Cats };

            return View(model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Editor()
        {

            var menu = acc.Menu_items.ToList();
            var Cats = acc.Categories.ToList();

            var model = new ViewModel { Menu_Items = menu, Categories = Cats };

            return View(model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult AddNew()
        {
            ViewBag.cat = new SelectList(acc.Categories.ToList(), "ID", "Cat", 1);
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult AddNew(menu_item menus)
        {
            string fileName = Path.GetFileNameWithoutExtension(menus.Myfile.FileName);
            string extention = Path.GetExtension(menus.Myfile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
            menus.Path = "~/images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/images/"), fileName);
            if (!ModelState.IsValid)
            {
                return View();
            }
            menus.Myfile.SaveAs(fileName);
            acc.Menu_items.Add(menus);
            acc.SaveChanges();
            return RedirectToAction("Editor");
        }
        [Authorize]
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            acc.Categories.Add(category);
            acc.SaveChanges();
            return RedirectToAction("Editor");
        }
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Delete(menu_item newMenu)
        {
            acc.Entry(newMenu).State = EntityState.Deleted;
            acc.SaveChanges();
            return RedirectToAction("Editor");
        }
        [Authorize]
        public ActionResult DeleteCat(Category category)
        {
            acc.Entry(category).State = EntityState.Deleted;
            acc.SaveChanges();
            return RedirectToAction("Editor");
        }
        [Authorize]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var menu = acc.Menu_items.Find(id);
            ViewBag.cat = new SelectList(acc.Categories.ToList(), "ID", "Cat", menu.CatID);
            TempData["imgPath"] = menu.Path;
            return View(menu);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Edit(menu_item NewItem)
        {
            try
            {
                if (NewItem.Myfile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(NewItem.Myfile.FileName);
                    string extention = Path.GetExtension(NewItem.Myfile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                    NewItem.Path = "~/images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/images/"), fileName);
                    NewItem.Myfile.SaveAs(fileName);
                }
                else
                {
                    NewItem.Path = TempData["imgPath"].ToString();
                }
                if (ModelState.IsValid == false)
                {
                    return View();
                }
                acc.Entry(NewItem).State = EntityState.Modified;
                acc.SaveChanges();
                return RedirectToAction("Editor");
            }
            catch
            {
                return RedirectToAction("Editor");
            }
        }
        [Authorize]
        [HttpGet]
        public ActionResult EditCat(int id)
        {
            var cat= acc.Categories.Find(id);
            return View(cat);
        }
        [Authorize]
        [HttpPost]
        public ActionResult EditCat(Category category)
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }
            acc.Entry(category).State = EntityState.Modified;
            acc.SaveChanges();
            return RedirectToAction("Editor");
        }
        [HttpGet]
        public async Task<ActionResult> Search(string searchBy,string search)
        {
            ViewData["GetDetails"] = search;
            if (searchBy == "Item")
            {     
                ViewData["radio"]="Item";
                var Menquery = from x in acc.Menu_items select x;
                if (!string.IsNullOrEmpty(search))
                {
                    Menquery = Menquery.Where(x => x.name.Contains(search));
                }
                return View(await Menquery.AsNoTracking().ToListAsync());
            }
            else
            {
                var Menquery = from x in acc.Menu_items select x;
                if (!string.IsNullOrEmpty(search))
                {
                    Menquery = Menquery.Where(x => x.Category.Cat.StartsWith(search));
                }
                return View(await Menquery.AsNoTracking().ToListAsync());
            }


            
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult> SearchEdit(string searchBy, string search)
        {
            ViewData["GetDetails"] = search;
            if (searchBy == "Item")
            {
                ViewData["radio"] = "Item";
                var Menquery = from x in acc.Menu_items select x;
                if (!string.IsNullOrEmpty(search))
                {
                    Menquery = Menquery.Where(x => x.name.Contains(search));
                }
                return View(await Menquery.AsNoTracking().ToListAsync());
            }
            else
            {
                var Menquery = from x in acc.Menu_items select x;
                if (!string.IsNullOrEmpty(search))
                {
                    Menquery = Menquery.Where(x => x.Category.Cat.StartsWith(search));
                }
                return View(await Menquery.AsNoTracking().ToListAsync());
            }
        }
    }
}
