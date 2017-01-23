using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class BlueDuck : Duck
{
    public BlueDuck(Rectangle rectangle, Game1 game, float depth, Vector2 screen) : 
        base(game.Content.Load<Texture2D>("blueDuckAnimation"), game.Content.Load<Texture2D>("deadDuckBlue"), game.Content.Load<Texture2D>("fallingDuckBlue"), rectangle, 3, depth, screen)
    {
        Direction *= 3f;
    }

    public override void Update(GameTime gameTime, InputHandler inputHandler)
    {
        base.Update(gameTime, inputHandler);
    }

    public override void Draw(SpriteBatch s)
    {
        base.Draw(s);
    }
}
