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

// walkright
namespace PyramidPanic
{
    // Dit is een toestands class (dus moet hij de interface implementeren)
    // Deze class belooft dan plechtig dat hij de methods uit de interface heeft (toepast)
    public class WalkRight : AnimatedSprite, IEntityState
    {
        //Fields
        // scorpion object
        private Scorpion scorpion;
        // velocity
        private Vector2 velocity;

        //Contstructor
        // walkright
        public WalkRight(Scorpion scorpion) : base(scorpion)
        {
            // scorpion object
            this.scorpion = scorpion;
            // destination rectangle
            this.destinationRectangle = new Rectangle((int)this.scorpion.Position.X,
                                                      (int)this.scorpion.Position.Y,
                                                      32,
                                                      32);
            // velocity of the scorp
            this.velocity = new Vector2(this.scorpion.Speed, 0f);
        }

        // initialize
        public void Initialize()
        {
            // x+y are initialized here
            this.destinationRectangle.X = (int)this.scorpion.Position.X;
            this.destinationRectangle.Y = (int)this.scorpion.Position.Y;
        }

        // update
        public new void Update(GameTime gameTime)
        {
            // touch the edge of screen and turn states
            // so it will also change the direction it will go
            if (this.scorpion.Position.X > 640 - 16)
            {
                //Breng de beetle in de toestand walkdown
                this.scorpion.State = this.scorpion.WalkLeft;
                this.scorpion.WalkLeft.Initialize();
            }
            // scorpion position calculating
            this.scorpion.Position += this.velocity;
            // x+y
            this.destinationRectangle.X = (int)this.scorpion.Position.X;
            this.destinationRectangle.Y = (int)this.scorpion.Position.Y;
            // update gamitiem
            base.Update(gameTime);
        }

        //draw
        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
