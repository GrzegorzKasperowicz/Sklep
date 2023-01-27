using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sklep.Data.Model;
using Sklep.WebApp.Models;
using System.Diagnostics;

namespace Sklep.WebApp.Controllers
{
    public class HomeController : ControllerWithLoggerAndContext
    {
        public HomeController(ILogger<HomeController> logger, SklepDbContext context)
            : base(logger, context)
        {
        }

        public IActionResult Index()
        {
            var news = from s in _context.News
                           orderby s.Title
                           select s;

            return View(news);
            //ViewBag.ModelNews =
            // (
            //         from news in _context.News
            //         orderby news.Position
            //         select news
            //     ).ToList();

            //id ??= _context.News.First().IdNews;

            //var item = _context.News.Find(id);
            //return View(item);
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Details(int id)
        {
            //return View(await _context.News.Where(t => t.IdNews ==
            //id).FirstOrDefaultAsync());
            ViewBag.Types = await _context.News.ToListAsync();
            return View(await _context.News.Where(t => t.IdNews ==
           id).FirstOrDefaultAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}