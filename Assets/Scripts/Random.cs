using System;
public static class RNG
{
    public static Random rng { get; private set; } = new Random();
    static void  setSeed(int Seed)
    {
        rng = new Random(Seed);
    }
}