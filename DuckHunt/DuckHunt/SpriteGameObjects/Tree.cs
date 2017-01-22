using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Tree : SpriteGameObject
{
    public Tree(Rectangle rectangle, Game1 game, float depth) : base(game.Content.Load<Texture2D>("Tree"), rectangle, depth)
    {

    }

    public float Depth
    {
        get { return depth; }
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }

    public override void Draw(SpriteBatch s)
    {
        base.Draw(s);
    }
}