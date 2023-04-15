using System;
using Microsoft.Xna.Framework;
using JorCademyPlayground;
using Microsoft.Xna.Framework.Graphics;

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
    /// Draw an ellipse.
    /// </summary>
    /// <param name="color">Surface color</param>
    /// <param name="x">X coordinate</param>
    /// <param name="y">Y coordinate</param>
    /// <param name="w">Surface width</param>
    /// <param name="h">Surface height</param>
    public void Ellipse(Color color, float x, float y, int w, int h)
    {
        this._app.Ellipse(x, y, w, h, color);
    }

   /// <summary>
   /// Draw a rectangle.
   /// </summary>
   /// <param name="color">Surface color</param>
   /// <param name="x">X coordinate</param>
   /// <param name="y">Y coordinate</param>
   /// <param name="w">Surface width</param>
   /// <param name="h">Surface heigth</param>
    public void Rectangle(Color color, float x, float y, int w, int h)
    {
        this._app.Rectangle(x, y, w, h, color);
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
        // TODO: Filepath may vary per platform. Fix for this is necessary
        this._app.Image($"../../../Content/{name}", x, y, width, height, Color.White);
    }
}