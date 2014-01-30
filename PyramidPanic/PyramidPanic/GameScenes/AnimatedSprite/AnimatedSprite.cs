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

namespace PyramidPanic
{
    public class AnimatedSprite
    {
        //Fields
        private IAnimatedSprite iAnimatedSprite;
        // 2 rectangle variables aangemaakt 
        protected Rectangle destinationRectangle, sourceRectangle;
        // een timer (handig voor update method)
        private float timer = 0f;
        // effect variabele (handig voor flipeffecten)
        protected SpriteEffects effect;
        protected int imageNumber = 1; //Loopt van 0 tm 3
        // een rotatie variabele
        protected float rotation = 0f;
        // pivot = draaipunt, zorgt ervoor dat de main character fijn (smooth) kan draaien
        private Vector2 pivot;


        // De constructor
        public AnimatedSprite(IAnimatedSprite iAnimatedSprite)
        {
            // Dit zorgt dat dat de animated sprite goed werkt
            this.iAnimatedSprite = iAnimatedSprite;
            // Hier woorde met de sourcerect gebruik gemaakt van het imageNumber variabel
            this.sourceRectangle = new Rectangle(this.imageNumber * 32, 0, 32, 32);  
            // effect vooral gebruit voor flippen
            this.effect = SpriteEffects.None;
            // pivot is draaipunt
            this.pivot = new Vector2(16f, 16f);
        }

        //Update
        public void Update(GameTime gameTime)
        {
            // timer van de updatefunctie die wordt gebruikt voor de source rect
            if (this.timer > 5 / 60f)
            {
                if (this.sourceRectangle.X < 96)
                {
                    this.sourceRectangle.X += 32;
                }
                else
                {
                    this.sourceRectangle.X = 0;
                }
                this.timer = 0f;
            }
            this.timer += 1 / 60f;
        }


        // Draw method van de AnimatedSprite class
        public void Draw(GameTime gameTime)
        {
            // Dit is dde draw methode van de iAnimatedsprite, het maakt gebruik van de 
            // Spritebatch, hier wordt ook het pivot punt gebruikt
            this.iAnimatedSprite.Game.SpriteBatch.Draw(this.iAnimatedSprite.Texture,
                                              this.destinationRectangle,
                                              this.sourceRectangle,
                                              Color.White,
                                              this.rotation,
                                              this.pivot,
                                              this.effect,
                                              0f);              
        }
    }
}
