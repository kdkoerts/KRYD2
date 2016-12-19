using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckHunt
{
    class SpriteGameObject : GameObject
    {
        public Vector2 drawOffset;
        public float depth;

        public SpriteGameObject()
        {

        }

        public void Draw()
        {

        }

        public void Depth()
        {

            //treeDrawZ = (position.Y - 720) / 360 * 0.8f + 0.2f;

            depth = 1 - ((position.Y - 720)/360);
            //depth = Math.Abs(depth);
        }
    }
}
