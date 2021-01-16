using AutoMapper;
using Dtos.CharacterDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper mapper;
        private readonly DataContext dataContext;
        private readonly IHttpContextAccessor httpContextAccessor;

        public CharacterService(
            IMapper mapper,
            DataContext dataContext,
            IHttpContextAccessor httpContextAccessor) 
        {
            this.mapper = mapper;
            this.dataContext = dataContext;
            this.httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId() => int.Parse(httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Character character = mapper.Map<Character>(newCharacter);
            character.User = await dataContext.users.FirstOrDefaultAsync(u => u.Id == GetUserId());

            await dataContext.characters.AddAsync(character);
            await dataContext.SaveChangesAsync();

            serviceResponse.Data = (dataContext.characters.Where(c => c.User.Id == GetUserId()).Select(c => mapper.Map<GetCharacterDto>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                Character character = await dataContext.characters.FirstAsync(c => c.Id == id && c.User.Id == GetUserId());

                if (character == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Character not found.";
                    return serviceResponse;
                }

                dataContext.characters.Remove(character);
                await dataContext.SaveChangesAsync();
                serviceResponse.Data = (dataContext.characters.Select(c => mapper.Map<GetCharacterDto>(c))).ToList();
            }
            catch ( Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            List<Character> dbCharaters = await dataContext.characters.Where(c => c.User.Id == GetUserId()).ToListAsync();
            serviceResponse.Data = (dbCharaters.Select(c => mapper.Map<GetCharacterDto>(c))).ToList();
            return serviceResponse;
        } 

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            Character character = await dataContext.characters.FirstOrDefaultAsync(c => c.Id == id && c.User.Id == GetUserId());
            serviceResponse.Data = mapper.Map<GetCharacterDto>(character);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
                Character character = await dataContext.characters.FirstOrDefaultAsync(c => c.Id == updateCharacter.Id);
                character.HitPoints = updateCharacter.HitPoints;
                character.Defense = updateCharacter.Defense;
                character.Class = updateCharacter.Class;
                character.Intelligence = updateCharacter.Intelligence;
                character.Strength = updateCharacter.Strength;
                character.Name = updateCharacter.Name;

                dataContext.characters.Update(character);
                await dataContext.SaveChangesAsync();

                serviceResponse.Data = mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            
            return serviceResponse;
        }
    }
}
