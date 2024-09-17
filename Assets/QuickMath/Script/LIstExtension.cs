using System;
using System.Collections;
using System.Collections.Generic;

public static class LIstExtension
{
    private static readonly Random rng = new Random(); // Buat instance static Random

    // Metode ekstensi untuk mengacak list
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
