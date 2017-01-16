using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

class Bullets : SpriteGameObject
{ 
    private int bullets = 2;
    public int Ammo
    {
        get { return bullets; }
        set { bullets = value; }
    }

    public Bullets(Texture2D sprite, Rectangle rectangle, float depth) : base(sprite, rectangle)
    {

    }


}
