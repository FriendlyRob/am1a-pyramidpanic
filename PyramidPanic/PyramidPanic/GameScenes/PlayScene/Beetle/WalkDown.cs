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
    // Dit is een toestands class (dus moet hij de interface implementeren)
    // Deze class belooft dan plechtig dat hij de methods uit de interface heeft (toepast)
    
    public class WalkDown : AnimatedSprite, IEntityState
    {
        //Fields
        // Beetle moet hier worden meegegeven (best wel logisch)
        private Beetle beetle;
        // velocity
        private Vector2 velocity;

        //Contstructor
        public WalkDown(Beetle beetle) : base(beetle)
        {
            // beetle object hier
            this.beetle = beetle;
            // voor walkdown wordt hij verticaal geflipt
            this.effect = SpriteEffects.FlipVertically;
            // positie van de veetle
            this.destinationRectangle = new Rectangle((int)this.beetle.Position.X,
                                                      (int)this.beetle.Position.Y,
                                                      32,
                                                      32);
            // snelheid
            this.velocity = new Vector2(0f, this.beetle.Speed);
        }
        
        // Initialize
        public void Initialize()
        {
            // Hier worden de x en y positie geinitialiseerd
            this.destinationRectangle.X = (int)this.beetle.Position.X;
            this.destinationRectangle.Y = (int)this.beetle.Position.Y;
        }

        // Update
        public new void Update(GameTime gameTime)
        {
            // de min 16 zorgt ervoor dat de beetle niet half uit het scherm gaat
            if (this.beetle.Position.Y > 480 - 16)
            {
                // Als de beetle onderaan komt, gaat hij over naar de walkupclasse
                this.beetle.State = new WalkUp(this.beetle);
                // De walkupclasse wordt geinitialiseerd hier
                this.beetle.WalkUp.Initialize();
            }
            // positie + velocity om nieuwe positie te berekenen
            this.beetle.Position += this.velocity;
            this.destinationRectangle.X = (int)this.beetle.Position.X;
            this.destinationRectangle.Y = (int)this.beetle.Position.Y;
            // update van gametime
            base.Update(gameTime);
        }

        // Draw
        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
