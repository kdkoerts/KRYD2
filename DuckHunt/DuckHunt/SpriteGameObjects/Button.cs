using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

class Button : SpriteGameObject
{
    private string name;
    private Vector2 textPosition;
    private bool isButtonClicked;
    private GameStateManager.NextGameState nextGameState;

    public Button(Game1 game, Rectangle rectangle, String name, GameStateManager.NextGameState nextGameState) : base(game.Content.Load<Texture2D>("button"), rectangle, 1f)
    {
        this.name = name;

        textPosition = new Vector2(rectangle.X + rectangle.Width / 10, rectangle.Y + rectangle.Height / 10);

        this.nextGameState = nextGameState;
    }

    public String Name
    {
        get { return name; }
    }

    public bool IsButtonClicked
    {
        get { return isButtonClicked; }
    }

    public GameStateManager.NextGameState NextGameState
    {
        get { return nextGameState; }
    }

    public void Update(GameTime gameTime, InputHandler inputHandler)
    {
        base.Update(gameTime);

        isButtonClicked = isHit(inputHandler);
    }

    public void Draw(SpriteBatch s, SpriteFont f)
    {
        base.Draw(s);

        s.DrawString(f, name, textPosition, Color.White);
    }
}