using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

class Tree : SpriteGameObject
{
    public float depth;
    GameWorld w;
    Texture2D particlesprite;
    int timer = 0;

    public Tree(GameWorld w, Texture2D sprite, Texture2D particlesprite, Rectangle rectangle, float depth) : base(sprite, rectangle)
    {
        this.depth = depth;
        this.w = w;
        this.particlesprite = particlesprite;
        this.timer = Particle.Rnd.Next(500);
    }

    public void Update()
    {
        ++timer;
        if(timer == 500)
        {
            w.Add(new Particle(new Vector2(0, 1), new Vector2(0, -0.0005f), 250, new Color(175, 255, 0), particlesprite, this.rectangle.Location.ToVector2() + this.rectangle.Size.ToVector2() * new Vector2((float)Particle.Rnd.NextDouble(), (float)Particle.Rnd.NextDouble())));
            timer = 0;
        }
    }
}

