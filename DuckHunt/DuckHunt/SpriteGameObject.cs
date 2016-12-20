using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class SpriteGameObject : GameObject
{
    protected Texture2D sprite;
    public Rectangle rectangle;

    public SpriteGameObject(Texture2D sprite, Rectangle rectangle)
    {
        this.sprite = sprite;
        this.rectangle = rectangle;
    }

    public virtual void Draw(SpriteBatch s)
    {
        s.Draw(sprite, rectangle, Color.White);
    }
}
