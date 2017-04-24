using System.Linq;
using WorldTracker.Models;

namespace WorldTracker.Repositories
{
    public interface IEventRepository
    {
        IQueryable<Event> GetAllEvents();
        Event GetEventByName(string title);
        int Update(Event eventp);
        int Delete(Event eventp);
        int Add(Event eventp);
    }
}