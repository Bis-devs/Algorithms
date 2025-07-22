using System;
using System.Collections.Generic;

public class Part1
{
    private HashSet<(int x, int y, int z)> filled = new HashSet<(int x, int y, int z)>();

    public void PozeniSimulacijo(string[] podanePodatke)
    {
        foreach (var vrstica in podanePodatke)
        {
            var parts = vrstica.Split(',');
            int x = int.Parse(parts[0]);
            int y = int.Parse(parts[1]);
            int z = int.Parse(parts[2]);

            filled.Add((x, y, z));
        }

        int vsota = 0;

        foreach (var (x, y, z) in filled)
        {
            // Štejemo, koliko strani kocke je pokritih
            int coveredSides = 0;

            // Sosednje pozicije kocke v vse 3D smeri
            var trenutnaPozicija = new[] { x, y, z };

            // Preverimo vsako koordinato posebej (x, y, z)
            for (int os = 0; os < 3; os++)
            {
                // Ustvarimo smeri premika - za pozitivno in negativno smer
                var pozitivnoSmer = new int[] { 0, 0, 0 };
                pozitivnoSmer[os] = 1; // Premaknemo se v pozitivno smer po trenutni osi

                var negativnoSmer = new int[] { 0, 0, 0 };
                negativnoSmer[os] = -1; // Premaknemo se v negativno smer po trenutni osi

                // Preverimo, ali je kocka v sosednji poziciji napolnjena
                if (filled.Contains((trenutnaPozicija[0] + pozitivnoSmer[0],
                                     trenutnaPozicija[1] + pozitivnoSmer[1],
                                     trenutnaPozicija[2] + pozitivnoSmer[2])))
                {
                    coveredSides++; // Sosednja kocka v pozitivni smeri je napolnjena
                }

                if (filled.Contains((trenutnaPozicija[0] + negativnoSmer[0],
                                     trenutnaPozicija[1] + negativnoSmer[1],
                                     trenutnaPozicija[2] + negativnoSmer[2])))
                {
                    coveredSides++; // Sosednja kocka v negativni smeri je napolnjena
                }
            }

            // Skupno ima kocka 6 strani. Pokrite strani odštejemo in dodamo število izpostavljenih strani.
            vsota += 6 - coveredSides;
        }


        Console.WriteLine($"Rezultat del 1 je: {vsota}");
    }
}
