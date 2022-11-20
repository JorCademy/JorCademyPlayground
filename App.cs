using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace JorCademyPlayground
{
    public class App : Game
    {
        private Playground jcApp;
        private static GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        
        // Window properties
        public Color BackgroundColor;
        
        // Containing all primitives in the scene
        private List<GameObject> objectsInScene;

        public App(Playground jcApp)
        {
            // MonoGame standard settings
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            // Init window
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            this.BackgroundColor = Color.White;

            // Initialize list of textures within scene
            objectsInScene = new List<GameObject>();       

            // Link app with playground
            this.jcApp = jcApp;
        }

        protected override void Initialize()
        {
            // Set window title
            this.SetScreenTitle("JorCademy Playground");

            // Setup JC app
            jcApp.Setup();

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

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /* Drawing primitives, Source: https://lajbert.github.io/blog/monogame_2d_primitives/#/ */

        /* Drawing rectangle */
        public static Texture2D CreateRectangle(int size, Color color)
        {
            Texture2D rect = new Texture2D(_graphics.GraphicsDevice, size, size);
            Color[] data = new Color[size * size];

            for (int i = 0; i < data.Length; ++i)
            {
                data[i] = color;
            }

            rect.SetData(data);
            return rect;
        }

        /* Drawing circle */
        public void Ellipse(int x, int y, int size, Color color)
        {
            this.objectsInScene.Add(new Ellipse(_graphics, new Vector2(x, y), size, color));
        }

        protected override void Draw(GameTime gameTime)
        {
            // Reset screen
            GraphicsDevice.Clear(BackgroundColor);
    
            // Update JorCademy app
            jcApp.Update(gameTime);

            // Draw all textures within the game
            _spriteBatch.Begin();
            foreach (GameObject obj in this.objectsInScene)
            {
                _spriteBatch.Draw(obj.CreateTexture(), new Vector2(obj.Position.X, obj.Position.Y), obj.Color);
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}