using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Original : Level
{
    //bulletscreen displays amount of bullets (used and unused)
    BulletScreen bulletScreen;

    //hitscreen displays amount of hit ducks in current round
    HitScreen hitScreen;

    //round screen displays current round
    RoundScreen roundScreen;

    //score screen displays current score
    ScoreScreen scoreScreen;

    public Original(Game1 game) : base(game)
    {
        bulletScreen = new BulletScreen(game);
        hitScreen = new HitScreen(game);
        roundScreen = new RoundScreen(game);
        scoreScreen = new ScoreScreen(game);

        AddDucks(1);
    }

    public override void Update(GameTime gameTime, InputHandler inputHandler)
    {
        base.Update(gameTime, inputHandler);

        bulletScreen.Update(gameTime, inputHandler);
        hitScreen.Update(gameTime);
        roundScreen.Update(gameTime);
        scoreScreen.Update(gameTime);
    }

    public override void Draw(SpriteBatch s)
    {
        base.Draw(s);

        bulletScreen.Draw(s);
        hitScreen.Draw(s);
        roundScreen.Draw(s);
        scoreScreen.Draw(s);
    }
}