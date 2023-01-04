using Business.Layer.Services;
using Data.Access.Layer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Layer.Models;
using System.Diagnostics;

namespace Presentation.Layer.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeService _empService;
        private readonly IGuardService _guardService;
        public HomeController(IEmployeeService empService, IGuardService guardService)
        {
            _empService = empService;
            _guardService = guardService;
        }

        public IActionResult Index()
        {
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

        public IActionResult show(string fn, string ln)
        {
            return View(_empService.GetEmp(fn, ln));
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpGet]
        
        public IActionResult Badge(string fn, string ln, int ecode)
        {

            return View(_guardService.SignInBadge(fn, ln, ecode));
        }

        [HttpGet]
        
        public IActionResult BadgeOut(int id)
        {
            _guardService.SignOutBadge(id);
            return RedirectToAction(nameof(GetBadges));
        }

        
        [HttpGet]
        public IActionResult GetBadges()
        {
            return View(_guardService.GetBadges());
        }

        //================== changes ============
        [HttpPost]
        public IActionResult SignOutPage(string TempBadge)
        {
           _guardService.SignOutPage(TempBadge);
            return RedirectToAction("Index","Home");
            
        }

        [HttpGet]
        public IActionResult SignOutPage()
        {
            return View();

        }

        [Authorize]
        public IActionResult BadgeOutPage()
        {
            return View(_guardService.GetMultiModels());
        }

        /*public IActionResult BadgeReportPage()
        {
            return View(_guardService.GetReports());
        }*/

        //===========================

        [HttpPost]
        
        public IActionResult BadgeReportPage(DateTime StartDate, DateTime EndDate, string FirstName, string LastName, string Status)
        {
            return View(_guardService.GetReports(StartDate, EndDate, FirstName, LastName, Status));
        }

        [HttpGet]
        [Authorize]
        public IActionResult BadgeReportPage()
        {
            return View(_guardService.GetNReports());
        }

        /*[HttpGet]
        public IActionResult SignOut(int id)
        {
            _guardService.SignOutBadge(id);
            return RedirectToAction(nameof(SignOut));
        }*/
        [Authorize]
        public IActionResult BadgeQueuePage()
        {
            return View(_guardService.GetBadgeQueue());
        }
    }
}