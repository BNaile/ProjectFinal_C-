using Business.Abstract;
using Entities.Concrete.Dto;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWeb.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class ExpertiseController : Controller
    {

        private readonly IExpertiseService _expertiseService;
        public ExpertiseController(IExpertiseService expertiseService)
        {
            _expertiseService = expertiseService;
        }

        public IActionResult Index()
        {
            var data = _expertiseService.GetAll().Data;

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ExpertiseCreateDto dto)
        {
            var result = _expertiseService.Add(dto);
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
            var data = _expertiseService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(ExpertiseUpdateDto dto)
        {
            var result = _expertiseService.UpDate(dto);

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
            var result = _expertiseService.Delete(id);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(result);
            }
            return RedirectToAction("Index");



        }
    }
}
