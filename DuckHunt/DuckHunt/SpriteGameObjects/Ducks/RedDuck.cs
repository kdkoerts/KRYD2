using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class RedDuck : Duck
{
    public RedDuck(Rectangle rectangle, Game1 game, float depth, Vector2 screen) : 
        base(game.Content.Load<Texture2D>("redDuckAnimation"), game.Content.Load<Texture2D>("duckFleeRed"), game.Content.Load<Texture2D>("deadDuckRed"), game.Content.Load<Texture2D>("fallingDuckRed"), rectangle, 3, depth, screen)
    {
        Direction *= 4f;
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
