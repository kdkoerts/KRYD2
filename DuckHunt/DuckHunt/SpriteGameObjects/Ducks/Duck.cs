using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

abstract class Duck : AnimatedSpriteGameObject
{
    static Random random;
    private Vector2 screen;

    private bool isAlive;

    public Duck(Texture2D sprite, Rectangle rectangle, int frames, float depth, Vector2 screen) : base(sprite, rectangle, frames, depth)
    {
        random = new Random();

        isAlive = true;

        this.screen = screen;

        RandomDirection();
    }

    public bool IsAlive
    {
        get { return isAlive; }
    }

    public void RandomDirection()
    {
        //gives the duck a random direction
        Vector2 direction = new Vector2(random.Next(-100, 100), random.Next(-100, 100));
        direction.Normalize();
        Direction = direction;
    }

    public void StayOnScreen()
    {
        if (rectangle.X < 0)
        {
            Vector2 direction = Direction;
            direction.X *= -1;
            Direction = direction;
            rectangle.X = 0;
        }
        else if (rectangle.X + rectangle.Width > screen.X)
        {
            Vector2 direction = Direction;
            direction.X *= -1;
            Direction = direction;
            rectangle.X = (int)(screen.X - rectangle.Width);
        }

        if (rectangle.Y < 0)
        {
            Vector2 direction = Direction;
            direction.Y *= -1;
            Direction = direction;
            rectangle.Y = 0;
        }
        else if (rectangle.Y + rectangle.Height > screen.Y * 9f / 10f)
        {
            Vector2 direction = Direction;
            direction.Y *= -1;
            Direction = direction;
            rectangle.Y = (int)(screen.Y * 9f / 10f - rectangle.Height);
        }
    }

    public virtual void Update(GameTime gameTime, InputHandler inputHandler)
    {
        base.Update(gameTime);

        StayOnScreen();

        if (isHit(inputHandler))
        {
            isAlive = false;
        }
    }

    public override void Draw(SpriteBatch s)
    {
        base.Draw(s);
    }
}