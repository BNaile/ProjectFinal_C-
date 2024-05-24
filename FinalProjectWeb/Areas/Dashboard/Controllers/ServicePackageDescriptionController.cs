using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWeb.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class ServicePackageDescriptionController : Controller
    {
        private readonly IServicePackageDescription _servicePackageDescriptionService;
        public ServicePackageDescriptionController(IServicePackageDescription servicePackageDescriptionService)
        {
            _servicePackageDescriptionService = servicePackageDescriptionService;
        }

        public IActionResult Index()
        {
            var data = _servicePackageDescriptionService.GetAll().Data;

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ServicePackageDescriptionCreateDto dto)
        {

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
            var data = _servicePackageDescriptionService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(ServicePackageDescriptionUpdateDto dto)
        {
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
