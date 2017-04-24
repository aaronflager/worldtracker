using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WorldTracker.Models;
using WorldTracker.Repositories;

namespace WorldTracker.Controllers
{
    public class CharactersController : Controller
    {
        private ICharacterRepository characterRepo;

        public CharactersController(ICharacterRepository repo)
        {
            characterRepo = repo;
        }

        [Authorize]
        public ViewResult Index()
        {
            return View(characterRepo.GetAllCharacters().ToList());
        }

        [HttpGet]
        [Authorize]
        public ViewResult CharacterUpdate(string Name, int CharacterId)
        {
            var characterVM = new CharacterViewModel();

            characterVM.InitialChar = (from c in characterRepo.GetAllCharacters()
                               where c.CharacterID == CharacterId
                               select c).FirstOrDefault<Character>();

            return View(characterVM);
        }

        [HttpPost]
        public IActionResult CharacterUpdate(CharacterViewModel characterVM)
        {
            characterRepo.Update(characterVM.ModifiedChar);

            return RedirectToAction("Index", "Characters");
        }

        [HttpGet]
        [Authorize]
        public IActionResult CharacterDelete(Character character)
        {
            characterRepo.Delete(character);

            return RedirectToAction("Index", "Characters");
        }

        [HttpGet]
        [Authorize]
        public ViewResult CharacterAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CharacterAdd(Character character)
        {
            characterRepo.Add(character);

            return RedirectToAction("Index", "Characters");
        }

        [Authorize]
        public ViewResult CharacterFilter()
        {
            var characterFilterVM = new CharacterFilterViewModel();
            characterFilterVM.PriorCharacters = characterRepo.GetAllCharacters().ToList();
            characterFilterVM.Characters = characterRepo.GetAllCharacters().ToList();
            return View(characterFilterVM);
        }

        [HttpPost]
        [Authorize]
        public ViewResult CharacterFilterByClass(string filterName)
        {
            var characterFilterVM = new CharacterFilterViewModel();
            characterFilterVM.PriorCharacters = characterRepo.GetAllCharacters().ToList();
            characterFilterVM.Characters = characterRepo.GetAllCharacters().
                Where(c => c.Class == filterName).ToList();
            return View("CharacterFilter", characterFilterVM);
        }
    }
}