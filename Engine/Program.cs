using Microsoft.Xna.Framework;
using JorCademyPlayground;

public class Program
{
    static void Main()
    {
        new Playground();
    }
}

public partial class Playground
{
    // Playground initialization
    App app;

    // Screen properties
    private int _screenWidth;
    private int _screenHeight;
    private string _title;
    private Color _backColor;

    public Playground() 
    { 
        app = new App(this);

        this._title = "JorCademy Playground"; 
        this._backColor = Color.White;

        // Update all properties 
        // this.Setup();

        // Process fetched changes
        app.SetScreenTitle(_title); // NOTE: not working yet
        app.SetScreenSize(_screenWidth, _screenHeight);
        
        // Run application
        app.Run();
    }

    public void Screen(string title, int width, int height)
    {
        this._title = title;
        this._screenWidth = width;
        this._screenHeight = height;
    }

    public void Backdrop(string name)
    {
        
    }

    // TODO: call in Setup currently does not work properly
    public void Backdrop(Color color)
    {
        this._backColor = color;
        this.app.ClearScreen(color);
    }

    public void Circle(Color color, float x, float y, float radius)
    {

    }

    public void Square(Color color, float x, float y, float size)
    {

    }

    public void Image(string name, float x, float y, float width, float height)
    {

    }
}