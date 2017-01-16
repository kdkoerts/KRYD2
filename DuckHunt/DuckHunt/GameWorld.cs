using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
class GameWorld
{
    static readonly int MaxParticles = 1000;
    Game game;

    List<Duck> duckList;
    List<Tree> treeList;
    Particle[] particleList = new Particle[MaxParticles];

    MouseState previousMouseState, newMouseState;

    Vector2 screen;

    Random random;

    int aantallevenden = 0;

    public GameWorld(Game game, Vector2 screen)
    {
        this.game = game;

        this.screen = screen;

        random = new Random();

        duckList = new List<Duck>();
        treeList = new List<Tree>();

        AddTrees(10);

        AddDucks(1);
    }

    public void Add(Particle part)
    {
        if (MaxParticles != aantallevenden)
        {
            particleList[aantallevenden] = part;
            aantallevenden++;
        }
    }

    public void RemoveParticles(int amount)
    {
        if (amount > aantallevenden)
            amount = aantallevenden;
        for (int i=0; i<amount && i+amount < aantallevenden; ++i)
        {
            particleList[i] = particleList[i + amount];
        }
        aantallevenden -= amount;
    }

    public void Update(GameTime gameTime)
    {
        previousMouseState = newMouseState;
        newMouseState = Mouse.GetState();

        foreach (Duck d in duckList)
        {
            d.Update(previousMouseState, newMouseState, gameTime);
        }

        for(int i = duckList.Count; i > 0; i--)
        {
            if(!duckList.ElementAt(i - 1).isAlive)
            {
                duckList.RemoveAt(i - 1);
            }
        }

        if(duckList.Count == 0)
        {
            AddDucks(1);
        }
        // Particle dingen
        for (int n = 0; n < aantallevenden;)
        {
            if (particleList[n].levensduur >= 0)
            {
                particleList[n].Update();
                n++;
            }
            else
            {
                aantallevenden -= 1;
                particleList[n] = particleList[aantallevenden];
            }
        }

        foreach(Tree t in treeList)
        {
            t.Update();
        }
   }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(game.Content.Load<Texture2D>("background"), new Rectangle(0, 0, (int)screen.X, (int)screen.Y), Color.White);

        foreach (Tree t in treeList)
        {
            t.Draw(spriteBatch);
        }

        // Particle dingen
        for (int n = 0; n < aantallevenden; n++)
            particleList[n].Draw(spriteBatch);

        foreach (Duck d in duckList)
        {
            d.Draw(spriteBatch);
        }
    }

    public void AddTrees(int n)
    {
        for (int i = 0; i < n; i++)
        {
            float depth = 0.7f + 0.3f * (float)random.NextDouble();
            float x = (float)random.NextDouble();
            Rectangle rectangle = new Rectangle((int)(x * (screen.X - 150)), (int)(depth * (screen.Y - 450)), (int)(depth * 150), (int)(depth * 400));
            treeList.Add(new Tree(this, game.Content.Load<Texture2D>("tree"), game.Content.Load<Texture2D>("blad"), rectangle, depth));
        }

        treeList.Sort((x, y) => x.depth.CompareTo(y.depth));
    }

    public void AddDucks(int n)
    {
        for(int i = 0; i < n; i++)
        {
            float depth = (float)random.NextDouble();
            duckList.Add(new BlackDuck(game.Content.Load<Texture2D>("blackDuckAnimation"), new Rectangle(random.Next(0, (int)screen.X - 50), 250, 50, 50), screen, depth, 3));
        }

        duckList.Sort((x, y) => x.depth.CompareTo(y.depth));
    }
}