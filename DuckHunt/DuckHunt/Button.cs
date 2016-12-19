using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Button : SpriteGameObject
{
    Menu menu;
    Menu.GameStates gameState;
    string name;

    public Button(Texture2D sprite, Rectangle rectangle, Menu menu, Menu.GameStates gameState, string name) : base(sprite, rectangle)
    {
        this.menu = menu;
        this.gameState = gameState;

        this.name = name;
    }

    public void Update(MouseState previousMouseState, MouseState newMouseState)
    {
        if (isButtonPressed(previousMouseState, newMouseState))
        {
            menu.currentGameState = gameState;
        }
    }

    public override void Draw(SpriteBatch s)
    {
        base.Draw(s);

        s.DrawString(menu.font, name, new Vector2(rectangle.X + 5, rectangle.Y + 5), Color.Black);
    }

    public bool isButtonPressed(MouseState previousMouseState, MouseState newMouseState)
    {
        if (newMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released
            && newMouseState.Position.X > rectangle.X && newMouseState.Position.X < rectangle.X + rectangle.Width
            && newMouseState.Position.Y > rectangle.Y && newMouseState.Position.Y < rectangle.Y + rectangle.Height)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}