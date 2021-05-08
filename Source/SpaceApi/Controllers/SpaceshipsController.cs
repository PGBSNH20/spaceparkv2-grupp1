using Microsoft.AspNetCore.Mvc;
using SpaceApi.Models;
using SpaceApi.SWAPI;
using System.Collections.Generic;
using System.Linq;

namespace SpaceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpaceshipsController : Controller
    {
        private readonly ISpaceContext _context;

        public SpaceshipsController(ISpaceContext context)
        {
            _context = context;
        }
        [HttpGet]
         public List<Starship> GetAvailableStarships(string personName)
         {
            Results starWarsCharacter = PersonApi.GetCharacter(personName);
            if (starWarsCharacter == null) return null;
            List<Starship> starships = new List<Starship>();
            starships = ShipApi.GetPersonsStarshipsAvailableForParking(starWarsCharacter, _context);
            return starships;
         }
    }
}
