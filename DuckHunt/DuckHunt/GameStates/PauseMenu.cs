using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

//the pause menu, where the user can choose to resume the game, or go back to the main menu
class PauseMenu : GameState
{
    public PauseMenu(Game1 game) : base(game, game.Content.Load<Texture2D>("menu_background"), GameStateManager.NextGameState.PauseMenu)
    {
        //create buttons and add them to the buttonlist
        Rectangle r = new Rectangle((int)(game.screen.X - 500) / 2, (int)(game.screen.Y - 500), 500, 125);
        Button b = new Button(game, r, "resume", GameStateManager.NextGameState.PlayingState);
        buttonList.Add(b);

        r = new Rectangle((int)(game.screen.X - 500) / 2, (int)(game.screen.Y - 300), 500, 125);
        b = new Button(game, r, "back to menu", GameStateManager.NextGameState.MainMenu);
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