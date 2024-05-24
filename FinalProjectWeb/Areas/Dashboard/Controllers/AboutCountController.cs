using Business.Abstract;
using Entities.Concrete.Dto;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWeb.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class AboutCountController : Controller
    {
       
        private readonly IAboutCountService _aboutCountService;

        public AboutCountController(IAboutCountService aboutCountService)
        {
            _aboutCountService = aboutCountService;
        }

        public IActionResult Index()
        {
            var data = _aboutCountService.GetAll().Data;

            ViewBag.ShowButton = data.Count() == 0;

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AboutCountCreateDto dto)
        {
            var result = _aboutCountService.Add(dto);
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
            var data = _aboutCountService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(AboutCountUpdateDto dto)
        {
            var result = _aboutCountService.UpDate(dto);

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
            var result = _aboutCountService.Delete(id);
            if (!result.IsSuccess)
            {
                ModelState.Clear();
                ModelState.AddModelError("", result.Message);
                return View(result);
            }
                return RedirectToAction("Index");

          

        }
    }
}
