using Business.Abstract;
using Entities.Concrete.Dto;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWeb.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class PhotoCategoryController : Controller
    {
        private readonly IPhotoCategoryService _categoryService;

        public PhotoCategoryController(IPhotoCategoryService photoService)
        {
            _categoryService = photoService;
        }
        public IActionResult Index()
        {
            var data = _categoryService.GetAll().Data;

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PhotoCategoryCreateDto dto)
        {
            var result = _categoryService.Add(dto);
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
            var data = _categoryService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(PhotoCategoryUpdateDto dto)
        {
            var result = _categoryService.UpDate(dto);

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
            var result = _categoryService.Delete(id);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(result);
            }
                return RedirectToAction("Index");

           

        }
    }
}
