using System.Collections.Generic;

namespace MonopolyDesignPattern
{
    public class Board
    {
        public SortedDictionary<int, Tile> ListOfTiles { get; set; }


        public Board()
        {
            InitTiles();
        }

        private void InitTiles()
        {
            ListOfTiles = new SortedDictionary<int, Tile>();
            int nbTile;
            for (nbTile = 0; nbTile < 40; nbTile++)
            {
                switch (nbTile)
                {
                    case 10:
                        ListOfTiles.Add(10, new Jail(nbTile));
                        break;
                    case 30:
                        ListOfTiles.Add(30, new GoToJail(nbTile));
                        break;
                    /* 
                     * add new special tiles here
                    */

                    default:
                        ListOfTiles.Add(nbTile, new Tile(nbTile));
                        break;
                }
            }
        }

        public Tile Move(Player player, int nbTiles)
        {
            int oldTile = -1;
            foreach (KeyValuePair<int, Tile> kv in ListOfTiles)
            {
                if (kv.Value.ListOfPlayer.Contains(player))
                {
                    kv.Value.RemovePlayer(player);
                    oldTile = kv.Key;
                    break;
                }
            }
            if (oldTile != -1)
            {
                // if newTile=40, then newTile=0
                int newTile = (oldTile + nbTiles) % 40;
                foreach (KeyValuePair<int, Tile> kv in ListOfTiles)
                {
                    if (kv.Key == newTile)
                    {
                        kv.Value.AddPlayer(player);
                        return kv.Value;
                    }
                }
                return null;
            }
            else
            {
                return null;
            }

        }

        public void GoToJail(Player player, Tile currentTile)
        {
            currentTile.RemovePlayer(player);
            Tile jail = ListOfTiles[10];
            jail.AddPlayer(player);
            player.IsInJail = true;
            player.NbTurnInJail = 0;
        }
    }
}