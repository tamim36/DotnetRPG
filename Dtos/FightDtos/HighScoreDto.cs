using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos.FightDtos
{
    public class HighScoreDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Fights { get; set; }
        public int Victories { get; set; }
        public int Defeats { get; set; }
    }
}
