using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWeb.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class BusinessCatController : Controller
    {
        //[Authorize]

        private readonly IBusinessCatService _businessService;
        public BusinessCatController(IBusinessCatService businessService)
        {
            _businessService = businessService;
        }

        public IActionResult Index()
        {
            var data = _businessService.GetAll().Data;

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BusinessCatCreateDto dto)
        {
            var result = _businessService.Add(dto);
            if (!result.IsSuccess)
            {
                ModelState.Clear();
                ModelState.AddModelError("", result.Message);
                return View();
            }
            return RedirectToAction("Index");


        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _businessService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(BusinessCatUpdateDto dto)
        {
            var result = _businessService.UpDate(dto);

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
            var result = _businessService.Delete(id);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(result);
            }
            return RedirectToAction("Index");



        }


    }
}
