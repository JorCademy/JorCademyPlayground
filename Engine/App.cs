﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;
using System;

namespace JorCademyPlayground
{
    public class App : Game
    {
        private Playground jcApp;
        private static GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        
        // Containing all primitives in the scene
        private readonly List<GameObject> _objectsInScene;

        public App(Playground jcApp)
        {
            // MonoGame standard settings
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            // Init window
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;

            // Initialize list of textures within scene
            _objectsInScene = new List<GameObject>();

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

        public void ClearObjects()
        {
            this._objectsInScene.Clear();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        /* Drawing rectangle */
        public void Square(float x, float y, int size, Color color)
        {
            this._objectsInScene.Add(new Rectangle(_graphics, new Vector2(x, y), size, color));
        }

        /* Drawing circle */
        public void Circle(float x, float y, int size, Color color)
        {
            this._objectsInScene.Add(new Circle(_graphics, new Vector2(x, y), size, color));
        }

        /* Draw an image */
        public void Image(string name, float x, float y, int w, int h, Color color)
        {
            _objectsInScene.Add(new Sprite(_graphics, name, w, h, new Vector2(x, y), color));
        }

        /* Draw text */
        public void Text(string text, float fontSize, float x, float y)
        {
            throw new NotImplementedException();
        }

        protected override void Draw(GameTime gameTime)
        {
            // Update JorCademy app
            jcApp.Draw();

            // Draw all textures within the game
            _spriteBatch.Begin();
            foreach (GameObject obj in this._objectsInScene)
            {
                _spriteBatch.Draw(obj.CreateTexture(), new Vector2(obj.Position.X, obj.Position.Y), obj.Color);
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}