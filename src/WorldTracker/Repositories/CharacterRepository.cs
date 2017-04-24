using System.Linq;
using WorldTracker.Models;

namespace WorldTracker.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
            private ApplicationDbContext context;

            public CharacterRepository(ApplicationDbContext ctx)
            {
                context = ctx;
            }


        public IQueryable<Character> GetAllCharacters()
        {
            return context.Characters;
        }

        public Character GetCharacterByName(string name)
        {
            Character character = null;
            var characterList = GetAllCharacters().ToList();
            foreach (Character c in characterList)
            {
                if (c.Name == name)
                {
                    character = c;
                }
            }
            return character;
        }

        public int Update(Character character)
        {
            context.Characters.Update(character);
            return context.SaveChanges();
        }

        public int Delete(Character character)
        {
            context.Characters.Remove(character);
            return context.SaveChanges();
        }

        public int Add(Character character)
        {
            context.Characters.Add(character);
            return context.SaveChanges();
        }
    }
}
