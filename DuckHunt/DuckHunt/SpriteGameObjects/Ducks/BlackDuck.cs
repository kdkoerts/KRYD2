using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class BlackDuck : Duck
{
    public BlackDuck(Rectangle rectangle, Game1 game, float depth, Vector2 screen) : 
        base(game.Content.Load<Texture2D>("blackDuckAnimation"), game.Content.Load<Texture2D>("deadDuckBlack"), game.Content.Load<Texture2D>("fallingDuckBlack"),  rectangle, 3, depth, screen, 500)
    {
        Direction *= 5f;
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
