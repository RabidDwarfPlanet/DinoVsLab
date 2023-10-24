using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battler
{
    internal class Dinosaur : Combatant
    {
        Random rand = new Random();
        public int attackPower = 0;

        public Dinosaur(string dinoName, int health, int player)
        :base(dinoName, health, player) 
        {
            if (this.activeWeapon != null)
            { 
                attackPower = activeWeapon.addedAttackPower;
            }
        }

        public override int Damage()
        {
            attackPower = activeWeapon.addedAttackPower;
            int damage = this.attackPower + rand.Next(this.activeWeapon.randomAttackPower);
            return damage;
        }

    }
}
