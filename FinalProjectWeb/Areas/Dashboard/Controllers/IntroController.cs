using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWeb.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class IntroController : Controller
    {
        private readonly IIntroService _introService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public IntroController(IIntroService introService, IWebHostEnvironment webHostEnvironment)
        {
            _introService = introService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var data = _introService.GetAll().Data;

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IntroCreateDto dto, IFormFile photoUrl)
        {
            var result = _introService.Add(dto,photoUrl, _webHostEnvironment.WebRootPath);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View();
               
            }
            return RedirectToAction("Index");

            //burdaa yazdıqın kimi yazacasqa şekil yüklmeyeyi eynisidi kopya edim deyirsən 
           //sadece add olan yeri
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _introService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(IntroUpdateDto dto, IFormFile photoUrl)
        {
            var result = _introService.UpDate(dto, photoUrl, _webHostEnvironment.WebRootPath);

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
           var result = _introService.Delete(id);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);

                return View(result);
            }
                return RedirectToAction("Index");

         

        }
    }
}
