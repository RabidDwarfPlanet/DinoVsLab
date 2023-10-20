using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battler
{
    internal class Combatant
    {
        public string type;
        public string name;
        public int health;
        public Weapon[] weapon = new Weapon[3];
        public Weapon activeWeapon;
        

        public Combatant(string type, int health)
        {
            this.type = type;
            this.health = health;
        }

        public void displayName()
        {
            Console.WriteLine(name);
        }

        public void chooseWeapon(Weapon assignment, int place)
        {
            this.weapon[place] = assignment;
            
        }

        public void takeDamage(int damage)
        {
            this.health -= damage;
        }

        public void pickWaepon()
        {

        }

        

    
    }


    
}
