using System.Linq;
using WorldTracker.Models;

namespace WorldTracker.Repositories
{
    public interface ICharacterRepository
    {
        IQueryable<Character> GetAllCharacters();
        Character GetCharacterByName(string name);
        int Update(Character character);
        int Delete(Character character);
        int Add(Character character);
    }
}
