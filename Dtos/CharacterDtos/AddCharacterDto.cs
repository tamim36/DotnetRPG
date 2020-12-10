using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos.CharacterDtos
{
    public class AddCharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Batman";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Knight;
    }
}
