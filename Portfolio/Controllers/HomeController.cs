using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Services;
using System.Diagnostics;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositoryProjects _repositoryProjects;
        private readonly IConfiguration configuration;
        private readonly IServicioEmail servicioEmail;

        public HomeController(ILogger<HomeController> logger, 
            IRepositoryProjects repositoryProjects, 
            IConfiguration configuration,
            IServicioEmail servicioEmail)
        {
            _logger = logger;
            this._repositoryProjects = repositoryProjects;
            this.configuration = configuration;
            this.servicioEmail = servicioEmail;
        }

        //public IActionResult Index()
        //{
        //    //ViewBag.Name = "Michael James Williams";
        //    Person person = new Person()
        //    {
        //        Name = "Michael Williams",
        //        Age = 24
        //    };

        //    return View("Index", person);
        //}

        public IActionResult Index()
        {
            var name = configuration.GetValue<string>("name");
            _logger.LogInformation("Mensaje info " + name);
            var proyectos = _repositoryProjects.GetAllProyects().Take(3).ToList();

            var model  = new HomeIndexViewModel() { Proyectos = proyectos };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Proyects()
        {
            var proyectos = _repositoryProjects.GetAllProyects();

            return View(proyectos);
        }

        public IActionResult Contacto()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Contacto(ContactoViewModel contacto)
        {
            await servicioEmail.Enviar(contacto);
            return RedirectToAction("Gracias");
        }   

        public IActionResult Gracias()
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