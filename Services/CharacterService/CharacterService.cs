using AutoMapper;
using Dtos.CharacterDtos;
using Microsoft.EntityFrameworkCore;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper mapper;
        private readonly DataContext dataContext;

        public CharacterService(IMapper mapper, DataContext dataContext)
        {
            this.mapper = mapper;
            this.dataContext = dataContext;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Character character = mapper.Map<Character>(newCharacter);

            await dataContext.characters.AddAsync(character);
            await dataContext.SaveChangesAsync();

            serviceResponse.Data = (dataContext.characters.Select(c => mapper.Map<GetCharacterDto>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                Character character = await dataContext.characters.FirstAsync(c => c.Id == id);
                dataContext.characters.Remove(character);

                await dataContext.SaveChangesAsync();
            }
            catch ( Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            serviceResponse.Data = (dataContext.characters.Select(c => mapper.Map<GetCharacterDto>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            List<Character> dbCharaters = await dataContext.characters.ToListAsync();
            serviceResponse.Data = (dbCharaters.Select(c => mapper.Map<GetCharacterDto>(c))).ToList();
            return serviceResponse;
        } 

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            Character character = await dataContext.characters.FirstOrDefaultAsync(c => c.Id == id);
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
