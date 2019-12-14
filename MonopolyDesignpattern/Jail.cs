namespace MonopolyDesignPattern
{
    public class Jail : Tile
    {
        public Jail(int index) : base(index)
        {
            Name = "Jail";
        }

        public override void Action(Player player, GameMaster gm, Board board)
        {
            base.Action(player, gm, board);

            if (player.IsInJail)
            {
                View.PrintPlayerIsInJailSince(player);
                if (player.NbTurnInJail < 3 && player.NbTurnInJail != -1)
                {
                    int roll1 = gm.Dice1.Roll();
                    int roll2 = gm.Dice2.Roll();

                    View.PrintRollResults(roll1, roll2);

                    if (roll1 == roll2)
                    {
                        View.PrintPlayerOutJail(roll1==roll2);
                        player.NbTurnInJail = -1;
                        player.IsInJail = false;
                        Tile currentTile = board.Move(player, roll1 + roll2);
                        currentTile.Action(player, gm, board);
                    }
                    else
                    {
                        player.NbTurnInJail++;
                    }
                }
                else
                {
                    View.PrintPlayerOutJail(false);
                    int roll1 = gm.Dice1.Roll();
                    int roll2 = gm.Dice2.Roll();
                    View.PrintRollResults(roll1, roll2);

                    player.NbTurnInJail = -1;
                    player.IsInJail = false;
                    Tile currentTile = board.Move(player, roll1 + roll2);
                    currentTile.Action(player, gm, board);
                }
            }
        }
    }
}