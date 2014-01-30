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

// walkleft
namespace PyramidPanic
{
    // Dit is een toestands class (dus moet hij de interface implementeren)
    // Deze class belooft dan plechtig dat hij de methods uit de interface heeft (toepast)  
    public class WalkLeft : AnimatedSprite, IEntityState
    {
        //Fields
        // scorpion object
        private Scorpion scorpion;
        // velocity of the scorpion when it moves
        private Vector2 velocity;

        //Contstructor
        public WalkLeft(Scorpion scorpion) : base(scorpion)
        {
            // scorpion object
            this.scorpion = scorpion;
            // effect (used for flipping)
            this.effect = SpriteEffects.FlipHorizontally;
            // dest rect
            this.destinationRectangle = new Rectangle((int)this.scorpion.Position.X,
                                                      (int)this.scorpion.Position.Y,
                                                      32,
                                                      32);
            // velocity of scorpion (used for the movement)
            this.velocity = new Vector2(this.scorpion.Speed, 0f);
        }

        // init
        public void Initialize()
        {
            // X+ y initialized here
            this.destinationRectangle.X = (int)this.scorpion.Position.X;
            this.destinationRectangle.Y = (int)this.scorpion.Position.Y;
        }

        // update
        public new void Update(GameTime gameTime)
        {
            // when it touches the end of screen change state so it 
            // will alse change direction it will go
            if (this.scorpion.Position.X < (0+16))
            {
                //Breng de beetle in de toestand walkdown
                this.scorpion.State = this.scorpion.WalkRight;
                this.scorpion.WalkRight.Initialize();
            }
            // calculating the position of the scorpion using the velocity
            this.scorpion.Position -= this.velocity;
            // X+Y
            this.destinationRectangle.X = (int)this.scorpion.Position.X;
            this.destinationRectangle.Y = (int)this.scorpion.Position.Y;
            // update of hte gametiem
            base.Update(gameTime);
        }

        // draw
        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
