using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWeb.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class PhotoController : Controller
    {
        private readonly IPhotoService _photoService;
        private readonly IPhotoCategoryService _photoCategoryService;
        public PhotoController(IPhotoService photoService, IPhotoCategoryService photoCategoryService)
        {
            _photoService = photoService;
            _photoCategoryService = photoCategoryService;
        }

        public IActionResult Index()
        {
            var data = _photoService.GetPhotMeWithCategory().Data;

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["PhotoCategories"] = _photoCategoryService.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(PhotoCreateDto dto)
        {
            ViewData["PhotoCategories"] = _photoCategoryService.GetAll().Data;
            var result = _photoService.Add(dto);
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
            ViewData["PhotoCategories"] = _photoCategoryService.GetAll().Data;
            var data = _photoService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(PhotoUpdateDto dto)
        {
            var result = _photoService.UpDate(dto);

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
            var result = _photoService.Delete(id);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(result);
            }
                return RedirectToAction("Index");

           

        }
    }
}
