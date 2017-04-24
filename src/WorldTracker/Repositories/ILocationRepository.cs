using System.Linq;
using WorldTracker.Models;

namespace WorldTracker.Repositories
{
    public interface ILocationRepository
    {
        IQueryable<Location> GetAllLocations();
        Location GetLocationByName(string name);
        int Update(Location location);
        int Delete(Location location);
        int Add(Location location);
    }
}