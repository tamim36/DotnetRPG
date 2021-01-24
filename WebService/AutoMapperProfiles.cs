using AutoMapper;
using Dtos.CharacterDtos;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dtos.SkillsDtos;
using Dtos.WeaponDtos;
using Dtos.FightDtos;

namespace WebService
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Character, GetCharacterDto>()
                .ForMember(dto => dto.Skills,
                    c => c.MapFrom(ch => ch.CharacterSkills.Select(cs => cs.Skills)));
            CreateMap<AddCharacterDto, Character>();
            CreateMap<Weapon, GetWeaponDto>();
            CreateMap<Skills, GetSkillsDto>();
            CreateMap<Character, HighScoreDto>();
        }
    }
}
