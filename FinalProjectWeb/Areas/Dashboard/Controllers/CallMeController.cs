﻿using Business.Abstract;
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
        //Bu Service yazmısane onun adı hansıdı?hans; ad; bax googldan gos
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
            ViewData["Services"] = _servicePackage.GetAll().Data;
            return View();
        }
        // bir dk goz;e oz kodumda bax;m

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
            var data = _callMeService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(CallMeUpdateDto dto)
        {
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
