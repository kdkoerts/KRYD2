using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class BulletScreen : SpriteGameObject
{
    private const int totalBullets = 3;
    private int bullets;

    private Texture2D bullet;
    private Texture2D usedBullet;

    private Rectangle[] r;

    public BulletScreen(Game1 game) : base(game.Content.Load<Texture2D>("bulletScreen"), new Rectangle(20, (int)(game.screen.Y - 140), 200, 120), 1f)
    {
        Bullets = totalBullets;

        bullet = game.Content.Load<Texture2D>("bullet");
        usedBullet = game.Content.Load<Texture2D>("usedBullet");

        //rectangle array for places where bullets are drawn
        r = new Rectangle[totalBullets];
        for (int i = 0; i < totalBullets; i++)
        {
            r[i] = new Rectangle(rectangle.X + (int)(rectangle.Width * (1f / 10f + i * 3f / 10f)), rectangle.Y + rectangle.Height / 20, rectangle.Width / 5, ((rectangle.Height * 3) / 5));
        }
    }

    //property for getting amount of bullets left, and setting amount of useable bullets whithin the proper range
    public int Bullets
    {
        get { return bullets; }
        set
        {
            if (value >= 0 && value <= totalBullets)
            {
                bullets = value;
            }
            else if (value < 0)
            {
                bullets = 0;
            }
            else
            {
                bullets = totalBullets;
            }
        }
    }

    public void Update(GameTime gameTime, InputHandler inputHandler)
    {
        base.Update(gameTime);

        //if a bullet is used, lower the amount of bullets by one
        if (inputHandler.IsMouseClicked)
        {
            Bullets--;
        }
    }

    public override void Draw(SpriteBatch s)
    {
        base.Draw(s);

        Texture2D sprite = bullet;

        for (int i = 0; i < totalBullets; i++)
        {
            //draw a yellow bullet for every bullet that isn't used yet
            //draw a grey bullet for every used bullet

            if (i == bullets)
            {
                sprite = usedBullet;
            }

            s.Draw(sprite, r[i], Color.White);
        }
    }
}