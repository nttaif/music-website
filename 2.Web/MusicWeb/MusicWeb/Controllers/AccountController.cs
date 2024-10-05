using Microsoft.Ajax.Utilities;
using MusicWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicWeb.Controllers
{
    public class AccountController : Controller
    {
        public CommonConnection cnn = new CommonConnection();
        // GET: Account
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            try
            {
                var user = cnn.AuthUser(username, password);
                if (user!=null)
                {
                    if (user.RoleUser == "user")
                    {
                        Session["ID"] = user.ID;
                        Session["username"] = username;
                        Session["RoleUser"] = user.RoleUser;
                        return RedirectToAction("Index", "Home");
                    }
                    if (user.RoleUser == "admin")
                    {
                        Session["ID"] = user.ID;
                        Session["username"] = username;
                        Session["RoleUser"] = user.RoleUser;
                        return RedirectToAction("Index","Admin");
                    }
                }
                else
                {
                    ViewBag.ErrorLogin = "Login account does not exist!";
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorLogin = "Login account does not exist!";
                Console.WriteLine(ex.Message);
            }
            return View();
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(string username,string email,string password,string confirmPassword)
        {
            try
            {
                AdminUserModel person= new AdminUserModel();
                if (password == confirmPassword)
                {
                    person.NameUser = username;
                    person.EmailUser = email;
                    person.RoleUser = "user";
                    person.PasswordUser = password;
                    cnn.AddAdminUser(person);
                }
                else
                {
                    ViewBag.ErrorSignUp = "Re-enter invalid password";
                    return View();
                }
            }catch (Exception ex)
            {
                ViewBag.ErrorSignUp = "Invalid registration information!";
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login","Account");
        }
    }
}