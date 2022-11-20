using Microsoft.Xna.Framework;
using JorCademyPlayground;

new Playground();

public class Playground
{
    // Playground initialization
    App app;
    public Playground() { app = new App(this); app.Run(); }
    
    // Values used for testing movement
    Vector2 pos;
    float speed;

    public void Setup()
    {
        // Set screen size
        app.SetScreenSize(1000, 1000);
        
        // Object properties
        this.speed = 0.5f;
        this.pos = new Vector2(100, 100);
    }

    public void Draw(GameTime deltaTime)
    {
        // Clear screen with backdrop color
        app.ClearScreen(Color.White);

        // Add dummy objects to be drawn
        app.Circle(300, 100, 200, Color.DodgerBlue);
        app.Circle(this.pos.X, this.pos.Y, 100, Color.LightGreen);
        app.Square(400, 200, 350, Color.Pink);

        // Make object move
        pos.X += speed;
        pos.Y += speed;
    }
}