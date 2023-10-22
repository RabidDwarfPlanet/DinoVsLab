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
        public int player;
        public Weapon[] weapon = new Weapon[3];
        public Weapon activeWeapon;


        public Combatant(string type, int health, int player)
        {
            this.type = type;
            this.health = health;
            this.player = player;
        }

        public void takeDamage(int damage)
        {
            this.health -= damage;
        }

        public void displayType()
        {
            Console.WriteLine(type);
        }

        public void chooseWeapon(Weapon assignment, int place)
        {
            this.weapon[place] = assignment;

        }






    }


    
}
