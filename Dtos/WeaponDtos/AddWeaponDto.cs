using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos.WeaponDtos
{
    public class AddWeaponDto
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int CharacterId { get; set; }
    }
}
