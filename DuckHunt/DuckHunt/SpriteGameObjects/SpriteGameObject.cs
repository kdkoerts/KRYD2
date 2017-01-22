using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class SpriteGameObject
{
    protected Texture2D sprite;
    protected Rectangle rectangle;
    protected float depth;
    private Vector2 direction;
    protected SpriteEffects spriteEffects;

    public SpriteGameObject(Texture2D sprite, Rectangle rectangle, float depth)
    {
        this.sprite = sprite;
        this.rectangle = rectangle;
        this.depth = depth;
    }

    public Vector2 Direction
    {
        get { return direction; }
        set
        {
            direction = value;

            // Checks if the sprite is moving left and flips the sprite if needed.
            if (value.X < 0)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            else
            {
                spriteEffects = SpriteEffects.None;
            }
        }
    }

    public bool isHit(InputHandler inputHandler)
    {
        if (inputHandler.IsMouseClicked && inputHandler.MousePosition.X > rectangle.X && inputHandler.MousePosition.X < rectangle.X + rectangle.Width
            && inputHandler.MousePosition.Y > rectangle.Y && inputHandler.MousePosition.Y < rectangle.Y + rectangle.Height)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public virtual void Update(GameTime gameTime)
    {
        rectangle.X += (int)direction.X;
        rectangle.Y += (int)direction.Y;
    }

    public virtual void Draw(SpriteBatch s)
    {
        s.Draw(sprite, rectangle, Color.White);
    }
}