using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WorldTracker.Models;
using WorldTracker.Repositories;

namespace WorldTracker.Controllers
{
    public class EventsController : Controller
    {
        private IEventRepository eventRepo;
        private ILocationRepository locRepo;

        public EventsController(IEventRepository repo, ILocationRepository repoL)
        {
            eventRepo = repo;
            locRepo = repoL;
        }

        [Authorize]
        public ViewResult Index()
        {
            return View(eventRepo.GetAllEvents().ToList());
        }

        [HttpGet]
        [Authorize]
        public ViewResult EventUpdate(string Name, int EventId)
        {
            var eventVM = new EventViewModel();

            eventVM.InitialEvent = (from e in eventRepo.GetAllEvents()
                                       where e.EventID == EventId
                                       select e).FirstOrDefault<Event>();

            eventVM.Locations = locRepo.GetAllLocations().ToList();

            return View(eventVM);
        }

        [HttpPost]
        public IActionResult EventUpdate(EventViewModel eventVM)
        {
            eventVM.ModifiedEvent.Site = (from loc in locRepo.GetAllLocations()
                                            where loc.Name == eventVM.SiteName
                                            select loc).FirstOrDefault<Location>();

            eventRepo.Update(eventVM.ModifiedEvent);

            return RedirectToAction("Index", "Events");
        }

        [HttpGet]
        [Authorize]
        public IActionResult EventDelete(Event eventp)
        {
            eventRepo.Delete(eventp);

            return RedirectToAction("Index", "Events");
        }

        [HttpGet]
        [Authorize]
        public ViewResult EventAdd()
        {
            var eventAddVM = new EventAddViewModel();
            eventAddVM.Locations = locRepo.GetAllLocations().ToList();
            return View(eventAddVM);
        }

        [HttpPost]
        public IActionResult EventAdd(EventAddViewModel eventAddVM)
        {
            Event newEvent = new Event();
            newEvent.Title = eventAddVM.Event.Title;
            newEvent.WorldDate = eventAddVM.Event.WorldDate;
            newEvent.Description = eventAddVM.Event.Description;
            newEvent.Site = (from loc in locRepo.GetAllLocations()
                             where loc.Name == eventAddVM.SiteName
                             select loc).FirstOrDefault<Location>();

            eventRepo.Add(newEvent);

            return RedirectToAction("Index", "Events");
        }
    }
}