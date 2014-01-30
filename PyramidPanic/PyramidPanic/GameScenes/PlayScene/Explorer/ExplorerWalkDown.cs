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
    
    public class ExplorerWalkDown : AnimatedSprite, IEntityState
    {
        //Fields
        // explorer object
        private Explorer explorer;
        // velocity
        private Vector2 velocity;

        //Contstructor
        public ExplorerWalkDown(Explorer explorer) : base(explorer)
        {
            // exporer object
            this.explorer = explorer;
            // dest renct
            this.destinationRectangle = new Rectangle((int)this.explorer.Position.X,
                                                      (int)this.explorer.Position.Y,
                                                      32,
                                                      32);
            // velocity
            this.velocity = new Vector2(0f, this.explorer.Speed);
            // rotation
            this.rotation = (float)Math.PI / 2;
        }

        // initialize
        public void Initialize()
        {
            // X + Y worden hier aangegeven
            this.destinationRectangle.X = (int)this.explorer.Position.X;
            this.destinationRectangle.Y = (int)this.explorer.Position.Y;
        }

        // update
        public new void Update(GameTime gameTime)
        {
            // Deze code zorgt ervoor dat de explorer niet buiten de rechterrand
            // kan lopen.
            this.explorer.Position += this.velocity;
            if (this.explorer.Position.Y > 480 - 16)
            {
                //Breng de explorer in de toestand Idlewalk
                this.explorer.Position -= this.velocity;
                this.explorer.State = this.explorer.IdleWalk;
                // effect
                this.explorer.IdleWalk.Effect = SpriteEffects.None;
                // rotatie
                this.explorer.IdleWalk.Rotation = (float)Math.PI / 2;  
            }
            
            // Als de Right knop wordt losgelaten, dan moet de 
            // explorer weer in de toestand Idle komen
            if (Input.EdgeDetectKeyUp(Keys.Down))
            {
                this.explorer.State = this.explorer.Idle;
                this.explorer.Idle.Effect = SpriteEffects.None;
                this.explorer.Idle.Rotation = (float)Math.PI / 2;
            }

            // update gametime
            base.Update(gameTime);
        }

        // draw
        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
