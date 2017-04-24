using System.Linq;
using WorldTracker.Models;

namespace WorldTracker.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private ApplicationDbContext context;

        public LocationRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }


        public IQueryable<Location> GetAllLocations()
        {
            return context.Locations;
        }

        public Location GetLocationByName(string name)
        {
            Location location = null;
            var locationList = GetAllLocations().ToList();
            foreach (Location loc in locationList)
            {
                if (loc.Name == name)
                {
                    location = loc;
                }
            }
            return location;
        }

        public int Update(Location location)
        {
            context.Locations.Update(location);
            return context.SaveChanges();
        }

        public int Delete(Location location)
        {
            context.Locations.Remove(location);
            return context.SaveChanges();
        }

        public int Add(Location location)
        {
            context.Locations.Add(location);
            return context.SaveChanges();
        }
    }
}
