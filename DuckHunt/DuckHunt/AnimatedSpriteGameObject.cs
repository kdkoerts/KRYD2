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

    public override void Draw(SpriteBatch s)
    {
        s.Draw(sprite, rectangle, new Rectangle((currentFrame * sprite.Width / frames), 0, (sprite.Width / frames), sprite.Height), Color.White);
    }

}