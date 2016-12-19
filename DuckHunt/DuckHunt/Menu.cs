using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Menu
{
    Texture2D logo;

    List<Button> buttonList = new List<Button>();

    Game game;

    GameWorld gameWorld;

    MouseState previousMouseState;
    MouseState newMouseState;

    public SpriteFont font;

    Vector2 screen;

    public enum GameStates
    {
        Menu,
        SinglePlayerMenu,
        Co_opMenu,
        VersusMenu,
        CalibrationMode,
        Playing,
        Paused
    }

    public GameStates previousGameState, currentGameState;

    public Menu(Game game)
    {
        this.game = game;

        screen.X = game.GraphicsDevice.Viewport.Width;
        screen.Y = game.GraphicsDevice.Viewport.Height;

        previousGameState = GameStates.Menu;
        currentGameState = GameStates.Menu;

        logo = game.Content.Load<Texture2D>("duckhuntlogo");

        Button(300, 300, GameStates.CalibrationMode, "calibration");
        Button(300, 350, GameStates.SinglePlayerMenu, "single player");
        Button(300, 400, GameStates.Co_opMenu, "co-op");
        Button(300, 450, GameStates.VersusMenu, "versus");

        font = game.Content.Load<SpriteFont>("font");
    }

    public void Update()
    {
        previousGameState = currentGameState;

        previousMouseState = newMouseState;
        newMouseState = Mouse.GetState();

        foreach (Button b in buttonList)
        {
            b.Update(previousMouseState, newMouseState);
        }

        //create new buttons when gamestate is changed
        if (previousGameState != currentGameState)
        {
            buttonList.Clear();

            if(currentGameState == GameStates.Menu)
            {
                Button(300, 300, GameStates.CalibrationMode, "calibration");
                Button(300, 350, GameStates.SinglePlayerMenu, "single player");
                Button(300, 400, GameStates.Co_opMenu, "co-op");
                Button(300, 450, GameStates.VersusMenu, "versus");
            }
            else if (currentGameState == GameStates.CalibrationMode)
            {
                Button(300, 450, GameStates.Menu, "back to menu");
            }
            else if (currentGameState == GameStates.SinglePlayerMenu || currentGameState == GameStates.Co_opMenu || currentGameState == GameStates.VersusMenu)
            {
                Button(300, 300, GameStates.Playing, "original");
                Button(300, 350, GameStates.Playing, "unlimited");
                Button(300, 400, GameStates.Playing, "unlimited ammo");
                Button(300, 450, GameStates.Menu, "back to menu");

                gameWorld = new GameWorld(game, screen);
            }
            else if (currentGameState == GameStates.Playing)
            {
                Button(600, 10, GameStates.Paused, "pause");
            }
            else if (currentGameState == GameStates.Paused)
            {
                Button(300, 350, GameStates.Playing, "resume");
                Button(300, 400, GameStates.CalibrationMode, "calibration");
                Button(300, 450, GameStates.Menu, "exit");
            }
        }

        if(currentGameState == GameStates.Playing)
        {
            gameWorld.Update();
        }
    }

    public void Draw(SpriteBatch s)
    {
        if (currentGameState == GameStates.Menu)
        {
            s.Draw(logo, new Rectangle(250, 10, 200, 200), Color.White);
        }
        if (currentGameState == GameStates.Playing)
        {
            gameWorld.Draw(s);
        }

        foreach (Button b in buttonList)
        {
            b.Draw(s);
        }
    }

    void Button(int x, int y, GameStates gameState, string name)
    {
        buttonList.Add(new Button(game.Content.Load<Texture2D>("button"), new Rectangle(x, y, 125, 25), this, gameState, name));
    }
}