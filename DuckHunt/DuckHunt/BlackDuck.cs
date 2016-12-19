using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

class BlackDuck : Duck
{
    public BlackDuck(Texture2D sprite, Rectangle rectangle, Vector2 screen, float depth) : base(sprite, rectangle, depth)
    {
        this.screen = screen;

        direction *= 4.5f;
    }

    public override void Update(MouseState previousMouseState, MouseState newMouseState)
    {
        base.Update(previousMouseState, newMouseState);

        if (random.Next(0, 120) == 0)
        {
            direction.X *= -1;
        }
    }
}
