using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWeb.Areas.Dashboard.Controllers
{

    [Area("Dashboard")]
    [Authorize]
    public class ServicePackageController : Controller
    {
        private readonly IServicePackage _serviceService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ServicePackageController(IServicePackage serviceService, IWebHostEnvironment webHostEnvironment)
        {
            _serviceService = serviceService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var data = _serviceService.GetAll().Data;

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ServicePackageCreateDto dto, IFormFile photoUrl)
        {

            var result = _serviceService.Add(dto, photoUrl, _webHostEnvironment.WebRootPath);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(dto);
               
            }
            return RedirectToAction("Index");


        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _serviceService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(ServicePackageUpdateDto dto, IFormFile photoUrl)
        {
            var result = _serviceService.UpDate(dto, photoUrl, _webHostEnvironment.WebRootPath);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(dto);
            }
                return RedirectToAction("Index");

           
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _serviceService.Delete(id);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(result);
            }
                return RedirectToAction("Index");

         

        }
    }
}
