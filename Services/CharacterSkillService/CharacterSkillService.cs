using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dtos.CharacterDtos;
using Dtos.CharacterSkillDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Models;
using Repositories;

namespace Services.CharacterSkillService
{
    public class CharacterSkillService : ICharacterSkillService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMapper _mapper;

        public CharacterSkillService(DataContext context, IHttpContextAccessor httpContext, IMapper mapper)
        {
            _context = context;
            _httpContext = httpContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GetCharacterDto>> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            try
            {
                Character character = await _context.characters
                    .Include(c => c.Weapon)
                    .Include(c => c.CharacterSkills).ThenInclude(cs => cs.Skills)
                    .FirstOrDefaultAsync(c => c.Id == newCharacterSkill.CharacterId
                                              && c.User.Id ==
                                              int.Parse(_httpContext.HttpContext.User.FindFirstValue(ClaimTypes
                                                  .NameIdentifier)));
                if (character == null)
                {
                    response.Success = false;
                    response.Message = "Character not found.";
                    return response;
                }

                Skills skills = await _context.skills
                    .FirstOrDefaultAsync(s => s.Id == newCharacterSkill.SkillsId);
                if (skills == null)
                {
                    response.Success = false;
                    response.Message = "Skills not found.";
                    return response;
                }

                CharacterSkills characterSkills = new CharacterSkills
                {
                    Character = character,
                    Skills = skills
                };
                await _context.characterSkills.AddAsync(characterSkills);
                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetCharacterDto>(character);
                response.Message = "Skill Added.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
