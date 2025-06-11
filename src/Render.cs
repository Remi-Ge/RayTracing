using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

public static class Render
{
    public static void RenderWorld(World world, Camera camera, Screen screen, string outputPath = "output.png")
    {
        using (Image<Rgba32> image = new Image<Rgba32>(screen.width, screen.height))
        {
            for (int y = 0; y < screen.height; y++)
            {
                for (int x = 0; x < screen.width; x++)
                {
                    image[x, y] = GetPixelColor(x, y, world, camera, screen);
                }
            }
            image.Save(outputPath);
        }
    }

    private static Rgba32 GetPixelColor(int x, int y, World world, Camera camera, Screen screen)
    {
        return new Rgba32(0, 0, 0);
    }
}