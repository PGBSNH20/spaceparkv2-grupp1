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
        private readonly SpaceContext _context;

        public SpaceshipsController(SpaceContext context)
        {
            _context = context;
        }
        [HttpGet]
         public List<Starship> GetAvailableStarships(string personName)
         {
            Results starWarsCharacter = PersonApi.GetCharacter(personName);
            return starWarsCharacter == null ? null : ShipApi.GetPersonsStarshipsAvailableForParking(starWarsCharacter, _context);
         }
        
    }
}
