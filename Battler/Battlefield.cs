using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Battler
{
    internal class Battlefield
    {
        Dinosaur displayDinosaur = new Dinosaur("Dinosaur", 100, 0);
        Robot displayRobot = new Robot("Robot", 150, 0);
        Weapon Tail = new Weapon("Tail", 5, 5);
        Weapon Fists = new Weapon("Fists", 5, 5);
        Weapon Sword = new Weapon("Sword", 10, 5);
        Weapon Fire = new Weapon("Fire breath", 0, 25);
        Weapon Claws = new Weapon("Claws", 10, 5);
        Weapon Bite = new Weapon("Bite", 5, 15);
        Weapon Railgun = new Weapon("Railgun", 0, 25);
        Weapon Laser = new Weapon("Laser", 5, 15);
        Random rand = new Random();
        int milliseconds = 1500;
        string winner = null;
        string winnerChar = null;
        string loser = null;
        string currentPlayerChar = null;
        Combatant currentPlayer = null;
        Combatant opponent = null;
        string playerOneChar = null;
        string playerTwoChar = null;
        List<Combatant> Fighters = new List<Combatant>();
        List<Weapon> robotWeapons = new List<Weapon>();
        List<Weapon> dinoWeapons = new List<Weapon>();
        List<Combatant> playerOneTeam = new List<Combatant>();
        List<Combatant> playerTwoTeam = new List<Combatant>();
        List<Combatant> currentTeam = new List<Combatant>();
        List<Combatant> opponentTeam = new List<Combatant>();
        bool groupBattle = false;
        Combatant playerOne = null;
        Combatant playerTwo = null;
        int playerNumber = 0;
        


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


        public void pickCharacter(int playerNumber)
        {

            restart:
            string playerCommand = Console.ReadLine();
            switch (playerCommand.ToLower())
            {
                case "dinosaur":
                case "dinosaurs":
                case "dino":
                case "dinos":
                case "herd":
                    if (groupBattle == false)
                    {
                        Dinosaur Dinosaur = new Dinosaur("Dinosaur", 50, playerNumber);
                        
                        if(playerNumber == 1)
                        {
                            playerOne = Dinosaur;
                            playerOneChar = "dino";
                        }
                        if (playerNumber == 2)
                        {
                            playerTwo = Dinosaur;
                            playerTwoChar = "dino";
                        }
                        
                    }
                    else
                    {
                        Herd herd = new Herd(playerNumber);
                        if (playerNumber == 1)
                        {
                            playerOneTeam = herd.Team;

                        }
                        else if (playerNumber == 2)
                        {
                            playerTwoTeam = herd.Team;

                        }
                    }
                    if (groupBattle == false)
                    {
                        Console.WriteLine($"\nPlayer {playerNumber} has chosen a Dinosaur");
                    }
                    else
                    {
                        Console.WriteLine($"\nPlayer {playerNumber} has chosen Dinosaurs");
                    }
                    currentPlayerChar = "dinosaur";
                    
                    break;
                case "robot":
                case "robots":
                case "fleet":
                    if (groupBattle == false)
                    {
                        Robot Robot = new Robot("Robot", 50, playerNumber);

                        if (playerNumber == 1)
                        {
                            playerOne = Robot;
                            playerOneChar = "robot";
                        }
                        if (playerNumber == 2)
                        {
                            playerTwo = Robot;
                            playerTwoChar = "robot";
                        }
                    }
                    else
                    {
                        Fleet fleet = new Fleet(playerNumber);
                        if (playerNumber == 1)
                        {
                            playerOneTeam = fleet.Team;

                        }
                        else if (playerNumber == 2)
                        {
                            playerTwoTeam = fleet.Team;

                        }

                    }
                    if(groupBattle == false)
                    {
                        Console.WriteLine($"\nPlayer {playerNumber} has chosen a Robot");
                    }
                    else
                    {
                        Console.WriteLine($"\nPlayer {playerNumber} has chosen Robots");
                    }
                    
                    currentPlayerChar = "robot";
                    break;
                case "test":
                    if (playerNumber == 1)
                    {
                        Combatant Robot = new Robot("Robot", 5, playerNumber);
                        playerOne = Robot;
                        playerOneChar = "robot";
                        currentPlayerChar = "robot";
                    }
                    if (playerNumber == 2)
                    {
                        Combatant Dinosaur = new Dinosaur("Dinosaur", 5, playerNumber);
                        playerTwo = Dinosaur;
                        playerTwoChar = "dino";
                        currentPlayerChar = "dinosaur";
                    }
                        break;
                case "characters":
                case "character":
                case "teams":
                    Console.WriteLine("");
                    if(groupBattle == false)
                    {
                        foreach (Combatant name in Fighters)
                            {
                                name.displayType();
                            }
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine("Herd \nFleet\n");
                    }
                    goto restart;
                default:
                    Console.WriteLine("That is not a valid character, please pick again");
                    goto restart;

            }
                
        }

        public void assignName()
        {
            if(groupBattle == false)
            {
                Console.WriteLine("What would you like to name your character?");
                currentPlayer.name = Console.ReadLine();
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {

                    if (i == 0)
                    {
                        Console.WriteLine($"\nWhat would you like to name your first {currentPlayerChar}");
                        currentTeam[i].name = Console.ReadLine();
                    }
                    else if (i == 1)
                    {
                        Console.WriteLine($"\nWhat would you like to name your second {currentPlayerChar}");
                        currentTeam[i].name = Console.ReadLine();
                    }
                    else if (i == 2)
                    {
                        Console.WriteLine($"\nWhat would you like to name your third {currentPlayerChar}");
                        currentTeam[i].name = Console.ReadLine();
                    }
                }
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }


        public void battleSetup()
        {


            robotWeapons.Add(Railgun);
            robotWeapons.Add(Laser);
            robotWeapons.Add(Sword);
            robotWeapons.Add(Fists);
            dinoWeapons.Add(Tail);
            dinoWeapons.Add(Claws);
            dinoWeapons.Add(Bite);
            dinoWeapons.Add(Fire);
            Fighters.Add(displayDinosaur);
            Fighters.Add(displayRobot);


            this.battleType();

            if (groupBattle == false)
            {
                Console.WriteLine($"Choose player 1's combatant (Type CHARACTERS for a list of avalible characters)");
                playerNumber = 1;
                this.pickCharacter(playerNumber);
                currentPlayer = playerOne;
                this.chooseWeapons();
                this.assignName();
                Console.Clear();
                Console.WriteLine($"Choose player 2's combatant (Type CHARACTERS for a list of avalible characters)");
                playerNumber = 2;
                this.pickCharacter(playerNumber);
                currentPlayer = playerTwo;
                this.chooseWeapons();
                this.assignName();
                this.singleUnitFight();
                this.detectWinner();

            }
            else
            {
                Console.WriteLine("Choose player 1's team (Type TEAMS for a list of avalible characters)");
                playerNumber = 1;
                this.pickCharacter(playerNumber);
                currentTeam = playerOneTeam;
                this.assignName();
                this.chooseTeamWeapons();
                Console.Clear();
                Console.WriteLine("Choose player 2's team (Type TEAMS for a list of avalible characters)");
                playerNumber = 2;
                this.pickCharacter(playerNumber);                
                currentTeam = playerTwoTeam;
                this.assignName();
                this.chooseTeamWeapons();
                this.groupFight();
                this.detectWinner();



            }
            
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            
            
        }
        public void groupFight()
        {
            reset:
            if(currentTeam == playerOneTeam)
            {
                Console.Clear();
                Console.WriteLine("It's player 2's teams turn");
                currentTeam = playerTwoTeam;
                opponentTeam = playerOneTeam;
                foreach (Combatant name in currentTeam)
                {
                    if (name.health > 0)
                    {
                        Console.WriteLine($"{name.name} is still alive with {name.health} health");
                    }
                    else
                    {
                        Console.WriteLine($"{name.name} has died");
                    }
                }

                Console.WriteLine("\nPress any key to continue");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("It's player 1's teams turn");
                currentTeam = playerOneTeam;
                opponentTeam = playerTwoTeam;
                foreach (Combatant name in currentTeam) 
                {
                    if(name.health > 0)
                    {
                        Console.WriteLine($"{name.name} is still alive with {name.health} health");
                    }
                    else
                    {
                        Console.WriteLine($"{name.name} has died");
                    }
                }
                Console.WriteLine("\nPress any key to continue");
                Console.ReadKey();
            }
            Console.WriteLine("");
            while (currentTeam[0].health > 0 || currentTeam[1].health > 0 || currentTeam[2].health > 0)
            {
                for(int i = 0; i < 3; i++)
                {
                    bool firstTry = true;
                    currentPlayer = currentTeam[i];
                    retryAttack:
                    opponent = opponentTeam[rand.Next(3)];
                    if(opponent.health <= 0 && firstTry == true)
                    {
                        firstTry = false;
                        goto retryAttack;
                    }

                    if(currentPlayer.health >= 0)
                    {
                        this.attacks();
                    }
                    else
                    {
                        Console.WriteLine($"{currentPlayer.name} is dead and can not attack");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                    }
                    
                    
                }
                if (opponentTeam[0].health <= 0 && opponentTeam[1].health <= 0 && opponentTeam[2].health <= 0)
                {
                    break;
                }
                else
                {
                    goto reset;
                }
                    
            }

            
        }
        public void singleUnitFight()
        {
            while (playerOne.health > 0 && playerTwo.health > 0)
            {
                //player 1 attacks player 2
                Console.Clear();
                currentPlayer = playerOne;
                opponent = playerTwo;
                Console.WriteLine($"{currentPlayer.name} turn");
                this.pickAttack();
                this.attacks();


                //player 2 attacks player 1
                if (playerTwo.health > 0)
                {
                    Console.Clear();
                    currentPlayer = playerTwo;
                    opponent = playerOne;
                    Console.WriteLine($"{currentPlayer.name} turn");
                    this.pickAttack();
                    this.attacks();
                }

                
            }
        }
        public void detectWinner()
        {
            if (groupBattle == false)
            {
                if (playerOne.health <= 0)
                {
                    winner = playerTwo.name;
                    loser = playerOne.name;

                    if (playerTwoChar == "robot")
                    {
                        winnerChar = "robot";
                    }
                    else if (playerTwoChar == "dino")
                    {
                        winnerChar = "dino";
                    }
                }
                else if (playerTwo.health <= 0)
                {
                    winner = playerOne.name;
                    loser = playerTwo.name;

                    if (playerOneChar == "robot")
                    {
                        winnerChar = "robot";
                    }
                    else if (playerOneChar == "dino")
                    {
                        winnerChar = "dino";
                    }
                }
            }
            else
            {
                if (playerOneTeam[0].health >= 0 || playerOneTeam[1].health >= 0 || playerOneTeam[2].health >= 0)
                {
                    winner = "Player 1";
                    loser = "Player 2";
                    if (playerOneTeam[1].type == "Robot")
                    {
                        winnerChar = "robot";
                    }
                    else if (playerOneTeam[1].type == "Dinosaur")
                    {
                        winnerChar = "dino";
                    }
                }
                else if (playerTwoTeam[0].health >= 0 || playerTwoTeam[1].health >= 0 || playerTwoTeam[2].health >= 0)
                {
                    winner = "Player 2";
                    loser = "Player 1";
                    if (playerTwoTeam[1].type == "Robot")
                    {
                        winnerChar = "robot";
                    }
                    else if (playerTwoTeam[1].type == "Dinosaur")
                    {
                        winnerChar = "dino";
                    }
                }
            }

        }
        public void attacks()
        {
            int damage = currentPlayer.Damage();
            opponent.health -= damage;
            this.consoleWriteAttack(damage);

            if (opponent.health > 0)
            {
                Console.WriteLine($"{opponent.name} has {opponent.health} health remaining");
                Console.WriteLine("Press any key to continue\n");
                Console.ReadKey();

            }
            else if(opponent.health <= 0 && opponent.isDead == false)
            {
                Console.WriteLine($"{opponent.name} has died");
                opponent.isDead = true;
                Console.WriteLine("Press any key to continue\n");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Press any key to continue\n");
                Console.ReadKey();
            }
        }

        public void pickAttack()
        {
            Console.WriteLine($"What would you like to attack with (Please enter the attack number)");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Attack {i + 1}: {currentPlayer.weapon[i].type}");
            }

        retry:
            string chosenInput = Console.ReadLine();
            int chosenAttack = 0;
            bool isNum = int.TryParse(chosenInput, out int attack);
            if (isNum == true && 0 < attack && attack < 4)
            {
                chosenAttack = attack - 1;
            }
            else
            {
                Console.WriteLine("Not a valid attack, please try again");
                goto retry;
            }

            currentPlayer.activeWeapon = currentPlayer.weapon[chosenAttack];


        }

        public void consoleWriteAttack(int damage)
        {
            switch (currentPlayer.activeWeapon.type)
            {
                case "Tail":
                case "Sword":
                case "Fists":
                    if(opponent.isDead == false)
                    {
                        Console.WriteLine($"{currentPlayer.name} hit {opponent.name} with their {currentPlayer.activeWeapon.type} for {damage} damage");
                    }
                    else
                    {
                        Console.WriteLine($"{currentPlayer.name} hit {opponent.name}'s body");
                    }
                    
                    break;
                case "Fire breath":
                    if (opponent.isDead == false)
                    {
                        Console.WriteLine($"{currentPlayer.name} breathes fire at {opponent.name} for {damage} damage");
                    }
                    else
                    {
                        Console.WriteLine($"{currentPlayer.name} burns {opponent.name}'s body");
                    }
                    break;
                case "Bite":
                    if (opponent.isDead == false)
                    {
                        Console.WriteLine($"{currentPlayer.name} bites {opponent.name} for {damage} damage");
                    }
                    else
                    {
                        Console.WriteLine($"{currentPlayer.name} bites {opponent.name}'s body");
                    }
                    break;
                case "Claws":
                    
                    if (opponent.isDead == false)
                    {
                        Console.WriteLine($"{currentPlayer.name} claws {opponent.name} for {damage} damage");
                    }
                    else
                    {
                        Console.WriteLine($"{currentPlayer.name} claws {opponent.name}'s body");
                    }
                    break;
                case "Laser":
                case "Railgun":
                    if (opponent.isDead == false)
                    {
                        Console.WriteLine($"{currentPlayer.name} shoots {opponent.name} with a {currentPlayer.activeWeapon.type} for {damage} damage");
                    }
                    else
                    {
                        Console.WriteLine($"{currentPlayer.name} shoots {opponent.name}'s body");
                    }
                    
                    break;

            }
        }

        public void chooseTeamWeapons()
        {
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine($"What weapon would you like {currentTeam[i].name} to use?(Type WEAPONS for avalible weapons)");
                        break;
                    case 1:
                        Console.WriteLine($"\nWhat weapon would you like {currentTeam[i].name} to use?");
                        break;
                    case 2:
                        Console.WriteLine($"\nWhat weapon would you like {currentTeam[i].name} to use?");
                        break;
                }
            retry:
                string chosenWeapon = Console.ReadLine();

                if (currentTeam[i].type == "Robot")
                {

                    switch (chosenWeapon.ToLower())
                    {
                        case "railgun":
                            currentTeam[i].activeWeapon = Railgun;
                            Console.WriteLine($"{currentTeam[i].name} has equipped a Railgun");
                            break;
                        case "laser":
                            Console.WriteLine($"{currentTeam[i].name} has equipped a Laser");
                            currentTeam[i].activeWeapon = Laser;
                            break;
                        case "fist":
                        case "fists":
                            Console.WriteLine($"{currentTeam[i].name} has equipped Fists");
                            currentTeam[i].activeWeapon = Fists;
                            break;
                        case "sword":
                            Console.WriteLine($"{currentTeam[i].name} has equipped a Sword");
                            currentTeam[i].activeWeapon = Sword;
                            break;
                        case "weapons":
                            Console.WriteLine("");
                            foreach (Weapon name in robotWeapons)
                            {
                                name.displayName();
                            }
                            Console.WriteLine("");
                            goto retry;
                        //case "add":
                        //    this.addNewWeapon();
                        //    break;
                        default:
                            Console.WriteLine("This is not a valid weapon, please try again");
                            goto retry;
                    }
                }
                else if (currentTeam[i].type == "Dinosaur")
                {
                    switch (chosenWeapon.ToLower())
                    {
                        case "claw":
                        case "claws":
                            currentTeam[i].activeWeapon = Claws;
                            Console.WriteLine($"{currentTeam[i].name} has equipped Claws");
                            break;
                        case "bite":
                            Console.WriteLine($"{currentTeam[i].name} has equipped Bite");
                            currentTeam[i].activeWeapon = Bite;
                            break;
                        case "fire breath":
                        case "firebreath":
                        case "fire":
                        case "breath":
                            Console.WriteLine($"{currentTeam[i].name} has equipped Fire breath");
                            currentTeam[i].activeWeapon = Fire;
                            break;
                        case "tail":
                            Console.WriteLine($"{currentTeam[i].name} has equipped Tail");
                            currentTeam[i].activeWeapon = Tail;
                            break;
                        case "weapons":
                            Console.WriteLine("");
                            foreach (Weapon name in dinoWeapons)
                            {
                                name.displayName();
                            }
                            Console.WriteLine();
                            goto retry;
                        //case "add":
                        //    this.addNewWeapon();
                        //    break;
                        default:
                            Console.WriteLine("This is not a valid weapon, please try again");
                            goto retry;
                    }
                }

            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        public void chooseWeapons()
        {
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine($"Your {currentPlayerChar} may choose 3 weapons for its fight");
                        Console.WriteLine($"What weapons would you like your {currentPlayerChar} to use (Type WEAPONS for avalible weapons)");
                        break;
                    case 1:
                        Console.WriteLine("\nWhat is your second weapon");
                        break;
                    case 2:
                        Console.WriteLine("\nWhat is your third weapon");
                        break;
                }
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
                            Console.WriteLine("");
                            goto retry;
                        //case "add":
                        //    this.addNewWeapon();
                        //    break;
                        default:
                            Console.WriteLine("This is not a valid weapon, please try again");
                            goto retry;
                    }
                }
                else if (currentPlayerChar == "dinosaur")
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
                        case "firebreath":
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
                            Console.WriteLine();
                            goto retry;
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

        public void nameCharacter()
        {
            
        }

        public void runGame()
        {
            this.welcomeMessage();
            this.battleSetup();
            this.victoryMessage();
        }
         
        public void battleType()
        {
            Console.WriteLine("Would you like to do single or group battles?");
        retry:
            string battleType = Console.ReadLine();
            groupBattle = false;
            switch (battleType.ToLower())
            {
                case "single":
                    break;
                case "group":
                    groupBattle = true;
                    break;
                default:
                    Console.WriteLine("That was not an option");
                    goto retry;

            }
            Console.Clear();
        }
        string winningDino1 = "            __\r\n           /oo\\      \r\n          |    |     \r\n      ^^  (vvvv)   ^^\r\n      \\\\  /\\__/\\  // \r\n       \\\\/      \\//  \r\n        /        \\   \r\n  ^    |          |  \r\n | \\___/          \\  \r\n|     (            ) \r\n \\     \\----------/  \r\n   \\_____//    \\\\    \r\n        W       W ";
        string winningDino2 = "            __\r\n           /oo\\           \r\n          |    |          \r\n      ^^  (vvvv)   ^^     \r\n      \\\\  /\\__/\\  //      \r\n       \\\\/      \\//       \r\n        /        \\        \r\n       |          |    ^  \r\n       /          \\___/ | \r\n      (            )     |\r\n       \\----------/     / \r\n         //    \\\\_____/   \r\n        W       W         ";
        string deadDino = "            __\r\n           /xx\\      \r\n          |    |     \r\n          (vvvv)     \r\n          /\\__/\\     \r\n        //      \\\\   \r\n      ///        \\\\\\ \r\n  ^  //|          |\\\\\r\n | \\vv_/          \\ vv \r\n|     (            ) \r\n \\     \\----------/  \r\n   \\_____//    \\\\    \r\n        W       W  ";
        string winningRobot1 = "\n      \\_/\r\n     (* *)\r\n    __)#(__\r\n( )( )...( )( )\r\n \\\\|| |_| ||//\r\n  \\() | | ()/\r\n    _(___)_\r\n   [-]   [-]";
        string winningRobot2 = "()           ()\r\n||    \\_/    ||\r\n()   (* *)   ()\r\n \\\\ __)#(__ //\r\n   ( )...( )\r\n      |_|\r\n      | |\r\n    _(___)_\r\n   [-]   [-]";
        string deadRobot = "      \\_/\r\n     (x x)\r\n    __)#(__\r\n   ( )...( )\r\n   || |_| ||\r\n   () | | ()\r\n  //_(___)_\\\\\r\n ()[-]   [-]()";


        public void victoryMessage()
        {
            bool loop = true;

            while (loop)
            {
                if (winnerChar == "robot")
                {
                    Console.Clear();
                    Console.WriteLine($"{winner} has defeated {loser} and is therefor victorious");
                    if (groupBattle == false)
                    {
                        Console.WriteLine(winningRobot1);
                    }
                    else
                    {
                        foreach (Combatant winner in currentTeam)
                        {
                            if (winner.health > 0)
                            {
                                Console.WriteLine(winningRobot1);
                            }
                            else
                            {
                                Console.WriteLine(deadRobot);
                            }
                        }
                    }
                    Console.WriteLine("Please close console");
                    Thread.Sleep(milliseconds);
                    Console.Clear();
                    Console.WriteLine($"{winner} has defeated {loser} and is therefor victorious");
                    if (groupBattle == false)
                    {
                        Console.WriteLine(winningRobot2);
                    }
                    else
                    {
                        foreach (Combatant winner in currentTeam)
                        {
                            if (winner.health > 0)
                            {
                                Console.WriteLine(winningRobot2);
                            }
                            else
                            {
                                Console.WriteLine(deadRobot);
                            }
                        }
                    }
                    Console.WriteLine("Please close console");
                    Thread.Sleep(milliseconds);
                }
                else if (winnerChar == "dino")
                {

                    Console.Clear();
                    Console.WriteLine($"{winner} has defeated {loser} and is therefor victorious");
                    if (groupBattle == false)
                    {
                        Console.WriteLine(winningDino1);
                    }
                    else
                    {
                        foreach (Combatant winner in currentTeam)
                        {
                            if (winner.health > 0)
                            {
                                Console.WriteLine(winningDino1);
                            }
                            else
                            {
                                Console.WriteLine(deadDino);
                            }
                        }
                    }
                    Console.WriteLine("Please close console");
                    Thread.Sleep(milliseconds);
                    Console.Clear();
                    Console.WriteLine($"{winner} has defeated {loser} and is therefor victorious");
                    if (groupBattle == false)
                    {
                        Console.WriteLine(winningDino2);
                    }
                    else
                    {
                        foreach (Combatant winner in currentTeam)
                        {
                            if (winner.health > 0)
                            {
                                Console.WriteLine(winningDino2);
                            }
                            else
                            {
                                Console.WriteLine(deadDino);
                            }
                        }
                    }
                    Console.WriteLine("Please close console");
                    Thread.Sleep(milliseconds);
                }
            }
        }
    }
}
