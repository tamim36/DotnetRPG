using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character{ Name = "Hitman"}
        };
        public async Task<ServiceResponse<List<Character>>> AddCharacter(Character character)
        {
            ServiceResponse<List<Character>> serviceResponse = new ServiceResponse<List<Character>>();
            characters.Add(character);
            serviceResponse.Data = characters;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Character>>> GetAllCharacters()
        {
            ServiceResponse<List<Character>> serviceResponse = new ServiceResponse<List<Character>>();
            serviceResponse.Data = characters;
            return serviceResponse;
        } 

        public async Task<ServiceResponse<Character>> GetCharacterById(int id)
        {
            ServiceResponse<Character> serviceResponse = new ServiceResponse<Character>();
            serviceResponse.Data = characters.FirstOrDefault(c => c.Id == id);
            return serviceResponse;
        }
    }
}
