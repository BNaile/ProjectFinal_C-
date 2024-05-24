using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWeb.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class IntroCatController : Controller
    {
        private readonly IIntroCatService _introCatService;
        public IntroCatController(IIntroCatService introCatService)
        {
            _introCatService = introCatService;
        }

        public IActionResult Index()
        {
            var data = _introCatService.GetAll().Data;

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IntroCatCreateDto dto)
        {
            var result = _introCatService.Add(dto);
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
            var data = _introCatService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(IntroCatUpdateDto dto)
        {
            var result = _introCatService.UpDate(dto);

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
            var result = _introCatService.Delete(id);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(result);
            }
            return RedirectToAction("Index");



        }
    }
}
