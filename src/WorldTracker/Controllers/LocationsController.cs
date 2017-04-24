using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WorldTracker.Models;
using WorldTracker.Repositories;

namespace WorldTracker.Controllers
{
    public class LocationsController : Controller
    {
        private ILocationRepository locationRepo;

        public LocationsController(ILocationRepository repo)
        {
            locationRepo = repo;
        }

        [Authorize]
        public ViewResult Index()
        {
            return View(locationRepo.GetAllLocations().ToList());
        }

        [HttpGet]
        [Authorize]
        public ViewResult LocationUpdate(string Name, int LocationId)
        {
            var locationVM = new LocationViewModel();

            locationVM.InitialLoc = (from l in locationRepo.GetAllLocations()
                                       where l.LocationID == LocationId
                                       select l).FirstOrDefault<Location>();

            return View(locationVM);
        }

        [HttpPost]
        public IActionResult LocationUpdate(LocationViewModel locationVM)
        {
            locationRepo.Update(locationVM.ModifiedLoc);

            return RedirectToAction("Index", "Locations");
        }

        [HttpGet]
        [Authorize]
        public IActionResult LocationDelete(Location location)
        {
            locationRepo.Delete(location);

            return RedirectToAction("Index", "Locations");
        }

        [HttpGet]
        [Authorize]
        public ViewResult LocationAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LocationAdd(Location location)
        {
            locationRepo.Add(location);

            return RedirectToAction("Index", "Locations");
        }
    }
}