using System;
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
    private readonly App _app;

    // Screen properties
    private int _screenWidth;
    private int _screenHeight;
    private string _title;
    private Color _backColor;

    public int ScreenWidth => this._screenWidth;
    public int ScreenHeight => this._screenHeight;
    public string ScreenTitle => this._title;
    public Color BackColor => this._backColor;
    
    public Playground() 
    {
        this._title = "JorCademy Playground"; 
        this._backColor = Color.White;
        
        _app = new App(this);
        
        // Process fetched changes
        _app.SetScreenTitle(_title);
        
        // Update all properties 
        this.Setup();

        // Process fetched changes (continued)
        _app.SetScreenSize(_screenWidth, _screenHeight);

        // Run application
        _app.Run();
    }

    /// <summary>
    /// Initialize the window of the application.
    /// </summary>
    /// <param name="title">Screen title</param>
    /// <param name="width">Screen width</param>
    /// <param name="height">Screen height</param>
    public void Screen(string title, int width, int height)
    {
        this._title = title;
        this._screenWidth = width;
        this._screenHeight = height;
    }
    
    public void Clear()
    {
        this._app.ClearObjects();
    }

    /// <summary>
    /// Set backdrop image.
    /// </summary>
    /// <param name="name">Name of corresponding file.</param>
    /// <exception cref="NotImplementedException">Yet to be implemented</exception>
    private void Backdrop(string name)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Set backdrop color.
    /// </summary>
    /// <param name="color">Color of choice</param>
    public void Backdrop(Color color)
    {
        this._backColor = color;
        this._app.ClearScreen(color);
    }

    /// <summary>
    /// Draw a circle.
    /// </summary>
    /// <param name="color">Surface color</param>
    /// <param name="x">X coordinate</param>
    /// <param name="y">Y coordinate</param>
    /// <param name="radius">Radius (width / 2)</param>
    public void Circle(Color color, float x, float y, int radius)
    {
        this._app.Circle(x, y, radius, color);
    }

    /// <summary>
    /// Draw a square.
    /// </summary>
    /// <param name="color">Surface color</param>
    /// <param name="x">X coordinate</param>
    /// <param name="y">Y coordinate</param>
    /// <param name="size">Width & height</param>
    public void Square(Color color, float x, float y, int size)
    {
        this._app.Square(x, y, size, color);
    }

    /// <summary>
    /// Draw a sprite.
    /// </summary>
    /// <param name="name">Name of the corresponding file</param>
    /// <param name="x">X coordinate</param>
    /// <param name="y">Y coordinate</param>
    /// <param name="width">Width</param>
    /// <param name="height">Height</param>
    public void Sprite(string name, float x, float y, int width, int height)
    {   
        this._app.Image(name, x, y, width, height, Color.White);
    }
}