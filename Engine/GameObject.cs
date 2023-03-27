using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JorCademyPlayground 
{
    public abstract class GameObject
    {
        public Vector2 m_position;
        protected int m_width;
        protected int m_height;
        protected Color m_color;
        protected GraphicsDeviceManager m_graphics;

        public Color Color
        {
            get 
            {
                return m_color;
            }
        }

        public Vector2 Position 
        {
            get 
            {
                return this.m_position;
            }
        }

        public abstract Texture2D CreateTexture();
    }

    public class Circle : GameObject
    {
        public Circle(GraphicsDeviceManager g, Vector2 pos, int size, Color c)
        {
            this.m_position = pos;
            this.m_width = size;
            this.m_height = size;
            this.m_color = c;
            this.m_graphics = g;
        }

        /* Create circle texture. Source: https://lajbert.github.io/blog/monogame_2d_primitives/#/ */
        public Texture2D CreateCircle()
        {
            Texture2D texture = new Texture2D(this.m_graphics.GraphicsDevice, this.m_width, this.m_height);
            Color[] colorData = new Color[m_width * m_height];

            int diameter = this.m_width;
            float radius = diameter / 2f;
            float radiusSquared = radius * radius;

            for (int x = 0; x < this.m_width; x++)
            {
                for (int y = 0; y < this.m_height; y++)
                {
                    int index = x * this.m_width + y;
                    Vector2 pos = new Vector2(x - radius, y - (this.m_height / 2));
                    if (pos.LengthSquared() <= radiusSquared)
                    {
                        colorData[index] = this.m_color;
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

        /* Helper function for checking whether a point is inside the area of the ellipse */
        private bool InsideEllipse(Vector2 index, int width, int height)
        {
            float xRange = (index.X * index.X) / ((width / 2) * (width / 2));
            float yRange = (index.Y * index.Y) / ((height / 2) * (height / 2));
            return (xRange + yRange <= 1);
        }

        /* Create primitive texture */
        public override Texture2D CreateTexture()
        {
            return this.CreateCircle();
        }
    }

    public class Rectangle : GameObject 
    {
        public Rectangle(GraphicsDeviceManager g, Vector2 pos, int size, Color c)
        {
            this.m_position = pos;
            this.m_width = size;
            this.m_height = size;
            this.m_color = c;
            this.m_graphics = g;
        }

        /* Create rectangle texture. Source: https://lajbert.github.io/blog/monogame_2d_primitives/#/ */
        public Texture2D CreateRectangle()
        {
            Texture2D rect = new Texture2D(this.m_graphics.GraphicsDevice, this.m_width, this.m_height);
            Color[] data = new Color[this.m_width * this.m_height];

            for (int i = 0; i < data.Length; ++i)
            {
                data[i] = this.m_color;
            }

            rect.SetData(data);
            return rect;
        }

        /* Create primitive texture */
        public override Texture2D CreateTexture()
        {
            return this.CreateRectangle();
        }
    }

    public class Sprite : GameObject
    {
        private string m_filePath;

        public Sprite(GraphicsDeviceManager g, string filePath, int width, int height, Vector2 pos, Color c)
        {
            this.m_filePath = filePath;
            this.m_position = pos;
            this.m_width = width;
            this.m_height = height;
            this.m_color = c;
            this.m_graphics = g;
        }

        /* Create image texture. Source: https://community.monogame.net/t/loading-png-jpg-etc-directly/7403 */
        public override Texture2D CreateTexture()
        {
            FileStream fileStream = new FileStream(m_filePath, FileMode.Open);
            Texture2D spriteAtlas = Texture2D.FromStream(this.m_graphics.GraphicsDevice, fileStream);
            fileStream.Dispose();
            return spriteAtlas;
        }
    }
}