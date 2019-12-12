using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using men_spa.Models;
using men_spa.Repositories;
namespace men_spa.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContactRepository _contactRepository;

        public HomeController(ILogger<HomeController> logger, IContactRepository contactRepository)
        {
            _logger = logger;
            _contactRepository = contactRepository;
        }

        public IActionResult Index()
        {
            //https://stackoverflow.com/questions/2960814/asp-mvc-access-viewdata-array
            ViewData["mustache_trimming_prices"] = new[]{
                new ServicePrice("Red Butler trimming", 27),
                new ServicePrice("French trimming", 20),
                new ServicePrice("Vietnam trimming", 25),
                new ServicePrice("Holly Bad Boy", 25),
                new ServicePrice("Vintage Trimming", 23),
                new ServicePrice("1977 Styles", 33)
                };
            //Todo: Hãy bổ xung code cho mục HAIR AND BEARD CUT PRICES
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult WhatWeDo()
        {
            return View();
        }

        public IActionResult SeeMore()
        {
            return View();
        }

        public IActionResult Gallery()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(ContactModel contactModel)
        {
            _contactRepository.AddNew(contactModel);
            return View("PostContactSubmit", contactModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
