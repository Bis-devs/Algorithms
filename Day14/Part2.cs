using System;
using System.Collections.Generic;
using System.Linq;

public class Part2
{
    private (int x, int y) virPeska = (500, 0); 
    private HashSet<(int x, int y)> filled = new HashSet<(int x, int y)>();  //hrani vse koordinate, ki so bile zapolnjene
    private int maxY;

    public void PozeniSimulacijo(string[] podanePodatke)
    {
        preberiVrstice(podanePodatke);
        int vsota = 0;

        while (true)
        {
            var (x, y) = SimulirajPesek();
            filled.Add((x, y));
            vsota++;

            // če pesek pride do vrha, prekini loop
            if ((x, y) == virPeska)
            {
                break;
            }
        }

        Console.WriteLine($"Part 2 Result: {vsota}");
    }

    private void preberiVrstice(string[] podanePodatke)
    {
        foreach (var vrstica in podanePodatke)
        {
            var koordinate = new List<(int x, int y)>();
            foreach (var prebraneKoordinate in vrstica.Split(" -> "))
            {
                var deli = prebraneKoordinate.Split(',');
                int x = int.Parse(deli[0]);
                int y = int.Parse(deli[1]);
                koordinate.Add((x, y));
            }

            for (int i = 1; i < koordinate.Count; i++)
            {
                var (cx, cy) = koordinate[i]; //trenutne koordinate
                var (px, py) = koordinate[i - 1]; //presnje koordinate

                if (cy != py)
                {
                    for (int y = Math.Min(cy, py); y <= Math.Max(cy, py); y++)
                    {
                        filled.Add((cx, y));
                    }
                }

                if (cx != px)
                {
                    for (int x = Math.Min(cx, px); x <= Math.Max(cx, px); x++)
                    {
                        filled.Add((x, cy));
                    }
                }
            }
        }

        maxY = filled.Max(koordinata => koordinata.y);
    }

    private (int x, int y) SimulirajPesek()
    {
        int x = virPeska.x;
        int y = virPeska.y;

        if (filled.Contains((x, y)))
        {
            return (x, y);
        }

        while (y <= maxY)
        {
            if (!filled.Contains((x, y + 1)))
            {
                y += 1;
                continue;
            }

            if (!filled.Contains((x - 1, y + 1)))
            {
                x -= 1;
                y += 1;
                continue;
            }

            if (!filled.Contains((x + 1, y + 1)))
            {
                x += 1;
                y += 1;
                continue;
            }

            break;
        }

        return (x, y);
    }
}
