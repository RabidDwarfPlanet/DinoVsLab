using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battler
{
    internal class Herd
    {
            public int playerNumber = 0;
            public Dinosaur dinosaurOne;
            public Dinosaur dinosaurTwo;
            public Dinosaur dinosaurThree;
            public List<Combatant> Team = new List<Combatant>();

            public Herd(int playerNumber)
            {
                this.playerNumber = playerNumber;
                dinosaurOne = new Dinosaur("Dinosaur", 50, playerNumber);
                dinosaurTwo = new Dinosaur("Dinosaur", 50, playerNumber);
                dinosaurThree = new Dinosaur("Dinosaur", 50, playerNumber);
                Team.Add(dinosaurOne); Team.Add(dinosaurTwo); Team.Add(dinosaurThree);
            }
    }
}
