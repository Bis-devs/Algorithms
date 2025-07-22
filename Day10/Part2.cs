using System;
using System.IO;
using System.Text;

public class Part2
{
    public void Run()
    {
        int X = 1;
        int stCiklov = 0;

        // Ustvari polje Y za shranjevanje vrednosti
        int[] Y = new int[241]; //za 240 ciklov 

        // Preberi vrstice in obdelaj vsako
        foreach (var vrstica in File.ReadAllLines("./day10.txt"))
        {
            var deli = vrstica.Split(' ');

            // "noop" ukaz - povečamo števec ciklov in shranimo trenutno vrednost X
            if (deli[0] == "noop")
            {
                stCiklov++;
                Y[stCiklov] = X;
            }
            // "addx" ukaz - dvakrat povečamo števec ciklov, dodamo vrednost X in V
            else if (deli[0] == "addx")
            {
                int V = int.Parse(deli[1]);

                stCiklov++;
                Y[stCiklov] = X;  // Shrani trenutno vrednost X

                stCiklov++;
                X += V;           // Povečaj X z V
                Y[stCiklov] = X;  // Shrani novo vrednost X
            }
        }

        // Kako se spreminjajo vrednosti X
        for (int i = 0; i <= 240; i++)
        {
            Console.WriteLine(Y[i]);
        }


        StringBuilder sb = new StringBuilder();

        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 40; col++)
            {
                int stevec = row * 40 + col + 1;

                // Uporabi "#" za lit pixel ali " " za dark pixel
                sb.Append(Math.Abs(Y[stevec - 1] - col) <= 1 ? "#" : " ");
            }
            sb.AppendLine(); // Dodaj novo vrstico po vsakih 40 znakih
        }

        // Izpiši rezultat
        Console.WriteLine(sb.ToString());
    }
}
