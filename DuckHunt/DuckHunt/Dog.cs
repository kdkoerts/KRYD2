using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Dog : AnimatedSpriteGameObject
{
    private Texture2D dogDuckRed;
    private Texture2D dogDuckBlue;
    private Texture2D dogDuckBlack;

    private Vector2 screen;

    public Dog(Texture2D sprite, Texture2D dogDuckRed, Texture2D dogDuckBlue, Texture2D dogDuckBlack, Rectangle rectangle, int frames, float depth, Vector2 screen) : base(sprite, rectangle, frames, depth)
    {

        this.screen = screen;

        this.dogDuckRed = dogDuckRed;
        this.dogDuckBlue = dogDuckBlue;
        this.dogDuckBlack = dogDuckBlack;

    }

    public void dogLaugh()
    {
        rectangle = new Rectangle(((int)(screen.X / 2) + (sprite.Width / 4)), 350, 100, 100);


    }

    public override void Draw(SpriteBatch s)
    {
        base.Draw(s);
    }
}