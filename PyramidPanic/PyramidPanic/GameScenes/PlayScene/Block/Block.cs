// Met using kan je een XNA codebibliotheek toevoegen en gebruiken in je class
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

// block
namespace PyramidPanic
{
    public class Block : Image
    {
        // fields
        // nog geen fields op dit moment

        // properties

         //Constructor
        public Block(PyramidPanic game, string pathNameAsset, Vector2 position) 
              : base(game, pathNameAsset, position)
        {
            // Begin van de constuctor
            // Nog niet klaar
        }

        // update

        // draw
        public void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
