// met using kan je een XNA codebibliotheek gebruiken in je class
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

namespace PyramidPanic
{
    class Image
    {
        // Fields
        private Texture2D texture;

        // Maak een rectangle voor het detecteren van collisions
        private Rectangle rectangle;

        // Maake een variabele aan om de game instantie in op te slaan.
        private PyramidPanic game;

        // Constructor
        public Image(PyramidPanic game, string pathNameAsset, Vector2 position)
        {
            this.game = game;
            this.texture = game.Content.Load<Texture2D>(pathNameAsset);
            this.rectangle = new Rectangle((int)position.X, 
                                           (int)position.Y,
                                           this.texture.Width,
                                           this.texture.Height);
        }

        // Update

        // Draw
        public void Draw(GameTime gameTime)
        {
            this.game.SpriteBatch.Draw(texture, rectangle, Color.White);
        }

        // Helper Methods
    }
}
