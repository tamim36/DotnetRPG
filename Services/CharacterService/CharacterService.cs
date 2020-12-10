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
        public async Task<List<Character>> AddCharacter(Character character)
        {
            characters.Add(character);
            return characters;
        }

        public async Task<List<Character>> GetAllCharacters()
        {
            return characters;
        } 

        public async Task<Character> GetCharacterById(int id)
        {
            var character = characters.FirstOrDefault(c => c.Id == id);
            return character;
        }
    }
}
