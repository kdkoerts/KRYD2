using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class GameStateManager
{
    private GameState currentGameState;
    private GameState temporaryGameState;

    private Game1 game;

    public enum NextGameState
    {
        MainMenu,
        GameModeMenu,
        CalibrationMode,
        PauseMenu,
        PlayingState
    }
    private NextGameState nextGameState;

    private InputHandler inputHandler;

    public GameStateManager(Game1 game)
    {
        this.game = game;

        nextGameState = NextGameState.MainMenu;

        currentGameState = new MainMenu(game);

        inputHandler = new InputHandler();
    }

    private void ChangeGameState()
    {
        //changes currentGameState to a different GameState if needed
        if (nextGameState != currentGameState.NextGameState)
        {
            if (currentGameState.NextGameState == NextGameState.MainMenu)
            {
                currentGameState = new MainMenu(game);
            }
            else if (currentGameState.NextGameState == NextGameState.GameModeMenu)
            {
                currentGameState = new GameModeMenu(game);
            }
            else if (currentGameState.NextGameState == NextGameState.PauseMenu)
            {
                //temporaryGameState is used to save the game when changing gameState to PauseMenu
                temporaryGameState = currentGameState;
                currentGameState = new PauseMenu(game);
            }
            else if (currentGameState.NextGameState == NextGameState.PlayingState)
            {
                //get the chosen game mode
                PlayingState.GameMode gameMode = currentGameState.GetGameMode;

                //when changing to PlayingState, check if a game is saved
                if (temporaryGameState != null)
                {
                    currentGameState = temporaryGameState;
                    currentGameState.NextGameState = NextGameState.PlayingState;
                }
                else
                {
                    currentGameState = new PlayingState(game, gameMode);
                }
            }
            else if (currentGameState.NextGameState == NextGameState.CalibrationMode)
            {
                currentGameState = new CalibrationMode(game);
            }

            nextGameState = currentGameState.NextGameState;

            //if the current GameState is not the PauseMenu, the saved game is removed
            if (nextGameState != NextGameState.PauseMenu)
            {
                temporaryGameState = null;
            }
        }
    }

    public void Update(GameTime gameTime)
    {
        inputHandler.Update();

        ChangeGameState();

        currentGameState.Update(gameTime, inputHandler);
    }

    public void Draw(SpriteBatch s)
    {
        currentGameState.Draw(s);
    }
}