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
        
        // Containing all primitives in the scene
        private List<Texture2D> textures;

        public App(Playground jcApp)
        {
            // MonoGame standard settings
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            // Standard window size
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;

            // Initialize list of textures within scene
            textures = new List<Texture2D>();       

            // Link app with playground
            this.jcApp = jcApp;
        }

        protected override void Initialize()
        {
            // Add textures to draw
            textures.Add(CreateRectangle(100, Color.White));
            textures.Add(CreateCircle(200, Color.White));

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

        // NOTE: Need separate classes for primitives
        // Drawing rectangle
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

        // Drawing circle
        public static Texture2D CreateCircle(int diameter, Color color)
        {
            Texture2D texture = new Texture2D(_graphics.GraphicsDevice, diameter, diameter);
            Color[] colorData = new Color[diameter * diameter];

            float radius = diameter / 2f;
            float radiusSquared = radius * radius;

            for (int x = 0; x < diameter; x++)
            {
                for (int y = 0; y < diameter; y++)
                {
                    int index = x * diameter + y;
                    Vector2 pos = new Vector2(x - radius, y - radius);
                    if (pos.LengthSquared() <= radiusSquared)
                    {
                        colorData[index] = color;
                    }
                    else
                    {
                        colorData[index] = Color.Transparent;
                    }
                }
            }

            texture.SetData(colorData);
            return texture;
        }

        protected override void Draw(GameTime gameTime)
        {
            // Reset screen
            GraphicsDevice.Clear(Color.CornflowerBlue);
    
            // Update JorCademy app
            jcApp.Update(gameTime);

            // Draw all textures within the game
            _spriteBatch.Begin();
            foreach (Texture2D prim in this.textures)
            {
                _spriteBatch.Draw(prim, new Vector2(100, 100 + 100 * textures.IndexOf(prim)), Color.White);
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}