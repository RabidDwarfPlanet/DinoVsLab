using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Battler
{
    internal class Battlefield
    {
        Combatant Dinosaur = new Combatant("Dinosaur", 100);
        Combatant Robot = new Combatant("Robot", 150);
        Weapon Tail = new Weapon("Tail", 10);
        Weapon Fists = new Weapon("Fists", 10);
        Weapon Sword = new Weapon("Sword", 15);
        Weapon Fire = new Weapon("Fire breath", 25);
        Weapon Claws = new Weapon("Claws", 15);
        Weapon Bite = new Weapon("Bite", 20);
        Weapon Railgun = new Weapon("Railgun", 25);
        Weapon Laser = new Weapon("Laser", 20);
        int milliseconds = 1500;
        string winner = null;
        string winnerChar = null;
        string loser = null;
        string currentPlayerChar = null;
        Combatant currentPlayer = null;
        string playerOneChar = null;
        string playerTwoChar = null;
        List<Combatant> Fighters = new List<Combatant>();
        List<Weapon> robotWeapons = new List<Weapon>();
        List<Weapon> dinoWeapons = new List<Weapon>();

        public Battlefield()
        {

        }

        public void welcomeMessage()
        {
            Console.WriteLine("Welcome to the battle of the ages!");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        //public void addNewWeapon()
        //{
        //    Console.WriteLine("What kind of weapon are you adding?");
        //    string newWeaponName = Console.ReadLine();
        //    Console.WriteLine("How much damage can it do?");
        //    int newWeaponAttackPower = int.Parse(Console.ReadLine());

        //    Weapon addedWeapon = new Weapon(newWeaponName, newWeaponAttackPower);
        //    robotWeapons.Add(addedWeapon);

        //    Robot.chooseWeapon(addedWeapon);

        //}

        public void chooseWeapons()
        {
            int i = 0;
            for (i = 0; i < 3; i++)
            {
                Console.WriteLine("\nWhat weapon would you like your fighter to use (Type WEAPONS for avalible weapons)");
            retry:
                string chosenWeapon = Console.ReadLine();

                if (currentPlayerChar == "robot")
                {
                    switch (chosenWeapon.ToLower())
                    {
                        case "railgun":
                            currentPlayer.chooseWeapon(Railgun, i);
                            Console.WriteLine("You have chosen a Railgun");
                            break;
                        case "laser":
                            Console.WriteLine("You have chosen a Laser");
                            currentPlayer.chooseWeapon(Laser, i);
                            break;
                        case "fist":
                        case "fists":
                            Console.WriteLine("You have chosen a Fists");
                            currentPlayer.chooseWeapon(Fists, i);
                            break;
                        case "sword":
                            Console.WriteLine("You have chosen a Sword");
                            currentPlayer.chooseWeapon(Sword, i);
                            break;
                        case "weapons":
                            Console.WriteLine("");
                            foreach (Weapon name in robotWeapons)
                            {
                                name.displayName();
                            }
                            break;
                        //case "add":
                        //    this.addNewWeapon();
                        //    break;
                        default:
                            Console.WriteLine("This is not a valid weapon, please try again");
                            goto retry;
                    }
                }
                else if (currentPlayerChar == "dino")
                {
                    switch (chosenWeapon.ToLower())
                    {
                        case "claw":
                        case "claws":
                            currentPlayer.chooseWeapon(Claws, i);
                            Console.WriteLine("You have chosen a Claws");
                            break;
                        case "bite":
                            Console.WriteLine("You have chosen a Bite");
                            currentPlayer.chooseWeapon(Bite, i);
                            break;
                        case "fire breath":
                        case "fire":
                        case "breath":
                            Console.WriteLine("You have chosen a Fire breath");
                            currentPlayer.chooseWeapon(Fire, i);
                            break;
                        case "tail":
                            Console.WriteLine("You have chosen a Tail");
                            currentPlayer.chooseWeapon(Tail, i);
                            break;
                        case "weapons":
                            Console.WriteLine("");
                            foreach (Weapon name in dinoWeapons)
                            {
                                name.displayName();
                            }
                            break;
                        //case "add":
                        //    this.addNewWeapon();
                        //    break;
                        default:
                            Console.WriteLine("This is not a valid weapon, please try again");
                            goto retry;
                    }
                }
            }
        }

        public void battleSetup()
        {
            Random rand = new Random();

            robotWeapons.Add(Railgun);
            robotWeapons.Add(Laser);
            robotWeapons.Add(Sword);
            robotWeapons.Add(Fists);
            dinoWeapons.Add(Tail);
            dinoWeapons.Add(Claws);
            dinoWeapons.Add(Bite);
            dinoWeapons.Add(Fire);
            Fighters.Add(Dinosaur);
            Fighters.Add(Robot);


            Console.WriteLine("Choose player 1's combatant (Type CHARACTERS for a list of avalible characters)");
            Combatant playerOne = null;
            string playerOneName = null;
            Combatant playerTwo = null;
            string playerTwoName = null;

            while (playerOne == null)
            {
                restart:
                string playerCommand = Console.ReadLine();

                
                switch (playerCommand.ToLower())
                {
                    case "dinosaur":
                    case "dino":
                        Combatant DinosaurP1 = new Combatant("Dinosaur", 100);
                        playerOne = DinosaurP1;
                        currentPlayerChar = "dino";
                        Console.WriteLine("\nPlayer 1 has chosen a Dinosaur");
                        break;
                    case "robot":
                        Console.WriteLine("\nPlayer 1 has chosen a Robot");
                        Combatant RobotP1 = new Combatant("Robot", 100);
                        playerOne = RobotP1;
                        currentPlayerChar = "robot";
                        break;
                    case "characters":
                        Console.WriteLine("");
                        foreach(Combatant name in Fighters)
                        {
                            name.displayName();
                        }
                        goto restart;
                    default:
                        Console.WriteLine("That is not a valid character, please pick again");
                        goto restart;
                }
                currentPlayer = playerOne;
                this.chooseWeapons();
                Console.WriteLine("What would you like to name your character?");
                playerOneName = Console.ReadLine();
            }

            Console.Clear();
            Console.WriteLine("Choose player 2's combatant (Type CHARACTERS for a list of avalible characters)");
            while (playerTwo == null)
            {
                string playerCommand = Console.ReadLine();

                switch (playerCommand.ToLower())
                {
                    case "dinosaur":
                    case "dino":
                        Combatant DinosaurP2 = new Combatant("Dinosaur", 100);
                        playerTwo = DinosaurP2;
                        string currentPlayer = "dino";
                        Console.WriteLine("\nPlayer 2 has chosen a Dinosaur");
                        break;
                    case "robot":
                        Console.WriteLine("\nPlayer 2 has chosen a Robot");
                        Combatant RobotP2 = new Combatant("Robot", 100);
                        playerTwo = RobotP2;
                        currentPlayer = "robot";
                        break;
                    case "characters":
                        Console.WriteLine("");
                        foreach (Combatant name in Fighters)
                        {
                            name.displayName();
                        }

                        break;
                    default:
                        Console.WriteLine("That is not a valid character, please pick again");
                        break;



                }

            }
            currentPlayer = playerTwo;
            this.chooseWeapons();
            Console.WriteLine("What would you like to name your character?");
            playerTwoName = Console.ReadLine();

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            while (playerOne.health > 0 && playerTwo.health > 0)
            {
                //player 1 attacks player 2
                int damage = rand.Next(playerOne.weapon.attackPower);
                playerTwo.takeDamage(damage);
                if(playerOne == Robot)
                {
                    Console.WriteLine($"\n{playerOneName} shoots {playerTwoName} with a {playerOne.weapon.type} for {damage}");
                }
                else if (playerOne == Dinosaur)
                {
                    Console.WriteLine($"\n{playerOneName} claws {playerTwoName} for {damage}");
                }

                if (playerTwo.health > 0)
                {
                    Console.WriteLine($"{playerTwoName} has {playerTwo.health} remaining");
                }
                else
                {
                    Console.WriteLine($"{playerTwoName} has died");
                    Console.ReadKey();
                }
                
                //player 2 attacks player 1
                if (playerTwo.health > 0)
                {
                    damage = rand.Next(playerTwo.weapon.attackPower);
                    playerOne.takeDamage(damage);
                    if (playerTwo == Robot)
                    {
                        Console.WriteLine($"\n{playerTwoName} shoots {playerOneName} with a {playerOne.weapon.type} for");
                        
                    }
                    else if (playerTwo == Dinosaur)
                    {
                        Console.WriteLine($"\n{playerTwoName} claws {playerOneName} for {damage}");
                    }

                    if (playerOne.health > 0)
                    {
                        Console.WriteLine($"{playerOneName} has {playerOne.health} remaining");
                    }
                    else
                    {
                        Console.WriteLine($"{playerOneName} has died");
                        Console.ReadKey();
                    }


                }

                if(playerOne.health <= 0)
                {
                    winner = playerTwoName;
                    loser = playerOneName;

                    if(playerOneChar == "robot")
                    {
                        winnerChar = "robot";
                    }
                    else if(playerOneChar == "dino")
                    {
                        winnerChar = "dino";
                    }
                }
                else if (playerTwo.health <= 0)
                {
                    winner = playerOneName;
                    loser = playerTwoName;

                    if (playerTwoChar == "robot")
                    {
                        winnerChar = "robot";
                    }
                    else if (playerTwoChar == "dino")
                    {
                        winnerChar = "dino";
                    }

                }

            }

        }


        public void pickAttack(string attack)
        {

        }

        public void victoryMessage()
        {
            bool loop = true;
            
            while (loop)
            {
                if (winnerChar == "robot")
                {
                    Console.Clear();
                    Console.WriteLine($"{winner} has defeated {loser} and is therefor victorious");
                    Console.WriteLine("\n      \\_/\r\n     (* *)\r\n    __)#(__\r\n( )( )...( )( )\r\n \\\\|| |_| ||//\r\n  \\() | | ()/\r\n    _(___)_\r\n   [-]   [-]");
                    Console.WriteLine("Please close console");
                    Thread.Sleep(milliseconds);
                    Console.Clear();
                    Console.WriteLine($"{winner} has defeated {loser} and is therefor victorious");
                    Console.WriteLine("()           ()\r\n||    \\_/    ||\r\n()   (* *)   ()\r\n \\\\ __)#(__ //\r\n   ( )...( )\r\n      |_|\r\n      | |\r\n    _(___)_\r\n   [-]   [-]");
                    Console.WriteLine("Please close console");
                    Thread.Sleep(milliseconds);
                }
                else if (winnerChar == "dino")
                {
                    
                    Console.Clear();
                    Console.WriteLine($"{winner} has defeated {loser} and is therefor victorious");
                    Console.WriteLine("            __\r\n           /oo\\\r\n          |    |\r\n      ^^  (vvvv)   ^^\r\n      \\\\  /\\__/\\  //\r\n       \\\\/      \\//\r\n        /        \\        \r\n       |          |    ^  \r\n       /          \\___/ | \r\n      (            )     |\r\n       \\----------/     /\r\n         //    \\\\_____/\r\n        W       W");
                    Console.WriteLine("Please close console");
                    Thread.Sleep(milliseconds);
                    Console.Clear();
                    Console.WriteLine($"{winner} has defeated {loser} and is therefor victorious");
                    Console.WriteLine("            __\r\n           /oo\\\r\n          |    |\r\n      ^^  (vvvv)   ^^\r\n      \\\\  /\\__/\\  //\r\n       \\\\/      \\//\r\n        /        \\        \r\n  ^    |          |  \r\n | \\___/          \\ \r\n|     (            )\r\n \\     \\----------/\r\n   \\_____//    \\\\\r\n        W       W");
                    Console.WriteLine("Please close console");
                    Thread.Sleep(milliseconds);
                }
            }
        }

        public void runGame()
        {
            this.welcomeMessage();
            this.battleSetup();
            this.victoryMessage();
        }
         

    }
}
