using Microsoft.Xna.Framework;

public partial class Playground
{
    public void Setup()
    {
        Screen("Minecraft", 800, 600);
    }

    public void Draw()
    {
        Backdrop(Color.LightSkyBlue);
        Circle(Color.DodgerBlue, 200, 200, 100);
        Square(Color.Red, 500, 100, 50);
        Sprite("mario.png", 400, 300, 200, 200);
    }
}