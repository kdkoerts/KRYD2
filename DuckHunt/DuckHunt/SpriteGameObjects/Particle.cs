using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

    public struct Particle
    {
        Vector2 snelheid;
        Vector2 acceleratie;
        public int levensduur;
        Color kleur;
        Texture2D texture;
        Vector2 locatie;

        public static readonly Random Rnd = new Random();

        public Particle(Vector2 snelheid, Vector2 acceleratie, int levensduur, Color kleur, Texture2D texture, Vector2 locatie)
        {
            this.snelheid = snelheid;
            this.acceleratie = acceleratie;
            this.levensduur = levensduur;
            this.kleur = kleur;
            this.texture = texture;
            this.locatie = locatie;
        }

        public void Update()
        {
            snelheid += acceleratie;
            locatie += snelheid;
            levensduur -= 1;
        }

        public void Draw(SpriteBatch s)
        {
            s.Draw(texture, locatie, kleur);
        }
    }

