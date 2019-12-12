using System;
using men_spa.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace men_spa.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IContactRepository _contactRepository;

        public AdminController(ILogger<AdminController> logger, IContactRepository contactRepository)
        {
            _logger = logger;
            _contactRepository = contactRepository;
        }
        /*
        // Sync
        public IActionResult IndexAsync()
        {
            var all_contacts =_contactRepository.GetAll();            
            return View("Index", all_contacts);
        }*/

        public async Task<IActionResult> IndexAsync()
        {
            var all_contacts = await _contactRepository.GetAll();
            return View("Index", all_contacts);
        }
    }
}
