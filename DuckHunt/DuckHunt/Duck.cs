using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

abstract class Duck : SpriteGameObject
{
    protected Vector2 direction;

    protected Vector2 screen;

    public bool isAlive;

    public float depth;

    protected static Random random;

    public Duck(Texture2D sprite, Rectangle rectangle, float depth) : base(sprite, rectangle)
    {
        isAlive = true;

        this.depth = depth;

        random = new Random();

        direction = new Vector2(random.Next(-100, 100), random.Next(-100, 100));
        direction.Normalize();
    }

    public virtual void Update(MouseState previousMouseState, MouseState newMouseState)
    {
        rectangle.X += (int)direction.X;
        rectangle.Y += (int)direction.Y;

        if(isDuckHit(previousMouseState, newMouseState))
        {
            isAlive = false;
        }

        if (rectangle.X + rectangle.Width > screen.X || rectangle.X < 0)
        {
            direction.X *= -1;
        }
        if (rectangle.Y + rectangle.Height > screen.Y || rectangle.Y < 0)
        {
            direction.Y *= -1;
        }
    }

    public override void Draw(SpriteBatch s)
    {
        base.Draw(s);
    }

    public bool isDuckHit(MouseState previousMouseState, MouseState newMouseState)
    {
        if (newMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released
            && newMouseState.Position.X > rectangle.X && newMouseState.Position.X < rectangle.X + rectangle.Width
            && newMouseState.Position.Y > rectangle.Y && newMouseState.Position.Y < rectangle.Y + rectangle.Height)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

