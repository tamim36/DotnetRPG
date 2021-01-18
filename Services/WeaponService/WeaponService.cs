using Dtos.CharacterDtos;
using Dtos.WeaponDtos;
using Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace Services.WeaponService
{
    public class WeaponService : IWeaponService
    {
        private readonly DataContext dataContext;
        private readonly IHttpContextAccessor httpContext;
        private readonly IMapper mapper;

        public WeaponService(DataContext dataContext, IHttpContextAccessor httpContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.httpContext = httpContext;
            this.mapper = mapper;
        }
        public async Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            try
            {
                Character character = await dataContext.characters
                    .FirstOrDefaultAsync(c => c.Id == newWeapon.CharacterId && 
                                              c.User.Id == int.Parse(httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));
                if (character == null)
                {
                    response.Success = false;
                    response.Message = "Character no found";
                    return response;
                }

                Weapon weapon = new Weapon
                {
                    Name = newWeapon.Name,
                    Damage = newWeapon.Damage,
                    Character = character
                };

                await dataContext.weapons.AddAsync(weapon);
                await dataContext.SaveChangesAsync();

                response.Data = mapper.Map<GetCharacterDto>(character);
                response.Message = "Weapon added Successfully.";
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }
    }
}
