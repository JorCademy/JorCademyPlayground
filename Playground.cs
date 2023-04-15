using Microsoft.Xna.Framework;

public partial class Playground
{
    public void Setup()
    {
        Screen("JorCademy Playground", 800, 600);
    }

    public void Draw()
    {
        Circle(Color.Red, 400, 300, 20, 20);
        Circle(Color.Yellow, 500, 500, 10, 20);
    }
}