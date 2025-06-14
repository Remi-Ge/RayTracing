using SixLabors.ImageSharp.PixelFormats;

public static class Program
{
    public static void Main()
    {
        Camera camera = new Camera(new Position(0, 0, 0), new Orientation(0, 0));
        Screen screen = new Screen(1920, 1080);
        Sphere sphere1 = new Sphere(new Position(10, 0, 0), 3, new Rgba32(255, 0, 0));
        Sphere sphere2 = new Sphere(new Position(4, 3, 0), 2, new Rgba32(0, 255, 0));
        World world = new World(new Position(1, 4, 2), new List<Sphere>() { sphere1, sphere2 });
        Render.RenderWorld(world, camera, screen);
    }
}
