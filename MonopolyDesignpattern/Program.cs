namespace MonopolyDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            GameMaster game = new GameMaster();
            game.InitPlayers();
            game.Play(20);
        }
    }
}
