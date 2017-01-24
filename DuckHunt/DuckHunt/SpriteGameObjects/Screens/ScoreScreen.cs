using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

 class ScoreScreen : SpriteGameObject
    {
        private int score;

        private SpriteFont font;

        Vector2 textPosition;

        public ScoreScreen(Game1 game) : base(game.Content.Load<Texture2D>("score screen"), new Rectangle((int)game.screen.X - 485, (int)game.screen.Y - 140, 200, 120), 1f)
    {
            font = game.Content.Load<SpriteFont>("font");

            Round = 0;

            textPosition = new Vector2(rectangle.X + rectangle.Width * 4 / 10, rectangle.Y + rectangle.Height / 10);
        }

        public int Round
        {
            get { return score; }
            set
            {
                if (value < 0)
                {
                    score = 0;
                }
                else
                {
                    score = value;
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch s)
        {
            base.Draw(s);

            //draw current round
            s.DrawString(font, score.ToString(), textPosition, Color.White);
        }
    }

