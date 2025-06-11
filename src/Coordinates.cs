public struct Position
{
    public double x;
    public double y;
    public double z;

    public Position(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public static Position zero => new Position(0, 0, 0);

    public void normalize()
    {
        double norm = Math.Sqrt(Math.Pow(this.x, 2) + Math.Pow(this.y, 2) + Math.Pow(this.z, 2));
        this.x /= norm;
        this.y /= norm;
        this.z /= norm;
    }

    public static double dot(Position p1, Position p2)
    {
        return p1.x * p2.x + p1.y * p2.y + p1.z * p2.z;
    }

    public static Position operator +(Position a, Position b)
    {
        return new Position(a.x + b.x, a.y + b.y, a.z + b.z);
    }

    public static Position operator -(Position a, Position b)
    {
        return new Position(a.x - b.x, a.y - b.y, a.z - b.z);
    }

    public static Position operator -(Position a)
    {
        return new Position(-a.x, -a.y, -a.z);
    }

    public static Position operator *(double a, Position b)
    {
        return new Position(a * b.x, a * b.y, a * b.z);
    }

    public override string ToString()
    {
        return $"({this.x}, {this.y}, {this.z})";
    }
}

public struct Orientation
{
    public double teta;
    public double fi;

    public Orientation(double teta, double fi)
    {
        this.teta = teta;
        this.fi = fi;
    }

    public Position getVector()
    {
        return new Position(Math.Cos(this.fi) * Math.Cos(this.teta),
                            Math.Cos(this.fi) * Math.Sin(this.teta),
                            Math.Sin(this.fi));
    }

    public override string ToString()
    {
        return $"({this.teta}, ({this.fi}))";
    }
}
