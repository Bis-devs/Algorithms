using System.IO;

public class Day10Factory
{
    public static object GetPart(string choice)
    {
        if (choice == "1")
        {
            return new Part1();
        }
        else if (choice == "2")
        {
            return new Part2();
        }
        else
        {
            throw new ArgumentException("Neveljavna izbira.");
        }
    }
}
