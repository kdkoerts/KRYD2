using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckHunt
{
    class Tree : SpriteGameObject
    {
        Texture2D TreeSpr;
        Vector2 scaling;

        public Tree(int posX, int posY, int posZ, Texture2D tex)
        {

            position.X = posX;
            position.Y = posY;

            scaling.X = (position.Y - 720f) / 360f * 0.8f + 0.2f; //Workaround omdat de draw een Vector2 wil
            scaling.Y = scaling.X;


            TreeSpr = tex;
            drawOffset.X = -TreeSpr.Width * scaling.X / 2;
            drawOffset.Y = -TreeSpr.Height * scaling.Y;
           


            Depth();

            

        }

        public override void LoadContent()
        {

        }

        public override void Update()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(TreeSpr, position + drawOffset, null, null, null, 0, scaling, Color.White, SpriteEffects.None, depth);
        }
    }
}
