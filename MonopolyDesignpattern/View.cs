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

        internal static void PrintJailVisitOnly()
        {
            Console.WriteLine("Jail : visit only");
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

        internal static void PrintGame(SortedDictionary<int, Tile> ListOfTiles)
        {
            int i;
            for(i=0; i<=9; i++)
            {
                Tile tile = ListOfTiles[i];
                Console.Write("|{0, 6}({1, 2})|", tile.Name, tile.Index);
            }
            for(i=10; i<=19; i++)
            {
                Tile tileR = ListOfTiles[i];
                Tile tileL = ListOfTiles[ListOfTiles.Count - i + 9];
                Console.Write("\n|{0, 6}({1, 2})|", tileL.Name, tileL.Index);
                Console.Write("".PadRight(96));
                Console.Write("|{0, 6}({1, 2})|", tileR.Name, tileR.Index);
            }
            for (i=29; i>=20; i--)
            {
                Tile tile = ListOfTiles[i];
                Console.Write("|{0, 6}({1, 2})|", tile.Name, tile.Index);
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
