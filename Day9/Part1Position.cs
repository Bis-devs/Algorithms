class Part1Position : PositionBase
{
    public Part1Position(int x, int y) : base(x, y) { }

    public bool Sosedni(PositionBase glava)
    {

        return Math.Abs(X - glava.X) <= 1 && Math.Abs(Y - glava.Y) <= 1;
    }

    // Sledenje v Part1 - sledi samo enemu vozliscu
    public override void Sledi(PositionBase glava)
    {
        if (!Sosedni(glava))
        {
            int deltaX = glava.X == X ? 0 : (glava.X - X) / Math.Abs(glava.X - X);
            int deltaY = glava.Y == Y ? 0 : (glava.Y - Y) / Math.Abs(glava.Y - Y);

            X += deltaX;
            Y += deltaY;
        }
    }
}
