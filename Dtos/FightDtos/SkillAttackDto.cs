using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos.FightDtos
{
    public class SkillAttackDto
    {
        public int AttackerId { get; set; }
        public int OpponentId { get; set; }
        public int SkillId { get; set; }
    }
}
