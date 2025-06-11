public static class Program
{
    public static void Main()
    {
        World world = new World();
        Camera camera = new Camera(new Position(0, 0, 0), new Orientation(0, 0));
        Screen screen = new Screen(1920, 1080);
        Render.RenderWorld(world, camera, screen);
    }
}
