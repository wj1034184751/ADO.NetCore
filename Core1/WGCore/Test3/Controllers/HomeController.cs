using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test3.Models;
using Microsoft.EntityFrameworkCore;
using BLL;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Test3.Controllers
{
    public class HomeController : Controller
    {
        private static string cacheKey = "TupKey";
        private readonly IUserInfoBLL _userInfoBLL;
        private readonly IMemoryCache _cache;
        private readonly ILogger _logger;

        public HomeController(IUserInfoBLL userInfoBLL,
                              IMemoryCache cache,
                              ILoggerFactory logger)
        {
            this._userInfoBLL = userInfoBLL;
            this._cache = cache;
            this._logger = logger.CreateLogger(typeof(HomeController));
        }
        public IActionResult Index()
        {
            #region
            //string h = null;
            //h.ToString();

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
            #endregion
            _logger.LogDebug("这是一个调试信息1");
            _logger.LogWarning("警告!");
            _logger.LogInformation("Index Page says hello");
            var result = _userInfoBLL.GetUserCount();
            var result_2 = _userInfoBLL.GetBookCount();
            Tuple<int, int> resultTup = new Tuple<int, int>(result, result_2);
            _cache.Set<Tuple<int, int>>(cacheKey, resultTup);
            return View();
            //return Content(string.Format("UserInfo:Count{0},Books:Count:{1}", result, result_2));
        }

        public IActionResult About()
        {
            var testCache = _cache.Get<Tuple<int, int>>(cacheKey);
            ViewData["Message"] = string.Format("Your application description page.t1:{0},t2:{1}", testCache.Item1, testCache.Item2);
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
