using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PartOne
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // view the map
            // send movement commands
            // view hero stats
            // view hero position

            var gameEngine = new GameEngine();
            while (true)
            {
                // to get the current map layout as a formatted string use this
                var currentMapString = gameEngine.Map.ToString();

                // to draw the map into the console use this
                gameEngine.Map.Draw();

                // 
                MovementEnum nextRandomMovement = GetNextRandomMovement();

                // Use this to give the player commands for movement from the form
                gameEngine.MovePlayer(nextRandomMovement);

                // Use this to get the hero / player's stats!
                var heroStats = gameEngine.Map.Hero.ToString();
                Console.WriteLine(heroStats);

                var sb = new StringBuilder();
                // Use this to get enemy stats or otherwise access enemies
                foreach (Enemy mapEnemy in gameEngine.Map.Enemies)
                {
                    sb.AppendLine(mapEnemy.ToString());
                }

                Console.WriteLine(sb.ToString());

                Thread.Sleep(1000);
                Console.Clear();
            }
        }

        static MovementEnum GetNextRandomMovement()
        {
            var rand = new Random().Next(1, 5);
            return (MovementEnum)rand;
        }
    }
}