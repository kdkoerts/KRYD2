using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Level
{
    protected Game1 game;
    protected Vector2 screen;
    protected Random random;

    protected List<Tree> treeList;
    protected List<Duck> duckList;

    public Level(Game1 game)
    {
        this.game = game;
        screen = game.screen;
        random = new Random();

        treeList = new List<Tree>();
        AddTrees(10);

        duckList = new List<Duck>();
    }

    public void AddTrees(int n)
    {
        //adds n trees to treeList, with a random position and a size corresponding to the depth of the tree
        for (int i = 0; i < n; i++)
        {
            float depth = 0.6f + 0.25f * (float)random.NextDouble();
            float x = (float)random.NextDouble();
            int width = 500;
            int height = 1000;
            Rectangle rectangle = new Rectangle((int)(x * (screen.X - width)), (int)(depth * (screen.Y - height)), (int)(depth * width), (int)(depth * height));
            treeList.Add(new Tree(rectangle, game, depth));
        }

        //sort treelist based on depth, so trees are drawn in the correct order
        treeList.Sort((x, y) => x.Depth.CompareTo(y.Depth));
    }

    public void AddDucks(int n)
    {
        //Adds n ducks to duckList
        for (int i = 0; i < n; i++)
        {
            Duck d = new BlackDuck(new Rectangle(500, 500, 300, 300), game, 1f, screen);
            duckList.Add(d);
        }
    }

    public virtual void Update(GameTime gameTime, InputHandler inputHandler)
    {
        //update all ducks
        foreach (Duck d in duckList)
        {
            d.Update(gameTime, inputHandler);
        }

        //remove dead ducks and add new ducks
        int removedDucks = 0;

        for (int i = duckList.Count; i > 0; i--)
        {
            if (!duckList.ElementAt<Duck>(i - 1).IsAlive)
            {
                duckList.RemoveAt(i - 1);
                removedDucks++;
            }
        }

        AddDucks(removedDucks);
    }

    public virtual void Draw(SpriteBatch s)
    {
        foreach (Tree t in treeList)
        {
            t.Draw(s);
        }

        foreach (Duck d in duckList)
        {
            d.Draw(s);
        }
    }
}