using System;
using System.Collections.Generic;
using System.Linq;

public class Part1
{
    private (int x, int y) virPeska = (500, 0);
    private HashSet<(int x, int y)> filled = new HashSet<(int x, int y)>();
    private int maxY;

    public void PozeniSimulacijo(string[] podanePodatke)
    {
        preberiVrstice(podanePodatke);
        int vsota = 0;

        while (true)
        {
            bool res = SimulirajPesek();
            if (!res)
            {
                break;
            }
            vsota++;
        }

        Console.WriteLine($"Rezultat del 1 je: {vsota}");
    }

    private void preberiVrstice(string[] podanePodatke)
    {
        foreach (var vrstica in podanePodatke)
        {
            var koordinate = new List<(int x, int y)>();
            foreach (var posameznaKoordinata in vrstica.Split(" -> "))
            {
                var parts = posameznaKoordinata.Split(',');
                int x = int.Parse(parts[0]);
                int y = int.Parse(parts[1]);
                koordinate.Add((x, y));
            }

            for (int i = 1; i < koordinate.Count; i++)
            {
                var (cx, cy) = koordinate[i];
                var (px, py) = koordinate[i - 1];

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

        maxY = filled.Max(koordinate => koordinate.y);
    }

    private bool SimulirajPesek()
    {
        int x = virPeska.x;
        int y = virPeska.y;

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

            filled.Add((x, y));
            return true;
        }

        return false;
    }
}
