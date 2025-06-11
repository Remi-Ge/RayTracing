using SixLabors.ImageSharp.PixelFormats;

public class Sphere
{
    public Position center;
    public double radius;
    public Rgba32 color;

    public Sphere(Position center, double radius, Rgba32 color)
    {
        this.center = center;
        this.radius = radius;
        this.color = color;
    }

    public bool intersect(Position origin, Position RayDirection, out Position intersection, out Position normalVector, out Position bounceVector)
    {
        Position oc = origin - this.center;

        double a = Position.dot(RayDirection, RayDirection);
        double b = 2.0 * Position.dot(oc, RayDirection);
        double c = Position.dot(oc, oc) - Math.Pow(this.radius, 2);

        double discriminant = b * b - 4 * a * c;

        intersection = Position.zero;
        normalVector = Position.zero;
        bounceVector = Position.zero;

        if (discriminant < 0)
        {
            return false;
        }

        double sqrt_discriminant = Math.Sqrt(discriminant);
        double t1 = (-b - sqrt_discriminant) / (2.0 * a);
        double t2 = (-b + sqrt_discriminant) / (2.0 * a);

        double t = double.MaxValue;
        if (t1 > 0 && t1 < t) t = t1;
        if (t2 > 0 && t2 < t) t = t2;

        if (t == double.MaxValue)
        {
            return false;
        }

        intersection = origin + t * RayDirection;
        normalVector = intersection - this.center;
        normalVector.normalize();
        bounceVector = RayDirection - 2 * Position.dot(RayDirection, normalVector) * normalVector;
        return true;
    }
}