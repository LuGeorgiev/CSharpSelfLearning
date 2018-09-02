namespace CamaraBazar.Web.Controllers
{
    using Models.Cameras;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Identity;
    using Services;
    using Data.Models;
    using CamaraBazar.Web.Infrastricture.Filters;

    public class CamerasController:Controller
    {
        private readonly ICameraService cameras;
        private readonly UserManager<User> userManager;

        public CamerasController(ICameraService cameras, UserManager<User> userManager)
        {
            this.cameras = cameras;
            this.userManager = userManager;
        }

        [MeasureTime]
        [Authorize]        
        public IActionResult Add() => this.View();

        [Authorize]
        [HttpPost]
        public IActionResult Add(CameraFormModel cameraModel)
        {
            if (!ModelState.IsValid)
            {
                return View(cameraModel);
            }

            this.cameras.Create(
                cameraModel.Make,
                cameraModel.Model,
                cameraModel.Price,
                cameraModel.Quantity,
                cameraModel.MinShutterSpeed,
                cameraModel.MaxShutterSpeed,
                cameraModel.MinISO,
                cameraModel.MaxISO,
                cameraModel.IsFullFrame,
                cameraModel.VideoReslution,
                cameraModel.LightMeterings,
                cameraModel.Description,
                cameraModel.ImageUrl,
                this.userManager.GetUserId(User));

            return RedirectToAction(nameof(HomeController.Index),"Home");
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var cameraExists = this.cameras.Exists(id, this.userManager.GetUserId(User));
            if (!cameraExists)
            {
                return NotFound();
            }

            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(int id, CameraFormModel cameraModel)
        {
            var updatedCamers = this.cameras.Edit(
                id,
                cameraModel.Make,
                cameraModel.Model,
                cameraModel.Price,
                cameraModel.Quantity,
                cameraModel.MinShutterSpeed,
                cameraModel.MaxShutterSpeed,
                cameraModel.MinISO,
                cameraModel.MaxISO,
                cameraModel.IsFullFrame,
                cameraModel.VideoReslution,
                cameraModel.LightMeterings,
                cameraModel.Description,
                cameraModel.ImageUrl,
                this.userManager.GetUserId(User));

            if (!updatedCamers)
            {
                return NotFound();
            }

            return RedirectToAction("SomeAction");
        }
    }
}
