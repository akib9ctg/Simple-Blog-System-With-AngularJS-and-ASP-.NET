using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogSystemApp.Models;

namespace BlogSystemApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User user)
        {
            ModelState.Clear();
            ViewBag.Message = "Account Created Succesfully";
            return View();
        }
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(SignIn signIn)
        {
           
            MyDbContext myDbContext = new MyDbContext();

            SqlParameter userEmail = string.IsNullOrEmpty(signIn.Email) ? new SqlParameter("@userEmail", DBNull.Value) : new SqlParameter("@userEmail", signIn.Email);
            SqlParameter userPassword = string.IsNullOrEmpty(signIn.Password) ? new SqlParameter("@userPassword", DBNull.Value) : new SqlParameter("@userPassword", signIn.Password);

            List<User>users = myDbContext.Database.SqlQuery<User>("EXEC LoginCheck @userEmail,@userPassword", userEmail, userPassword).ToList();
            if (users.Count == 1)
            {
                
                Session["Login"] = 1;
                Session["Id"] = users[0].Id;
                return RedirectToAction("Post", "Home");
            }
            else
            {
                Session["Login"] = 0;
                ViewBag.Message = "Invalid Email or Password";
                return View();
            }

            
        }
       
        public ActionResult Post()
        {
            if (Convert.ToInt32(Request["logout"]) == 1)
            {
                Session.Clear();
                return RedirectToAction("SignIn", "Home");
            }
            return View();
        }

        public ActionResult Profile()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}