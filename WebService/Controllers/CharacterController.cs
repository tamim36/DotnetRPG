using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.CharacterService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService characterService;

        public CharacterController(ICharacterService characterService)
        {
            this.characterService = characterService;
        }

        [HttpGet]
        public IActionResult GetCharacters()
        {
            return Ok(characterService.GetAllCharacters());
        }
        
        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(characterService.GetCharacterById(id));
        }

        [HttpPost]
        public IActionResult CreateCharacter(Character character)
        {
            
            return Ok(characterService.AddCharacter(character));
        }
    }
}
