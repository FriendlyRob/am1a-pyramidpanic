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
    public class Image
    {
        //fields
        //maak een variabele (reference) aan van het type Texture2D met de naam texture
        private Texture2D texture;


        //Maak een variabele aan (reference) aan van het type Color met de naam color
        private Color color = Color.White;

        //maak een rectangle voor het detecteren van collisions
        private Rectangle rectangle;

        //maak een variabele aan om de game instantie in op te slaan.
        private PyramidPanic game;

        #region Properties

        public Color Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        public Rectangle Rectangle
        {
            get { return this.rectangle; }
        }
        #endregion

        //constructor
        public Image(PyramidPanic game, String pathnameAsset, Vector2 position)
        {
            this.game = game;
            this.texture = game.Content.Load<Texture2D>(pathnameAsset);
            this.rectangle = new Rectangle((int)position.X,
                                           (int)position.Y,
                                           this.texture.Width,
                                           this.texture.Height);
        }


        //update


        //draw
        public void Draw(GameTime gameTime)
        {
            this.game.SpriteBatch.Draw(this.texture, this.rectangle, this.color);
        }

        //helper Methods
    }
}