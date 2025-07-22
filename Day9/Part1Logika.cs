class Part1Logika : SkupnaLogikaBase
{
    private PositionBase glava;
    private PositionBase rep;
    private HashSet<(int, int)> repPozicije;

    public Part1Logika()
    {
        glava = new Part1Position(0, 0);
        rep = new Part1Position(0, 0);
        repPozicije = new HashSet<(int, int)>();
        repPozicije.Add((rep.X, rep.Y));
    }

    // Premik za Part1, kjer premikamo tako glavo kot rep
    public override void IzvediPremik(string navodilo, int korakov)
    {
        var (dx, dy) = smeri[navodilo];

        for (int i = 0; i < korakov; i++)
        {
            glava.Premikaj(dx, dy);    // Premik glave
            rep.Sledi(glava);          // Rep sledi glavi
            repPozicije.Add((rep.X, rep.Y)); // Zabeleži položaj repa
        }
    }

    protected override int ZabeleziPozicije()
    {
        return repPozicije.Count;
    }
}
