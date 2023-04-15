using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;
using System;
using MonoGame.Extended.Sprites;

namespace JorCademyPlayground
{
    public class App : Game
    {
        private Playground jcApp;
        private static GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public App(Playground jcApp)
        {
            // MonoGame standard settings
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            // Init window
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;

            // Link app with playground
            this.jcApp = jcApp;
        }

        protected override void Initialize()
        {
            jcApp.Setup();
            this.SetScreenTitle(jcApp.ScreenTitle);
            base.Initialize();
        }

        /* Set window size */
        public void SetScreenSize(int width, int height)
        {
            _graphics.PreferredBackBufferWidth = width;
            _graphics.PreferredBackBufferHeight = height;
        }

        /* Set window title */
        public void SetScreenTitle(string title)
        {
            Window.Title = title;
        }

        /* Refresh screen */
        public void ClearScreen(Color c)
        {
            if (GraphicsDevice == null)
            {
                Console.WriteLine("Backdrop cannot be drawn in Setup.");
                return;
            }

            GraphicsDevice.Clear(c);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        /* Drawing rectangle */
        public void Rectangle(float x, float y, int w, int h, Color color)
        {
            _spriteBatch.DrawRectangle(x, y, w, h, color, 2);
        }

        /* Drawing circle */
        public void Ellipse(float x, float y, int w, int h, Color color)
        {
            // NOTE: Ellipse drawn from center
            int dX = (int)(x + w * 2);
            int dY = (int)(y + h * 2);
            int dW = w * 2;
            int dH = h * 2;
            int sides = 50;
            
            _spriteBatch.DrawEllipse(new Vector2(dX, dY), new Vector2(dW, dH), sides, color, 2);
        }

        /* Draw an image */
        public void Image(string filepath, float x, float y, int w, int h, Color color)
        {
            FileStream fs = new FileStream(filepath, FileMode.Open);
            Texture2D spriteAtlas = Texture2D.FromStream(this.GraphicsDevice, fs);
            fs.Dispose();
            
            _spriteBatch.Draw(spriteAtlas, new Vector2(x, y), color);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Draw all textures within the game
            _spriteBatch.Begin();

            // Draw all shapes specified in Draw method
            jcApp.Draw();
            
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}