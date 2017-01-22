using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//every game state inherites from this class, it deals with updating the buttons
//deals with button clicks and drawing the background and buttons.
abstract class GameState
{
    protected Texture2D background;

    protected List<Button> buttonList;

    protected Vector2 screen;

    protected SpriteFont font;

    protected GameStateManager.NextGameState nextGameState;

    protected PlayingState.GameMode gameMode;

    public GameState(Game1 game, Texture2D background, GameStateManager.NextGameState nextGameState)
    {
        this.background = background;

        buttonList = new List<Button>();

        screen = game.screen;

        font = game.Content.Load<SpriteFont>("font");

        this.nextGameState = nextGameState;
    }

    public PlayingState.GameMode GetGameMode
    {
        get { return gameMode; }
    }

    public GameStateManager.NextGameState NextGameState
    {
        get { return nextGameState; }
        set { nextGameState = value; }
    }

    public virtual void Update(GameTime gameTime, InputHandler inputHandler)
    {
        //if a button is clicked, gets what the game state needs to be from that button
        foreach (Button b in buttonList)
        {
            b.Update(gameTime, inputHandler);

            if (b.IsButtonClicked)
            {
                nextGameState = b.NextGameState;
            }
        }
    }

    public virtual void Draw(SpriteBatch s)
    {
        s.Draw(background, new Rectangle(0, 0, (int)screen.X, (int)screen.Y), Color.White);

        foreach (Button b in buttonList)
        {
            b.Draw(s, font);
        }
    }
}