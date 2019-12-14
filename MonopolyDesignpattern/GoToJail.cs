namespace MonopolyDesignPattern
{
    public class GoToJail : Tile
    {
        public GoToJail(int index):base(index)
        {
            Name = "GTJail";
        }

        public override void Action(Player player, GameMaster gm, Board board)
        {
            base.Action(player, gm, board);
            board.GoToJail(player, this);
        }

    }
}