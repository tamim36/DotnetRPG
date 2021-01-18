using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Skills
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public List<CharacterSkills> CharacterSkills { get; set; }
    }
}
