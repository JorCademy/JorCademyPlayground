using System;
using System.Net.Mime;
using Microsoft.Xna.Framework;

public partial class Playground
{
    public void Setup()
    {
        Screen("JorCademy Playground", 800, 600);
    }

    public void Draw()
    {
        Backdrop(Color.White);
        Ellipse(Color.Red, 100, 100, 200, 100);
        Rectangle(Color.Green, 200, 200, 400, 300);
        Ellipse(Color.Gold, 400, 400, 300, 300);
    }
}