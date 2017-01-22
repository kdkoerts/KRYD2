using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class HitScreen : SpriteGameObject
{
    private const int totalDucks = 10;
    private int hitDucks;

    private Texture2D greenDuck;
    private Texture2D whiteDuck;

    private Rectangle[] r;

    public HitScreen(Game1 game) : base(game.Content.Load<Texture2D>("hitScreen"), new Rectangle((int)((game.screen.X - 800) / 2), (int)(game.screen.Y - 140), 800, 120), 1f)
    {
        HitDucks = 0;

        greenDuck = game.Content.Load<Texture2D>("duckGreen");
        whiteDuck = game.Content.Load<Texture2D>("duckWhite");

        r = new Rectangle[totalDucks];
        for (int i = 0; i < totalDucks; i++)
        {
            r[i] = new Rectangle(rectangle.X + (int)(rectangle.Width * (3f / 25f + i * 2f / 25f)), rectangle.Y + rectangle.Height / 3, rectangle.Width / 25, rectangle.Height / 2);
        }
    }

    //property for getting amount of hit ducks in current round, and for setting amount of hit ducks whithin proper range
    public int HitDucks
    {
        get { return hitDucks; }
        set
        {
            if (value >= 0 && value <= totalDucks)
            {
                hitDucks = value;
            }
            else if (value < 0)
            {
                hitDucks = 0;
            }
            else
            {
                hitDucks = totalDucks;
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

        Texture2D sprite = greenDuck;

        for (int i = 0; i < totalDucks; i++)
        {
            //draw a green duck for every hit duck
            //draw a white duck for every other duck

            if (i == hitDucks)
            {
                sprite = whiteDuck;
            }

            s.Draw(sprite, r[i], Color.White);
        }
    }
}