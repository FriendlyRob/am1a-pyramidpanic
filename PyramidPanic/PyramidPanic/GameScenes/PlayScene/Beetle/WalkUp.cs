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

// Walkup
namespace PyramidPanic
{
    // Dit is een toestands class (dus moet hij de interface implementeren)
    // Deze class belooft dan plechtig dat hij de methods uit de interface heeft (toepast)
    
    public class WalkUp : AnimatedSprite, IEntityState
    {
        //Fields
        private Beetle beetle;
        // velocity gebruikt de speed en positie om nieuwe positie te berekenen
        private Vector2 velocity;

        //Contstructor
        public WalkUp(Beetle beetle) : base(beetle)
        {
            // beetle object
            this.beetle = beetle;
            // dest rect gebruikt voor de beetle positie en afmetingen
            this.destinationRectangle = new Rectangle((int)this.beetle.Position.X,
                                                      (int)this.beetle.Position.Y,
                                                      32,
                                                      32);
            // velocity : positie, snelheid
            this.velocity = new Vector2(0f, this.beetle.Speed);
        }

        // Initialize
        public void Initialize()
        {
            // X en y worden hier geinitialized
            this.destinationRectangle.X = (int)this.beetle.Position.X;
            this.destinationRectangle.Y = (int)this.beetle.Position.Y;
        }

        // Update
        public new void Update(GameTime gameTime)
        {
            // If positie die ervoor zorgt dat de beetle andere toetand krijgt als 
            // de beetle boven aan het scherm komt
            if (this.beetle.Position.Y < (0+16))
            {
                //Breng de beetle in de toestand walkdown
                this.beetle.State = this.beetle.WalkDown;
                this.beetle.WalkDown.Initialize();
            }
            // positie moet altijd worden geupdate met bewegende objecten
            this.beetle.Position -= this.velocity;
            // X en Y van dest rect
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
