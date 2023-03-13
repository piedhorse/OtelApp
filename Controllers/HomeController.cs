using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using OtelApp.DataDB;
using OtelApp.Models;
using System.Data.SqlClient;
using System.Diagnostics;
using SqlCommand = Microsoft.Data.SqlClient.SqlCommand;


namespace OtelApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        rezbilgi rezbilgi = new rezbilgi();

        public ActionResult Odalar() { 
            
            
             OtelRezervasyonContext rezervasyonContext = new OtelRezervasyonContext();
            var data = rezervasyonContext.OtelOdalaris.ToList();

            DateTime startDate = (DateTime)TempData["Gtarih"];
            DateTime endDate = (DateTime)TempData["Ctarih"];
            int kisisayisi = (int)TempData["kisisayisi"];

            if (kisisayisi==3)
            {
                ViewBag.kisisayisi = true;
            }
           

            int count = 0;

            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Friday || date.DayOfWeek == DayOfWeek.Saturday)
                {
                    count++;
                }
            }

            ViewBag.WeekdayCount = count;

            return View(data); }
      
       
      
        
        
        [HttpGet]
        public IActionResult Index()
        {
         
            return View(rezbilgi);
        }


        [HttpPost]
        public IActionResult Index(DateTime Gtarih, DateTime Ctarih,int kisisayisi)
        {
            rezbilgi rez = new rezbilgi();
            rez.kisisayisi = kisisayisi;
            rez.Ctarih= Ctarih;
            rez.Gtarih= Gtarih;

          

            TempData["Gtarih"] = Gtarih;
            TempData["Ctarih"] = Ctarih;
            TempData["kisisayisi"] = kisisayisi;

         


            return RedirectToAction("Odalar", "Home");
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