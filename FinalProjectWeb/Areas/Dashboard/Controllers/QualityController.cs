using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWeb.Areas.Dashboard.Controllers
{

    [Area("Dashboard")]
    [Authorize]
    public class QualityController : Controller
    {
        private readonly IQualityService _qualityService;
        public QualityController(IQualityService qualityService)
        {
            _qualityService = qualityService;
        }

        public IActionResult Index()
        {
            var data = _qualityService.GetAll().Data;

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(QualityCreateDto dto)
        {
            var result = _qualityService.Add(dto);
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
            var data = _qualityService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(QualityUpdateDto dto)
        {
            var result = _qualityService.UpDate(dto);

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
            var result = _qualityService.Delete(id);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(result);
            }
                return RedirectToAction("Index");

           

        }
    }
}
