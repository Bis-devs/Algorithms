using System;
using System.IO;

public class Part1
{
    public void Run()
    {
        int X = 1;
        int stCiklov = 0;
        int vsota = 0;

        // Seznam ciklov na kateri se vsota poveča 
        int[] pomembniCikli = { 20, 60, 100, 140, 180, 220 };

        // Preberi vrstice iz datoteke
        foreach (var vrstica in File.ReadLines("./day10.txt"))
        {
            var deli = vrstica.Split(' ');

            if (deli[0] == "noop")
            {
                stCiklov += 1;

                if (Array.Exists(pomembniCikli, element => element == stCiklov))
                {
                    vsota += stCiklov * X;
                }
            }
            else if (deli[0] == "addx")
            {
                int V = int.Parse(deli[1]);

                stCiklov += 1;
                if (Array.Exists(pomembniCikli, element => element == stCiklov))
                {
                    vsota += stCiklov * X;
                }

                stCiklov += 1;
                if (Array.Exists(pomembniCikli, element => element == stCiklov))
                {
                    vsota += stCiklov * X;
                }

                X += V;
            }
        }

        Console.WriteLine("Končna vsota je " + vsota);
        Console.WriteLine("So izvedeni " + stCiklov + " ciklov.");
    }
}
