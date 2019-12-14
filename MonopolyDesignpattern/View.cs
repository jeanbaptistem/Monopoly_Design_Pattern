using System;
using System.Collections.Generic;

namespace MonopolyDesignPattern
{
    static class View
    {
        public static int SelectNbPlayers()
        {
            int nbPlayers = 0;
            while (nbPlayers == 0)
            {
                Console.Write("Number of players: ");
                string strNbPlayer = Console.ReadLine();
                try
                {
                    nbPlayers = int.Parse(strNbPlayer);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Please, select a valid number: {0}", e.Message);
                }
            }
            return nbPlayers;
        }

        internal static void PrintPlayerIsInJailSince(Player player)
        {
            Console.WriteLine("{0} is in jail since {1} turns", player.Name, player.NbTurnInJail == -1 ? 0 : player.NbTurnInJail);
        }

        internal static void PrintPlayerOutJail(bool doubleRoll)
        {
            if (doubleRoll)
            {
                Console.WriteLine("Double roll, go out");
            }
            else
            {
                Console.WriteLine("3 turns in jail, go out");
            }
        }

        public static string SelectPlayerName(int indexPlayer)
        {
            Console.Write("Name of player {0}: ", indexPlayer);
            string name = Console.ReadLine();
            return name;
        }

        internal static void PrintCurrentPlayer(Player currentPlayer)
        {
            Console.WriteLine("Current player is {0}", currentPlayer.Name);
        }

        internal static void PrintRollResults(int roll1, int roll2)
        {
            Console.WriteLine("This is your rolls : ");
            Console.WriteLine("First roll {0}, second roll {1}", roll1, roll2);
        }

        internal static void PrintCurrentTile(Tile tile)
        {
            Console.WriteLine("Your are on the tile: \"{0}\" ({1})", tile.Name, tile.Index);
        }

        internal static void PrintNextTurn()
        {
            Console.WriteLine("Next turn, please press any key");
        }

        internal static void EndOfTheGame()
        {
            Console.WriteLine("This is the end of the game");
        }

        internal static void PrintCurrentTurn(int nbTurn, int maxTurn)
        {
            Console.Clear();
            Console.WriteLine("Turn n°{0}/{1}", nbTurn, maxTurn);
        }

        static void printGame(SortedDictionary<int, Tile> ListOfTiles)
        {
            List<Tile> tiles_0_10 = new List<Tile>();
            List<Tile> tiles_11_20_31_40 = new List<Tile>();
            List<Tile> tiles_21_30 = new List<Tile>();

            foreach (KeyValuePair<int, Tile> tile in ListOfTiles)
            {
                if (tile.Key >= 0 && tile.Key < 11)
                {
                    tiles_0_10.Add(tile.Value);
                }
                else if (tile.Key > 10 && tile.Key < 21 || tile.Key > 30 && tile.Key < 41)
                {
                    tiles_11_20_31_40.Add(tile.Value);
                }
                else if (tile.Key > 20 && tile.Key < 31)
                {
                    tiles_21_30.Add(tile.Value);
                }
                else
                {
                    tiles_11_20_31_40.Add(tile.Value);
                }
            }

            int count = tiles_11_20_31_40.Count;

            foreach (Tile tile in tiles_0_10)
            {
                Console.Write("|" + tile.Name + "| ");
            }

            for (int i = 0; i < count; i++)
            {
                Console.Write("\n|" + tiles_11_20_31_40[count - i].Name + "|          |" + tiles_11_20_31_40[i].Name + "|");
            }

            tiles_21_30.Reverse();
            foreach (Tile tile in tiles_21_30)
            {
                Console.Write("|" + tile.Name + "| ");
            }

        }

        internal static void PrintTripleDoubleRoll()
        {
            Console.WriteLine("Triple double roll in a row, you go to jail");
        }

        internal static void PrintDoubleRoll(int countDoubleRoll)
        {
            Console.WriteLine("Double roll n°{0}, roll again", countDoubleRoll);
        }
    }
}
