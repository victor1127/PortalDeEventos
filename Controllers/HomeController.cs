using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortalDeEventos.Data;
using PortalDeEventos.Models;
using System.Diagnostics;

namespace PortalDeEventos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<EventUser> _userManager;

        public HomeController(ILogger<HomeController> logger, 
            ApplicationDbContext context,
            UserManager<EventUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var events = _context.Events.ToList();
            return View(events.ToList());
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

        [Authorize]
        public async Task<IActionResult> CreateEventAsync([Bind("Name", "Location", "Time", "Description")] Events newEvent)
        {
            var user = await _userManager.GetUserAsync(User);
            newEvent.AuthorId = user.Id;

            _context.Events.Add(newEvent);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<IActionResult> RegisterToEvent(int EventId)
        {
            var user = await _userManager.GetUserAsync(User);
            var register = new EventRegistration();
            register.EventsId = EventId;
            register.EventUserId = user.Id;
            _context.EventRegistration.Add(register);
            _context.SaveChanges();

            return RedirectToAction("Index");


        }


    }
}
