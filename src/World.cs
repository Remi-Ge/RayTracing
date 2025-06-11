public class World
{
    public Position globalIllumination;
    public List<Sphere> spheres = new List<Sphere>();

    public World()
    {
        this.globalIllumination = new Position(1, 0, 0);
        this.spheres = new List<Sphere>();
    }

    public World(Position globalIllumination, List<Sphere> spheres)
    {
        globalIllumination.normalize();
        this.globalIllumination = globalIllumination;
        this.spheres = spheres;
    }
}