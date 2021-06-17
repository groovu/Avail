using Availibility2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Availibility2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AvailContext _context;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        public HomeController(AvailContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.next5 = next5();
            return View(await _context.Avail.ToListAsync());
        }

        public List<List<Avail>> next5()
        {
            List<Avail> t0 = new List<Avail>();
            List<Avail> t1 = new List<Avail>();
            List<Avail> t2 = new List<Avail>();
            List<Avail> t3 = new List<Avail>();
            List<Avail> t4 = new List<Avail>();
            List<List<Avail>> days = new List<List<Avail>>() { t0, t1, t2, t3, t4 };
            foreach (var i in _context.Avail)
            {
                var delta = (i.Time.Date - DateTime.Now.Date).TotalDays;
                if ((int)delta < 0 || ((int)delta >= 5))
                {
                    continue;
                }
                else
                {
                    days[(int)delta].Add(i);
                }
            }

            return days;

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
