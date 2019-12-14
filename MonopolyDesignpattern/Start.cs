namespace MonopolyDesignPattern
{
    public class Start : Tile
    {
        public Start(int index) : base(index)
        {
            Name = "Start";
        }

        public override void Action(Player player, GameMaster gm, Board board)
        {
            base.Action(player, gm, board);
        }

    }
}
