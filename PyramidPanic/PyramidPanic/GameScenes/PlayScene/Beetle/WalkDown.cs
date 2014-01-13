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
    //Dit is een toestand classe
    public class WalkDown : AnimatedSprite , IEntityState
    {
        //Fields
        private Beetle beetle;


        //Constructor
        public WalkDown(Beetle beetle) : base(beetle)
        {
            this.beetle = beetle;
            this.effect = SpriteEffects.FlipVertically;
            this.destinationRectangle = new Rectangle((int)this.beetle.Position.X, (int)this.beetle.Position.Y, 32, 32);
        }


        public new void Update(GameTime gameTime)
        {
            if (this.beetle.Position.Y > 480 - 32)
            {
                this.beetle.State = new WalkUp(this.beetle);
            }

            this.beetle.Position += new Vector2(0f, this.beetle.Speed);
            this.destinationRectangle.X = (int)this.beetle.Position.X;
            this.destinationRectangle.Y = (int)this.beetle.Position.Y;
            base.Update(gameTime);
        }

        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
