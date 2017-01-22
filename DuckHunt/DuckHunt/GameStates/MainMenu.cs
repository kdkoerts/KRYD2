using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

//the main menu, where the user can choose to go the game mode menu, or to the calibration mode
class MainMenu : GameState
{
    public MainMenu(Game1 game) : base(game, game.Content.Load<Texture2D>("menu_background"), GameStateManager.NextGameState.MainMenu)
    {
        //create buttons and add them to the buttonlist
        Rectangle r = new Rectangle((int)(game.screen.X - 500) / 2, (int)(game.screen.Y - 500), 500, 125);
        Button b = new Button(game, r, "play game", GameStateManager.NextGameState.GameModeMenu);
        buttonList.Add(b);

        r = new Rectangle((int)(game.screen.X - 500) / 2, (int)(game.screen.Y - 300), 500, 125);
        b = new Button(game, r, "calibration", GameStateManager.NextGameState.CalibrationMode);
        buttonList.Add(b);
    }

    public override void Update(GameTime gameTime, InputHandler inputHandler)
    {
        base.Update(gameTime, inputHandler);
    }

    public override void Draw(SpriteBatch s)
    {
        base.Draw(s);
    }
}