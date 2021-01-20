using Models;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using Dtos.SkillsDtos;
using Dtos.WeaponDtos;

namespace Dtos.CharacterDtos
{
    public class GetCharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Batman";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Knight;
        public GetWeaponDto Weapon { get; set; }
        public List<GetSkillsDto> Skills { get; set; }
    }
}
