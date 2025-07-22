using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Izberite del 1 ali 2 za dan 10: ");
        string izbira = Console.ReadLine();

        try
        {
            var part = Day10Factory.GetPart(izbira);

            if (part is Part1 p1)
            {
                p1.Run();
            }
            else if (part is Part2 p2)
            {
                p2.Run();
            }
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
