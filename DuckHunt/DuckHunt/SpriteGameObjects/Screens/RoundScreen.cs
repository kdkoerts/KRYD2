using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class RoundScreen : SpriteGameObject
{
    private int round;

    private SpriteFont font;

    Vector2 textPosition;

    public RoundScreen(Game1 game) : base(game.Content.Load<Texture2D>("roundScreen"), new Rectangle((int)game.screen.X - 220, (int)game.screen.Y - 140, 200, 120), 1f)
    {
        font = game.Content.Load<SpriteFont>("font");

        Round = 0;

        textPosition = new Vector2(rectangle.X + rectangle.Width * 4 / 10, rectangle.Y + rectangle.Height / 10);
    }

    public int Round
    {
        get { return round; }
        set
        {
            if (value < 0)
            {
                round = 0;
            }
            else
            {
                round = value;
            }
        }
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }

    public override void Draw(SpriteBatch s)
    {
        base.Draw(s);

        //draw current round
        s.DrawString(font, round.ToString(), textPosition, Color.White);
    }
}