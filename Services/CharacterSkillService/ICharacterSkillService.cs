using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dtos.CharacterDtos;
using Dtos.CharacterSkillDtos;
using Models;

namespace Services.CharacterSkillService
{
    public interface ICharacterSkillService
    {
        Task<ServiceResponse<GetCharacterDto>> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill);
    }
}
