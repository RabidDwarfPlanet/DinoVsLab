using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battler
{
    internal class Robot : Combatant
    {
        Random rand = new Random();
        public Robot(string botName, int health, int player)
        : base(botName, health, player)
        {


        }

        public override int Damage()
        {
            int damage = this.activeWeapon.addedAttackPower + rand.Next(this.activeWeapon.randomAttackPower);
            return damage;
        }
    }
}


