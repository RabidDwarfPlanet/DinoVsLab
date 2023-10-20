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
        public int attackPower;

        public Weapon(string name, int attackPower)
        {
            this.type = name;
            this.attackPower = attackPower;
        }

        public void displayName()
        {
            Console.WriteLine(type);
        }
    }
}
