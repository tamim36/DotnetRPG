using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character{ Name = "Hitman"}
        };
        public List<Character> AddCharacter(Character character)
        {
            characters.Add(character);
            return characters;
        }

        public List<Character> GetAllCharacters()
        {
            return characters;
        } 

        public Character GetCharacterById(int id)
        {
            var character = characters.FirstOrDefault(c => c.Id == id);
            return character;
        }
    }
}
