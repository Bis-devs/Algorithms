class Part2Position : PositionBase
{
    public Part2Position(int x, int y) : base(x, y) { }

    public bool Sosedni(PositionBase glava, PositionBase rep)
    {
     
        return Math.Abs(glava.X - rep.X) <= 1 && Math.Abs(glava.Y - rep.Y) <= 1;
    }

    // Sledenje v Part2 - sledi glavi v verigi vozlov
    public override void Sledi(PositionBase glava)
    {
        if (!Sosedni(glava, this))
        {
            int deltaX = glava.X == X ? 0 : (glava.X - X) / Math.Abs(glava.X - X);
            int deltaY = glava.Y == Y ? 0 : (glava.Y - Y) / Math.Abs(glava.Y - Y);

            X += deltaX;
            Y += deltaY;
        }
    }
}
