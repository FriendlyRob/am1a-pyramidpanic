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

// exporerwalk
namespace PyramidPanic
{
    // Dit is een toestands class (dus moet hij de interface implementeren)
    // Deze class belooft dan plechtig dat hij de methods uit de interface heeft (toepast)  
    public class ExplorerIdleWalk : AnimatedSprite, IEntityState
    {
        //Fields
        // Explorer object
        private Explorer explorer;
        // velocity tijdens lopen
        private Vector2 velocity;
        // imagenumber foor animate sprite
        private int imageNumber = 1;
       
        //properties
        // effect (flippen)
        public SpriteEffects Effect
        {
            set { this.effect = value; }
        }
        // rotatie
        public float Rotation
        {
            set { this.rotation = value; }
        }

        //Constructor
        public ExplorerIdleWalk(Explorer explorer) : base(explorer)
        {
            // explorer object
            this.explorer = explorer;
            // destination rectangle
            this.destinationRectangle = new Rectangle((int)this.explorer.Position.X,
                                                      (int)this.explorer.Position.Y,
                                                      32,
                                                      32);
            // source rectangle
            this.sourceRectangle = new Rectangle(this.imageNumber * 32, 0, 32, 32);
            // velocity
            this.velocity = new Vector2(0f, 0f);
        }

        // initialize
        public void Initialize()
        {
            // hier worden de x en de y geinitialiseerd
            this.destinationRectangle.X = (int)this.explorer.Position.X;
            this.destinationRectangle.Y = (int)this.explorer.Position.Y;
        }

        // update
        public new void Update(GameTime gameTime)
        {
            //Bij het indrukken van de Right knop moet de toestand van de explorer veranderen in
            // ExplorerWalkRight
            if (Input.EdgeDetectKeyUp(Keys.Right))
            {
                this.explorer.State = this.explorer.Idle;
                this.explorer.Idle.Effect = SpriteEffects.None;
                this.explorer.Idle.Rotation = 0f;
            }
            //Bij het indrukken van de Left knop moet de toestand van de explorer veranderen in
            // ExplorerWalkleft
            else if (Input.EdgeDetectKeyUp(Keys.Left))
            {
                this.explorer.State = this.explorer.Idle;
                this.explorer.Idle.Effect = SpriteEffects.FlipHorizontally;
                this.explorer.Idle.Rotation = 0f;
            }
            //Bij het indrukken van de down knop moet de toestand van de explorer veranderen in
            // ExplorerWalk down
            else if (Input.EdgeDetectKeyUp(Keys.Down))
            {
                this.explorer.State = this.explorer.Idle;
                this.explorer.Idle.Effect = SpriteEffects.None;
                this.explorer.Idle.Rotation = (float)Math.PI / 2;
            }
            //Bij het indrukken van de up knop moet de toestand van de explorer veranderen in
            // ExplorerWalk up 
            else if (Input.EdgeDetectKeyUp(Keys.Up))
            {
                this.explorer.State = this.explorer.Idle;
                this.explorer.Idle.Effect = SpriteEffects.FlipVertically;
                this.explorer.Idle.Rotation = -(float)Math.PI / 2;
            }
            // Zorgt voor animatie. Roept de update(Gametime gametime) method aan van de AnimatedSpriteclass
            base.Update(gameTime);
        }

        // draw
        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
