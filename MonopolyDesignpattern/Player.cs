namespace MonopolyDesignPattern
{
    public class Player
    {
        public string Name { get; }

        public bool IsInJail { get; set; }

        public int NbTurnInJail { get; set; }

        public Player(string name)
        {
            Name = name;
            IsInJail = false;
            NbTurnInJail = -1;
        }
    }
}