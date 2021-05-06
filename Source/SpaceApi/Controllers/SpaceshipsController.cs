using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceApi.Models;
using SpaceApi.SWAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            Results starWarsCharacter = GetCharacter(personName);
            if (starWarsCharacter == null) return null;
            List<Starship> starships = new List<Starship>();
            starships = ShipApi.GetPersonsStarshipsAvailableForParking(starWarsCharacter, _context);
            return starships;
         }
        private static Results GetCharacter(string personName)
        {
            var personApi = new PersonApi();
            var apiResult = personApi.GetAllPersons();
            Results user = apiResult.Result.FirstOrDefault(p => p.Name == personName);
            return user;
        }
    }
}
