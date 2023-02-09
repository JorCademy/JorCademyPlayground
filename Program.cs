using Microsoft.Xna.Framework;
using JorCademyPlayground;
new Playground();

public partial class Playground
{
    // Playground initialization
    App app;
    public Playground() { app = new App(this); app.Run(); }
}