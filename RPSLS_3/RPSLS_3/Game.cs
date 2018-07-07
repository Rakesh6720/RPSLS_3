using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS_3
{
    class Game
    {
        Player player1;
        Player player2;
        Robot cpu;
        int numPlayers;
        List<string> Arsenal = new List<string>() { "0. Rock", "1. Paper", "2. Scissors", "3. Spock", "4. Lizard" };
        int trialsWin = 2;

        public void Run()
        {
            GeneratePlayers();
            PlayRound();
        }

        public string GetUserInput(string phrase)
        {
            Console.Write(phrase);
            string userInput = Console.ReadLine();
            return userInput;
        }

        public void GeneratePlayers()
        {
            string numString = GetUserInput("Enter the number of players: ");
            numPlayers = Int32.Parse(numString);
            if (numPlayers < 2)
            {
                player1 = new Player();
                NamePlayer(player1);
                cpu = new Robot();
                cpu.Score = 0;
                cpu.Name = "Robot";
            }
            else
            {
                player1 = new Player();
                NamePlayer(player1);
                player2 = new Player();
                NamePlayer(player2);
                
            }
        }
        public void NamePlayer(Player player)
        {
            
            player.Name = GetUserInput("Enter player name: ");
            player.Score = 0;
            
        }

        public void HumanPlayerPlays(Player player)
        {
            foreach(string weapon in Arsenal)
            {
                Console.WriteLine(weapon);
            }
            string playerWeaponString = GetUserInput(player.Name + ", choose your weapon: ");
            

            try
            {
                player.Weapon = Int32.Parse(playerWeaponString);
                if (player.Weapon >= 4)
                {
                    Console.WriteLine("Please enter a valid number 1 - 4");
                    HumanPlayerPlays(player);
                }
            }
            catch
            {
                Console.WriteLine("Please enter a valid number.");
                HumanPlayerPlays(player);
            }
        }



        public void PlayRound()
        {
            HumanPlayerPlays(player1);

            if (numPlayers >= 2)
            {
                HumanPlayerPlays(player2);
                EvaluateFight(player1, player2);
            }
            else
            {                
                cpu.RoboPlayerPlays();
                Console.WriteLine("Robot chose: " + Arsenal[cpu.Weapon]);
                EvaluateFight(player1, cpu);
            }
           
        }

        public void EvaluateFight(Player player1, Player player2)
        {
            
            int d = (5 + player1.Weapon - player2.Weapon) % 5;

            if (d == 1 || d == 3)
            {
                player1.Score++;
            }
            if (d == 2 || d == 4)
            {
                player2.Score++;
            }
            if (d==0)
            {

            }

            EvaluateScore(player1, player2);
                
        }

        public void EvaluateScore(Player player1, Player player2)
        {
            if (player1.Score == trialsWin || player2.Score == trialsWin)
            {
                Console.WriteLine("Game Over!");
                if (player1.Score > player2.Score)
                {
                    Console.WriteLine(player1.Name + " wins the match!");
                    string playAgain = GetUserInput("Would you like to play again? /n 1) YES /n 2) NO");
                    int playAgainInt = Int32.Parse(playAgain);
                    if (playAgainInt == 1)
                    {
                        player1.Score = 0;
                        player2.Score = 0;
                        PlayRound();
                    }
                }
                else
                {
                    Console.WriteLine(player2.Name + " wins the match!");
                    string playAgain = GetUserInput("Would you like to play again? /n 1) YES /n 2) NO");
                    int playAgainInt = Int32.Parse(playAgain);
                    if (playAgainInt == 1)
                    {
                        player1.Score = 0;
                        player2.Score = 0;
                        PlayRound();
                    }
                }
            }
            else
            {
                if (player1.Score > player2.Score)
                {
                    Console.WriteLine(player1.Name + " wins the round!");
                }
                else if (player1.Score == player2.Score)
                {
                    Console.WriteLine("It's a tie!");
                }
                else
                {
                    Console.WriteLine(player2.Name + " wins the round!");
                }
                Console.WriteLine("Next Round!");
                PlayRound();
            }
        }
    }
}
