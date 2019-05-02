using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test3.Models;
using Microsoft.EntityFrameworkCore;
using BLL;

namespace Test3.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserInfoBLL _userInfoBLL;

        public HomeController(IUserInfoBLL userInfoBLL)
        {
            this._userInfoBLL = userInfoBLL;
        }
        public IActionResult Index()
        {
            //using (EFMYSQL.MyDbContext _context = new EFMYSQL.MyDbContext())
            //{
            //    //var model = _context.UserInfo.FirstOrDefault();
            //    //EFMYSQL.UserInfo model = new EFMYSQL.UserInfo();
            //    //model.Age = 5;
            //    //model.Name = "wj";
            //    //model.Gender = true;
            //    //_context.UserInfo.Add(model);
            //    //_context.SaveChanges();
            //    var boo = _context.T_Books.Include(b=>b.Author).Where(d => d.Id == 2).FirstOrDefault();
            //}
            var result = _userInfoBLL.GetUserCount();
            var result_2 = _userInfoBLL.GetBookCount();
            //return View();
            return Content(string.Format("UserInfo:Count{0},Books:Count:{1}", result, result_2));
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
