using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWeb.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class ServicePackageDescriptionController : Controller
    {
        private readonly IServicePackageDescription _servicePackageDescriptionService;
        private readonly IServicePackage _servicePackageService;
        public ServicePackageDescriptionController(IServicePackageDescription servicePackageDescriptionService, IServicePackage servicePackageService)
        {
            _servicePackageDescriptionService = servicePackageDescriptionService;
            _servicePackageService = servicePackageService;
        }

        public IActionResult Index()
        {
            var data = _servicePackageDescriptionService.GetServiceWithServicePackages().Data;

            return View(data);
        }

        [HttpGet] 
        public IActionResult Create()
        {
            ViewData["ServicePackage"] = _servicePackageService.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(ServicePackageDescriptionCreateDto dto)
        {
            ViewData["ServicePackage"] = _servicePackageService.GetAll().Data;

            var result = _servicePackageDescriptionService.Add(dto);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View();
            }
            return RedirectToAction("Index");
           
        }
       
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["ServicePackage"] = _servicePackageService.GetAll().Data;
            var data = _servicePackageDescriptionService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(ServicePackageDescriptionUpdateDto dto)
        {
            ViewData["ServicePackage"] = _servicePackageService.GetAll().Data;
            var result = _servicePackageDescriptionService.UpDate(dto);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View();
            }
                return RedirectToAction("Index");

            
        }
        [HttpPost]  
        public IActionResult Delete(int id)
        {
            var result = _servicePackageDescriptionService.Delete(id);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(result);
            }
                return RedirectToAction("Index");

           

        }
    }
}
