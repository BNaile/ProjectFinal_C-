using Business.Abstract;
using Entities.Concrete.Dto;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWeb.Areas.Dashboard.Controllers
{

    [Area("Dashboard")]
    [Authorize]
    public class CallMeController : Controller
    {
        
        private readonly ICallMeService _callMeService;   
        private readonly IServicePackage _servicePackage;
        public CallMeController(ICallMeService callMeService, IServicePackage servicePackage)
        {
            _callMeService = callMeService;
            _servicePackage = servicePackage;
        }

        public IActionResult Index()
        {
            var data = _callMeService.GetAll().Data;

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Service"] = _servicePackage.GetAll().Data;
            return View();
        }
        

        [HttpPost]
        public IActionResult Create(CallMeCreateDto dto)
        {
            var result = _callMeService.Add(dto);
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
            ViewData["Service"] = _servicePackage.GetAll().Data;

            var data = _callMeService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(CallMeUpdateDto dto)
        {
            ViewData["Service"] = _servicePackage.GetAll().Data;
            var result = _callMeService.UpDate(dto);
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
            var result = _callMeService.Delete(id);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(result);
            }
            return RedirectToAction("Index");



        }
    }
}
