using Microsoft.AspNetCore.Mvc;
using Sklep.Data.Model;

namespace Sklep.WebApp.Controllers
{
    public class ControllerWithLoggerAndContext : Controller
    {
        protected readonly ILogger<HomeController> _logger;
        protected readonly SklepDbContext _context;
        public ControllerWithLoggerAndContext(ILogger<HomeController> logger, SklepDbContext context)
        {
            _logger = logger;
            _context = context;
        }
    }
}
