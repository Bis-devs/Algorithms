using System;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Izberite del 1 ali 2 za dan 18: ");
        string izbira = Console.ReadLine();

        string[] podanePodatke = File.ReadAllLines("./day18.txt");

        if (izbira == "1")
        {
            Part1 part1 = new Part1();
            part1.PozeniSimulacijo(podanePodatke);
        }
        else if (izbira == "2")
        {
            Part2 part2 = new Part2();
            part2.PozeniSimulacijo(podanePodatke);
        }
        else
        {
            Console.WriteLine("Neveljavna izbira.");
        }
    }
}
