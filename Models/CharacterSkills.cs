using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class CharacterSkills
    {
        public int CharacterId { get; set; }
        public Character Character { get; set; }
        public int SkillsId { get; set; }
        public Skills Skills { get; set; }
    }
}
