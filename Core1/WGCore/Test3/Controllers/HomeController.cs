using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test3.Models;
using Microsoft.EntityFrameworkCore;
namespace Test3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (EFMYSQL.MyDbContext _context = new EFMYSQL.MyDbContext())
            {
                //var model = _context.UserInfo.FirstOrDefault();
                //EFMYSQL.UserInfo model = new EFMYSQL.UserInfo();
                //model.Age = 5;
                //model.Name = "wj";
                //model.Gender = true;
                //_context.UserInfo.Add(model);
                //_context.SaveChanges();
                var boo = _context.T_Books.Include(b=>b.Author).Where(d => d.Id == 2).FirstOrDefault();
            }
            return View();
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
