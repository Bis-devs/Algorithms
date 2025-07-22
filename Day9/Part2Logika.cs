class Part2Logika : SkupnaLogikaBase
{
    private PositionBase[] vozli;
    private HashSet<(int, int)> repPozicije;

    public Part2Logika()
    {
        vozli = new PositionBase[10];
        for (int i = 0; i < 10; i++)
        {
            vozli[i] = new Part2Position(0, 0);
        }

        repPozicije = new HashSet<(int, int)>();
        repPozicije.Add((vozli[9].X, vozli[9].Y));
    }

    // Premik za Part2, kjer premikamo verigo vozlov
    public override void IzvediPremik(string navodilo, int korakov)
    {
        var (dx, dy) = smeri[navodilo];

        for (int i = 0; i < korakov; i++)
        {
            vozli[0].Premikaj(dx, dy);    // Premik glave (prvi vozel)
            for (int j = 1; j < vozli.Length; j++)
            {
                vozli[j].Sledi(vozli[j - 1]);    // Vsak vozel sledi prejšnjemu
            }
            repPozicije.Add((vozli[9].X, vozli[9].Y)); // Zabeleži položaj zadnjega vozla (repa)
        }
    }

    protected override int ZabeleziPozicije()
    {
        return repPozicije.Count;
    }
}
