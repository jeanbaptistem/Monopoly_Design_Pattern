using System;
using System.Collections.Generic;

namespace MonopolyDesignPattern
{
    public class GameMaster
    {
        private Queue<Player> ListOfAllPlayer;
        private Board Board;
        public Dice Dice1 { get; }
        public Dice Dice2 { get; }

        public GameMaster()
        {
            Board = new Board();
            Dice1 = new Dice();
            Dice2 = new Dice();
        }

        public void InitPlayers()
        {
            int nbPlayers = View.SelectNbPlayers();

            ListOfAllPlayer = new Queue<Player>();

            for (int indexPlayer = 1; indexPlayer < nbPlayers + 1; indexPlayer++)
            {
                ListOfAllPlayer.Enqueue(new Player(View.SelectPlayerName(indexPlayer)));
            }

            foreach (Player player in ListOfAllPlayer)
            {
                Board.ListOfTiles[0].AddPlayer(player);
            }
        }

        public void Play(int nbTurn)
        {
            int currentTurn = 1;
            while (currentTurn < nbTurn + 1)
            {
                View.PrintCurrentTurn(currentTurn, nbTurn);
                Player currentPlayer = ListOfAllPlayer.Dequeue();
                View.PrintCurrentPlayer(currentPlayer);

                if (!currentPlayer.IsInJail)
                {
                    int countDoubleRoll = 0;
                    Tile currentTile = null;
                    while (countDoubleRoll < 3)
                    {
                        int roll1 = Dice1.Roll();
                        int roll2 = Dice2.Roll();
                        View.PrintRollResults(roll1, roll2);
                        currentTile = Board.Move(currentPlayer, roll1 + roll2);
                        currentTile.Action(currentPlayer, this, Board);
                        if (roll1 != roll2 || currentTile == Board.ListOfTiles[30])
                        {
                            break;
                        }
                        else
                        {
                            countDoubleRoll++;
                            View.PrintDoubleRoll(countDoubleRoll);
                        }
                    }
                    if (countDoubleRoll == 3)
                    {
                        View.PrintTripleDoubleRoll();
                        Board.GoToJail(currentPlayer, currentTile);
                        currentTile = Board.ListOfTiles[10];
                        currentTile.Action(currentPlayer, this, Board);
                    }
                }
                else
                {
                    Tile jail = Board.ListOfTiles[10];
                    jail.Action(currentPlayer, this, Board);
                }

                View.PrintNextTurn();
                currentTurn++;
                ListOfAllPlayer.Enqueue(currentPlayer);
                Console.ReadKey();
            }

            View.EndOfTheGame();
        }

    }
}