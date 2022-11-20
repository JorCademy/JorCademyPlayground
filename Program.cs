using Microsoft.Xna.Framework;
using JorCademyPlayground;
new Playground();

public class Playground
{
    App app;
    public Playground() { app = new App(this); app.Run(); }
    
    public void Setup()
    {
        // Set screen size
        app.SetScreenSize(1000, 1000);
        
        // Add dummy objects to be drawn
        app.Ellipse(300, 100, 200, Color.DodgerBlue);
        app.Ellipse(100, 100, 100, Color.DodgerBlue);
    }

    public void Update(GameTime deltaTime)
    {

    }
}