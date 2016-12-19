using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

class Tree : SpriteGameObject
{
    public float depth;

    public Tree(Texture2D sprite, Rectangle rectangle, float depth) : base(sprite, rectangle)
    {
        this.depth = depth;
    }
}

