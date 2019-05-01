using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DrawingCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;

namespace Test2.Controllers
{
    public class HomeController : Controller
    {
        private readonly TestService _testService;
        public HomeController(TestService testService)
        {
            this._testService = testService;
        }
        public IActionResult Index()
        {
            //MyDbContext _context = new MyDbContext();
            //int count = _context.JD_Commodity_001.Count();
            //var model = _context.JD_Commodity_001.Where(d => d.Id == 2).FirstOrDefault();
            //return View();

            using (EFMYSQL.MyDbContext _context = new EFMYSQL.MyDbContext())
            {
                EFMYSQL.UserInfo model = new EFMYSQL.UserInfo();
                model.Age = 5;
                model.Name = "wj";
                model.Gender = true;
                _context.UserInfo.Add(model);
                _context.SaveChanges();
            }
            return Content(_testService.Print());
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
            return View(new Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public FileStreamResult GetStream()
        {
            using (Stream fs = System.IO.File.OpenWrite(@"D:\MyCode\MyGit\ADO.NetCore\Core1\WGCore\WGCore\wwwroot\images\1.jpeg"))
            using (Bitmap bmp = new Bitmap(50, 50))
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                g.DrawString("Hello", new Font(FontFamily.GenericSansSerif, 20), Brushes.Black, new PointF(0, 0));
                bmp.Save(fs, System.DrawingCore.Imaging.ImageFormat.Jpeg);
                return File(fs, "image/jpeg");
            }
        }
    }
}
