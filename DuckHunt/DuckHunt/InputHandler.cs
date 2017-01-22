using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

//eenden kunnen nu geraakt worden d.m.v. muisklik, 
//ook d.m.v. het gooien van een bal tegen het scherm!

class InputHandler
{
    private MouseState previousMouseState;

    private bool isMouseClicked;

    private Vector2 mousePosition;

    public InputHandler()
    {
        previousMouseState = Mouse.GetState();

        mousePosition = new Vector2(previousMouseState.Position.X, previousMouseState.Position.Y);
    }

    public bool IsMouseClicked
    {
        get { return isMouseClicked; }
    }

    public Vector2 MousePosition
    {
        get { return mousePosition; }
    }

    public void Update()
    {
        //get new mouse state and check for mouse click and get the new mouse position

        MouseState newMouseState = Mouse.GetState();

        isMouseClicked = (newMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released);

        mousePosition = new Vector2(newMouseState.Position.X, newMouseState.Y);

        previousMouseState = newMouseState;
    }
}