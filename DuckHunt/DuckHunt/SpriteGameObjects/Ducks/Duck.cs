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

    private int timeAlive;
    private bool isAlive;
    private bool isShot;
    private int hitTime;

    private Texture2D deadDuck;
    private Texture2D fallingDuck;

    private bool removableDuck;
    public bool RemovableDuck
    {
        get { return removableDuck; }
    }

    public Duck(Texture2D sprite, Texture2D deadDuck, Texture2D fallingDuck, Rectangle rectangle, int frames, float depth, Vector2 screen) : base(sprite, rectangle, frames, depth)
    {
        random = new Random();

        isAlive = true;

        this.screen = screen;

        this.deadDuck = deadDuck;

        this.fallingDuck = fallingDuck;

        removableDuck = false;

        RandomDirection();

        hitTime = 1000;
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

    public void Flee()
    {
        if (rectangle.X < screen.X / 2)
        {
            Direction = new Vector2(random.Next(-20, 0), random.Next(-20, 0));
        }
        else
        {
            Direction = new Vector2(random.Next(0, 20), random.Next(-20, 0));
        }
        if (rectangle.X + rectangle.Width > screen.X + 10 || rectangle.X < -10)
        {
            removableDuck = true;

        }
        Direction.Normalize();
        Direction *= 2;
    }

    public virtual void Update(GameTime gameTime, InputHandler inputHandler)
    {
        base.Update(gameTime);
        if(timeAlive < 300 && !isShot)
        {
            StayOnScreen();
        }
        else if(!isShot)
        {
            Flee();
        }

        if (isHit(inputHandler))
        {
            isAlive = false;
            isShot = true;
            Direction = Vector2.Zero;
        }
        if (isShot)
        {
            hitTime -= gameTime.ElapsedGameTime.Milliseconds;
            if (hitTime <= 0)
            {
                Direction = new Vector2(0, 10);
            }
            if (rectangle.Y > screen.Y)
            {
                removableDuck = true;
            }
        }
        timeAlive++;
    }

    public override void Draw(SpriteBatch s)
    {
        if (isAlive)
        {
            base.Draw(s);
        }
        else
        {
            if (hitTime > 0)
            {
                s.Draw(deadDuck, rectangle, Color.White);
            }
            else
            {
                s.Draw(fallingDuck, rectangle, Color.White);
            }
        }
    }
}