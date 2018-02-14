using System;

namespace TicTacToe.Core
{
    public class Randomizer
    {
        private static int seed;
        private static Random rnd;

        public static int Next(int max)
        {
            return rnd.Next(0, max);
        }

        public static int Next()
        {
            return rnd.Next(0, 3);
        }

        public static int NextEdge()
        {
            return rnd.Next(0, 2) * 2;
        }

        public static void Seed(int newSeed)
        {
            seed = newSeed;
            rnd = new Random(seed);
        }

        public static void RandomSeed()
        {
            seed = unchecked((int)DateTime.Now.Ticks);
            rnd = new Random(seed);
        }

        static Randomizer()
        {
            RandomSeed();
        }
    }
}
