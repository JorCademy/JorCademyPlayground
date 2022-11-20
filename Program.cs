using Microsoft.Xna.Framework;
using JorCademyPlayground;
new Playground();

public class Playground
{
    App app;
    public Playground() { app = new App(this); app.Run(); }
    
    public void Setup()
    {
        app.SetScreenSize(1000, 1000);
    }

    public void Update(GameTime deltaTime)
    {
        
    }
}