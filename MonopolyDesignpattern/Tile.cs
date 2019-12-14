using System.Collections.Generic;

namespace MonopolyDesignPattern
{
    public class Tile
    {
        public List<Player> ListOfPlayer { get; }
        public string Name;
        public int Index { get; set; }

        public Tile(int index)
        {
            ListOfPlayer = new List<Player>();
            Name = "Tile";
            Index = index;
        }

        public void AddPlayer(Player player)
        {
            ListOfPlayer.Add(player);
        }

        public bool RemovePlayer(Player player)
        {
            return ListOfPlayer.Remove(player);
        }

        public virtual void Action(Player player, GameMaster gm, Board board)
        {
            View.PrintCurrentTile(this);
        }
    }
}