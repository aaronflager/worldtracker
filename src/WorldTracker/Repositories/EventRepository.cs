using Microsoft.EntityFrameworkCore;
using System.Linq;
using WorldTracker.Models;

namespace WorldTracker.Repositories
{
    public class EventRepository : IEventRepository
    {
        private ApplicationDbContext context;

        public EventRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }


        public IQueryable<Event> GetAllEvents()
        {
            return context.Events.Include(e => e.Site);
        }

        public Event GetEventByName(string title)
        {
            Event ev = null;
            var eventList = GetAllEvents().ToList();
            foreach (Event e in eventList)
            {
                if (e.Title == title)
                {
                    ev = e;
                }
            }
            return ev;
        }

        public int Update(Event eventp)
        {
            context.Events.Update(eventp);
            return context.SaveChanges();
        }

        public int Delete(Event eventp)
        {
            context.Events.Remove(eventp);
            return context.SaveChanges();
        }

        public int Add(Event eventp)
        {
            context.Events.Add(eventp);
            return context.SaveChanges();
        }
    }
}