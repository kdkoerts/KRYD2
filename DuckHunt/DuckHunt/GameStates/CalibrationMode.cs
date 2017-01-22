using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//used for calibrating the camera input with the game screen
class CalibrationMode : GameState
{
    public CalibrationMode(Game1 game) : base(game, game.Content.Load<Texture2D>("background"), GameStateManager.NextGameState.CalibrationMode)
    {
        //create buttons and add them to the buttonlist
        Rectangle r = new Rectangle((int)(game.screen.X - 500) / 2, (int)(game.screen.Y - 300), 500, 125);
        Button b = new Button(game, r, "back to menu", GameStateManager.NextGameState.MainMenu);
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