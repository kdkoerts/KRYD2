using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class AnimatedSpriteGameObject : SpriteGameObject
{
    int frames;
    int currentFrame;
    int frameTime;
    protected Vector2 direction;
    public Vector2 directionp
    {
        get { return direction; }
        set { direction = value; }
    }

    public AnimatedSpriteGameObject(Texture2D sprite, Rectangle rectangle, int frames) : base(sprite, rectangle)
    {
        this.frames = frames;
        currentFrame = 1;
        frameTime = 0;
    }

    public void Update(GameTime gameTime)
    {
        frameTime += gameTime.ElapsedGameTime.Milliseconds;

        if(frameTime > 500)
        {
            currentFrame++;

            if(currentFrame == frames)
            {
                currentFrame = 0;
            }

            frameTime = 0;
        }
    }
    // Checks if the sprite is moving left or right and flips its sprite accordingly.
    public override void Draw(SpriteBatch s)
    {
        if(directionp.X < 0)
        {
            s.Draw(sprite, rectangle, new Rectangle((currentFrame * sprite.Width / frames), 0, (sprite.Width / frames), sprite.Height), Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0.9f); 
        }
        else
        {
            s.Draw(sprite, rectangle, new Rectangle((currentFrame * sprite.Width / frames), 0, (sprite.Width / frames), sprite.Height), Color.White);
        }
    }

}