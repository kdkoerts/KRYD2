using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

//game state that updates and draws the level, 
//has a pause button, so the user can pause the game and go to the pause menu
class PlayingState : GameState
{
    private Level level;

    public enum GameMode
    {
        Original,
        Unlimited,
        UnlimitedAmmo
    }

    public PlayingState(Game1 game, GameMode gameMode) : base(game, game.Content.Load<Texture2D>("background"), GameStateManager.NextGameState.PlayingState)
    {
        //create level
        CreateLevel(game, gameMode);

        //create buttons and add them to the buttonlist
        Rectangle r = new Rectangle((int)(game.screen.X - 300), 50, 250, 100);
        Button b = new Button(game, r, "pause", GameStateManager.NextGameState.PauseMenu);
        buttonList.Add(b);
    }

    private void CreateLevel(Game1 game, GameMode gameMode)
    {
        if (gameMode == GameMode.Original)
        {
            level = new Original(game);
        }
        else if (gameMode == GameMode.Unlimited)
        {
            level = new Unlimited(game);
        }
        else if (gameMode == GameMode.UnlimitedAmmo)
        {
            level = new UnlimitedAmmo(game);
        }
    }

    public override void Update(GameTime gameTime, InputHandler inputHandler)
    {
        //update current level
        level.Update(gameTime, inputHandler);

        base.Update(gameTime, inputHandler);
    }

    public override void Draw(SpriteBatch s)
    {
        //draw background
        s.Draw(background, new Rectangle(0, 0, (int)screen.X, (int)screen.Y), Color.White);

        //draw current level
        level.Draw(s);

        //draw buttons
        foreach (Button b in buttonList)
        {
            b.Draw(s, font);
        }
    }
}