using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("StockTickerTest")]
namespace StockTickerLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = Game.GetGame();
            Console.WriteLine("Welcome to StockTicker");
            Console.WriteLine("In this game, players can buy and sell stocks to increase their net worth");
            Console.WriteLine("Your net worth goes up when you collect dividends or when your stocks increase in value");
            Console.WriteLine("Dividends only pay out when the stock value is greater than or equal to 1000");
            Console.WriteLine();
            Console.WriteLine();
            string choice = "";
            do
            {
                if (!game.IsGameInProgress())
                {
                    Console.WriteLine("1- New Game");
                    Console.WriteLine("2- exit");
                }

                else if (game.IsNewGame())
                {
                    Console.WriteLine("1- Add player");
                    Console.WriteLine("2- Start Game");
                    Console.WriteLine("3- Get Player List");
                    Console.WriteLine("4- Quit Game");
                    Console.WriteLine("5- exit");
                }

                else if (game.IsGameInProgress())
                {
                    Console.WriteLine("1- End Game");
                    Console.WriteLine("2- Roll Dice (Market Movement)");
                    Console.WriteLine("3- See players");
                    Console.WriteLine("4- See Stocks");
                    Console.WriteLine("5- Quit game");
                    Console.WriteLine("6- exit");
                }

                choice = Console.Read().ToString();

            } while (choice != "q");
        }
    }
}
