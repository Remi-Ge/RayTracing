public class Camera {
    public Position position = new Position(0, 0, 0);
    public Orientation orientation = new Orientation(0, 0);
    private double fov = Math.PI / 2;

    public Camera(Position position, Orientation orientation)
    {
        this.position = position;
        this.orientation = orientation;
    }

    public Position getRayVector(Screen screen, int x, int y)
    {
        double verticalFov = this.fov * screen.height / screen.width;
        Orientation direction = new Orientation(
            this.orientation.teta + this.fov / screen.width
                * (x + 0.5d) - this.fov / 2d,
            this.orientation.fi - verticalFov / screen.height
                * (y + 0.5d) + verticalFov / 2d
        );
        return direction.getVector();
    }
}
