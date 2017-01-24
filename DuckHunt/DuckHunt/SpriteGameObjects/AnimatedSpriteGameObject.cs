using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class AnimatedSpriteGameObject : SpriteGameObject
{
    private int frames;
    private int currentFrame;
    private int frameTime;

    public AnimatedSpriteGameObject(Texture2D sprite, Rectangle rectangle, int frames, float depth) : base(sprite, rectangle, depth)
    {
        this.frames = frames;
        currentFrame = 1;
        frameTime = 0;
        spriteEffects = SpriteEffects.None;
    }

    public override void Update(GameTime gameTime)
    {
        //update frameTime and check if enough time has passed to change to the next animation frame
        frameTime += gameTime.ElapsedGameTime.Milliseconds;

        if (frameTime > 500)
        {
            currentFrame++;

            if (currentFrame == frames)
            {
                currentFrame = 0;
            }

            frameTime = 0;
        }

        base.Update(gameTime);
    }

    public override void Draw(SpriteBatch s)
    {
        //destination rectangle is used to draw the current frame
        s.Draw(sprite, rectangle, new Rectangle((currentFrame * sprite.Width / frames), 0, (sprite.Width / frames), sprite.Height), Color.White, 0, Vector2.Zero, spriteEffects, 0.9f);
    }
}