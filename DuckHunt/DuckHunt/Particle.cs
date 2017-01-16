using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

    public struct Particle
    {
        Vector2 velocity;
        Vector2 acceleration;
        public int lifespan;
        Color color;
        Texture2D texture;
        Vector2 location;

        public static readonly Random Rnd = new Random();

        public Particle(Vector2 velocity, Vector2 acceleration, int lifespan, Color color, Texture2D texture, Vector2 location)
        {
            this.velocity = velocity;
            this.acceleration = acceleration;
            this.lifespan = lifespan;
            this.color = color;
            this.texture = texture;
            this.location = location;
        }

        public void Update()
        {
            velocity += acceleration;
            location += velocity;
            lifespan -= 1;
        }

        public void Draw(SpriteBatch s)
        {
            s.Draw(texture, location, color);
        }
    }

