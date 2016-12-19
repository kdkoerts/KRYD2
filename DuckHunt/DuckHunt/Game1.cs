using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace DuckHunt
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D eendSprite;
        Texture2D boomSprite;
        Duck duck;
        List<Tree> treeList = new List<Tree>();
        Random r = new Random();

        public int bullets = 3;
        public MouseState oldmouse;

        //Temp score var en spritefont
        Vector2 MousePos = new Vector2();
        int score = 0;
        SpriteFont font;


        public Game1()
        {
            
            graphics = new GraphicsDeviceManager(this);
            //graphics.IsFullScreen = true;
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1024;
            Content.RootDirectory = "Content";

        }

        static void Main()
        {
            Game1 game = new Game1();
            game.Run();
        }

        protected void Mouseshooter()
        {
            MouseState mouse = Mouse.GetState();
            if (bullets > 0)                                   //If statement so that you can only shoot when you have ammo.
            {
                if (mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)    //
                {                                               //
                    MousePos = new Vector2(mouse.X, mouse.Y);   // Sets the mouse location to MousePos 
                    if (duck.Hitbox.Contains(MousePos))         //and checks if the MousePos is inside the hitbox of the duck.
                    {
                        duck.Reset();
                        score += 100;
                    }
                    bullets--;
                }
            }
            oldmouse = mouse;

        }


        protected override void Initialize()
        {
            base.Initialize();

            //TEMP MUIS ZICHTBAAR
            this.IsMouseVisible = true;

            for (int i = 0; i < 100; i++)
            {
                treeList.Add(new Tree(r.Next(0, 1920), r.Next(720, 1080), 0, boomSprite));

               
            }

            treeList.Sort((Tree t1, Tree t2) => { return t1.depth.CompareTo(t2.depth); });

            duck = new Duck(eendSprite);

        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            eendSprite = Content.Load<Texture2D>("ZwarteEend");
            boomSprite = Content.Load<Texture2D>("tree");
            //TEMP LOAD
            font = Content.Load<SpriteFont>("Spelfont");
        }

        
        protected override void UnloadContent()
        {


        }

       
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.R))
            {
                score = 0;
                bullets = 3;
            }
            Mouseshooter();
            duck.Update(gameTime);

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin(SpriteSortMode.BackToFront);
            duck.Draw(spriteBatch);

            //TEMP draw voor score
            spriteBatch.DrawString(font, score.ToString(), new Vector2(40, 20), Color.Black);

            for (int i = treeList.Count -1 ; i >= 0 ; i--)//for (int i = 0; i < treeList.Count; i++)
            {
                treeList[i].Draw(spriteBatch);
            }
            /*
            foreach (Tree t in treeList)
            {
                t.Draw(spriteBatch);
            }
            */
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
