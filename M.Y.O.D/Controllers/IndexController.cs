using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using M.Y.O.D.Models;
using System.Web.Security;

namespace Graduated.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        readonly Context acc = new Context();
        [Authorize]
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult Register(Register NewData)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            acc.Registers.Add(NewData);
            acc.SaveChanges();

            return RedirectToAction("LogIn");
        }
        public ActionResult EmailExist(string Email)
        {
            return Json(!acc.Registers.Any(ww => ww.Email == Email), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(Register user, logIn NewLog)
        {
            var usr = acc.Registers.SingleOrDefault(ww => ww.Email == user.Email && ww.pwd == user.pwd);
            if (usr != null)
            {
                Session["id"] = usr.id.ToString();
                Session["Email"] = usr.Email.ToString();
                NewLog.DateTime = DateTime.Now.ToString();
                acc.LogIns.Add(NewLog);
                acc.SaveChanges();
                if (IsValid(user))
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    return RedirectToAction("Editor", "Home");  
                }
      
            }
            else
            {
                ModelState.AddModelError("", "Email Or Password Is Wrong !!!");
            }
            return View();
        }
        
        private bool IsValid(Register user)
        {
            var usr = acc.Registers.SingleOrDefault(ww => ww.Email == user.Email && ww.pwd == user.pwd);
                return (user.Email == usr.Email && user.pwd == usr.pwd);  
        }

    }


}