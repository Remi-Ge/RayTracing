public class Sphere
{
    public Position center;
    public double radius;

    public Sphere(Position center, double radius)
    {
        this.center = center;
        this.radius = radius;
    }

    public bool intersect(Position origin, Position RayDirection, out Position intersection)
    {
        Position oc = origin - this.center;

        double a = Position.dot(RayDirection, RayDirection);
        double b = 2.0 * Position.dot(oc, RayDirection);
        double c = Position.dot(oc, oc) - Math.Pow(this.radius, 2);

        double discriminant = b * b - 4 * a * c;

        if (discriminant < 0)
        {
            intersection = Position.zero;
            return false;
        }

        double sqrt_discriminant = Math.Sqrt(discriminant);
        double t1 = (-b - sqrt_discriminant) / (2.0 * a);
        double t2 = (-b + sqrt_discriminant) / (2.0 * a);

        if (t1 <= 0 && t2 <= 0)
        {
            intersection = Position.zero;
            return false;
        }

        double t = t1 > t2 ? t1 : t2;
        intersection = origin + t * RayDirection;
        return true;
    }
}