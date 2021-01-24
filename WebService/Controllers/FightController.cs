using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Services.FightService;
using Dtos.FightDtos;
using Models;

namespace WebService.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FightController : ControllerBase
    {
        private readonly IFightService fightService;

        public FightController(IFightService fightService)
        {
            this.fightService = fightService;
        }

        [HttpPost("weapon")]
        public async Task<IActionResult> WeaponAttack(WeaponAttackDto request)
        {
            ServiceResponse<AttackResultDto> response = await fightService.WeaponAttack(request);
            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("skill")]
        public async Task<IActionResult> SkillAttack(SkillAttackDto request)
        {
            ServiceResponse<AttackResultDto> response = await fightService.SkillAttack(request);
            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> FightAttack(FightRequestDto request)
        {
            ServiceResponse<FightResultDto> response = await fightService.Fight(request);
            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> HighScore()
        {
            ServiceResponse<List<HighScoreDto>> response = await fightService.GetHighScore();
            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
