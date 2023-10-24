using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battler
{
    internal class Fleet
    {
        public int playerNumber = 0;
        public Robot robotOne;
        public Robot robotTwo;
        public Robot robotThree;
        public List<Combatant> Team = new List<Combatant>();

        public Fleet(int playerNumber)
        {
            this.playerNumber = playerNumber;
            robotOne = new Robot("Robot", 50, playerNumber);
            robotTwo = new Robot("Robot", 50, playerNumber);
            robotThree = new Robot("Robot", 50, playerNumber);
            Team.Add(robotOne); Team.Add(robotTwo); Team.Add(robotThree);   
        }
    }
}
