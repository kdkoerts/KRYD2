using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

//menu where the user can choose one of the game modes
class GameModeMenu : GameState
{
    public GameModeMenu(Game1 game) : base(game, game.Content.Load<Texture2D>("menu_background"), GameStateManager.NextGameState.GameModeMenu)
    {
        //create buttons and add them to the buttonlist
        Rectangle r = new Rectangle((int)(game.screen.X - 500) / 2, (int)(game.screen.Y - 700), 500, 125);
        Button b = new Button(game, r, "original", GameStateManager.NextGameState.PlayingState);
        buttonList.Add(b);

        r = new Rectangle((int)(game.screen.X - 500) / 2, (int)(game.screen.Y - 500), 500, 125);
        b = new Button(game, r, "unlimited", GameStateManager.NextGameState.PlayingState);
        buttonList.Add(b);

        r = new Rectangle((int)(game.screen.X - 500) / 2, (int)(game.screen.Y - 300), 500, 125);
        b = new Button(game, r, "unlimited ammo", GameStateManager.NextGameState.PlayingState);
        buttonList.Add(b);
    }

    public override void Update(GameTime gameTime, InputHandler inputHandler)
    {
        base.Update(gameTime, inputHandler);

        foreach (Button b in buttonList)
        {
            if (b.IsButtonClicked)
            {
                if (b.Name == "original")
                {
                    gameMode = PlayingState.GameMode.Original;
                }
                else if (b.Name == "unlimited")
                {
                    gameMode = PlayingState.GameMode.Unlimited;
                }
                else if (b.Name == "unlimited ammo")
                {
                    gameMode = PlayingState.GameMode.UnlimitedAmmo;
                }
            }
        }
    }

    public override void Draw(SpriteBatch s)
    {
        base.Draw(s);
    }
}