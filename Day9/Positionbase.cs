abstract class PositionBase
{
    public int X { get; set; }
    public int Y { get; set; }

    public PositionBase(int x, int y)
    {
        X = x;
        Y = y;
    }

    // Premik na podlagi delta vrednosti
    public void Premikaj(int dx, int dy)
    {
        X += dx;
        Y += dy;
    }

    // Abstraktna metoda za sledenje (specifična za Part1 in Part2)
    public abstract void Sledi(PositionBase other);
}
