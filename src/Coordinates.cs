public struct Position {
    public double x;
    public double y;
    public double z;

    public Position(double x, double y, double z) {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public void normalize() {
        double norm = Math.Sqrt(Math.Pow(this.x, 2) + Math.Pow(this.y, 2) + Math.Pow(this.z, 2));
        this.x /= norm;
        this.y /= norm;
        this.z /= norm;
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
}
