using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battler
{
    internal class Combatant
    {
        public string name;
        public int health;
        public Weapon[] weapon = new Weapon[3];
        

        public Combatant(string name, int health)
        {
            this.name = name;
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
