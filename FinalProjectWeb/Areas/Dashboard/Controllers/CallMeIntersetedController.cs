using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWeb.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class CallMeIntersetedController : Controller
    {
        private readonly ICallMeInterestedService _callMeInterstedService;
        public CallMeIntersetedController(ICallMeInterestedService callMeInterestedService)
        {
            _callMeInterstedService = callMeInterestedService;
        }

        public IActionResult Index()
        {
            var data = _callMeInterstedService.GetAll().Data;

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CallMeInterestedCreateDto dto)
        {
            var result = _callMeInterstedService.Add(dto);
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
            var data = _callMeInterstedService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(CallMeInterestedUpdateDto dto)
        {
            var result = _callMeInterstedService.UpDate(dto);

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
            var result = _callMeInterstedService.Delete(id);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);

                return View(result);
            }
            return RedirectToAction("Index");



        }
    }
}
