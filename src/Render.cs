using System.Runtime.Serialization.Formatters;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.ColorSpaces;
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
        return Render.ComputeRayColor(
            camera.position,
            camera.getRayVector(screen, x, y),
            world
        );
    }

    private static Rgba32 ComputeRayColor(Position rayOrigin, Position rayDirection, World world)
    {
        // Calculate Intersection with closest sphere
        Sphere? closestSphere = null;
        double closestDistance = double.MaxValue;
        Position closestIntersection = Position.zero;
        Position closestNormalVector = Position.zero;
        Position closestBounceVector = Position.zero;
        foreach (Sphere sphere in world.spheres)
        {
            bool intersect = sphere.intersect(rayOrigin, rayDirection, out Position intersection, out Position normalVector, out Position bounceVector);
            double distance = Position.distance(rayOrigin, intersection);
            if (intersect && distance != 0 && distance < closestDistance)
            {
                closestSphere = sphere;
                closestDistance = distance;
                closestIntersection = intersection;
                closestNormalVector = normalVector;
                closestBounceVector = bounceVector;
            }
        }

        // no intersection
        if (closestSphere == null)
        {
            return new Rgba32(0, 0, 0);
        }
        
        // Calculate color
        foreach (Sphere sphere in world.spheres)
        {
            bool intersect = sphere.intersect(rayOrigin, -world.globalIllumination, out Position intersection, out Position normalVector, out Position bounceVector);
            double distance = Position.distance(rayOrigin, intersection);
            if (intersect && distance != 0)
            {
                return new Rgba32((byte)(0.2 * closestSphere.color.R),
                    (byte)(0.2 * closestSphere.color.G),
                    (byte)(0.2 * closestSphere.color.B));
            }
        }
        double lightImpact = Position.dot(world.globalIllumination, -closestNormalVector);
        lightImpact = Math.Clamp(lightImpact, 0, 1);
        // when the color is dark, we want to add 0.2 of the original color
        byte r = (byte)(closestSphere.color.R * lightImpact * 0.8 + 0.2 * closestSphere.color.R);
        byte g = (byte)(closestSphere.color.G * lightImpact * 0.8 + 0.2 * closestSphere.color.G);
        byte b = (byte)(closestSphere.color.B * lightImpact * 0.8 + 0.2 * closestSphere.color.B);
        return new Rgba32(r, g, b);
    }
}