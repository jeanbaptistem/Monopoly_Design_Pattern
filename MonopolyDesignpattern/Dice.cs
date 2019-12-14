using System;

namespace MonopolyDesignPattern
{
    public class Dice
    {
        private Random Rng;

        public Dice()
        {
            int seed = DateTime.Now.Millisecond;
            Rng = new Random(seed);
        }

        public int Roll()
        {
            return Rng.Next(1, 7);
        }
    }
}