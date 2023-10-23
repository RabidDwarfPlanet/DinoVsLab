using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Battler
{
    internal class Weapon
    {
        public string type;
        public int addedAttackPower;
        public int randomAttackPower;

        public Weapon(string name, int addedAttackPower, int randomAttackPower)
        {
            this.type = name;
            this.addedAttackPower = addedAttackPower;
            this.randomAttackPower = randomAttackPower;
        }

        public void displayName()
        {
            Console.WriteLine($"{type}: {addedAttackPower} + d{randomAttackPower} damage");
        }


    }
}
