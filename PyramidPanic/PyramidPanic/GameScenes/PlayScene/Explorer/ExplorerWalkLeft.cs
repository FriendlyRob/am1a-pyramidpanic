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

// explorerwalkleft
namespace PyramidPanic
{
    // Dit is een toestands class (dus moet hij de interface implementeren)
    // Deze class belooft dan plechtig dat hij de methods uit de interface heeft (toepast)  
    public class ExplorerWalkLeft : AnimatedSprite, IEntityState
    {
        //Fields
        // explorer object
        private Explorer explorer;
        // velocity
        private Vector2 velocity;

        //Contstructor
        public ExplorerWalkLeft(Explorer explorer) : base(explorer)
        {
            // explorer object
            this.explorer = explorer;
            // dest rect
            this.destinationRectangle = new Rectangle((int)this.explorer.Position.X,
                                                      (int)this.explorer.Position.Y,
                                                      32,
                                                      32);
            // velocity
            this.velocity = new Vector2(this.explorer.Speed, 0f);
            // sprite effect is hier fliphorizontally
            this.effect = SpriteEffects.FlipHorizontally;
        }

        // initialize
        public void Initialize()
        {
            // x en y worden hier geinitialiseerd
            this.destinationRectangle.X = (int)this.explorer.Position.X;
            this.destinationRectangle.Y = (int)this.explorer.Position.Y;
        }

        // update
        public new void Update(GameTime gameTime)
        {
            // Deze code zorgt ervoor dat de explorer niet buiten de rechterrand
            // kan lopen.
            this.explorer.Position -= this.velocity;

            if (this.explorer.Position.X < 16 )
            {
                //Breng de explorer in de toestand Idle
                this.explorer.Position += this.velocity;
                this.explorer.State = this.explorer.IdleWalk;
                this.explorer.IdleWalk.Effect = SpriteEffects.FlipHorizontally;
                this.explorer.IdleWalk.Rotation = 0f;
            }

            // Als de Right knop wordt losgelaten, dan moet de 
            // explorer weer in de toestand Idle komen
            if (Input.EdgeDetectKeyUp(Keys.Left))
            {
                // state word idel
                this.explorer.State = this.explorer.Idle;
                // effect = flip hor
                this.explorer.Idle.Effect = SpriteEffects.FlipHorizontally;
                // 0 rotatie
                this.explorer.Idle.Rotation = 0f;
            }
            base.Update(gameTime);
        }

        // draw
        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
