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
    
    public class ExplorerIdle : AnimatedSprite, IEntityState
    {
        //Fields
        // explorer object
        private Explorer explorer;
        // velocity (position + speed)
        private Vector2 velocity;
        // gebruikt voor de sourcerect (animation)
        private int imageNumber = 1;
       
        //properties
        // sprite effect proppertie
        public SpriteEffects Effect
        {
            set { this.effect = value; }
        }

        // rotatie propertie
        public float Rotation
        {
            set { this.rotation = value; }
        }

        //Constructor
        public ExplorerIdle(Explorer explorer) : base(explorer)
        {
            // Hier zijn alle gegevens die worden meegegeven aan de propertie van de exploreridle
            // explorer object (vrij logisch lol :P)
            this.explorer = explorer;
            // dest rectangle
            this.destinationRectangle = new Rectangle((int)this.explorer.Position.X,
                                                      (int)this.explorer.Position.Y,
                                                      32,
                                                      32);
            // source rectangle
            this.sourceRectangle = new Rectangle(this.imageNumber * 32, 0, 32, 32);
            // de velocitie van de idle state is 0,0 want je bent idle
            this.velocity = new Vector2(0f, 0f);
        }

        // initialize
        public void Initialize()
        {
            // X + Y worden hier geinitialiseerd
            this.destinationRectangle.X = (int)this.explorer.Position.X;
            this.destinationRectangle.Y = (int)this.explorer.Position.Y;
        }

        // update
        public new void Update(GameTime gameTime)
        {
            //Bij het indrukken van de Right knop moet de toestand van de explorer veranderen in
            // ExplorerWalkRight
            if (Input.LevelDetectKeyDown(Keys.Right))
            {
                this.explorer.State = this.explorer.WalkRight;
                this.explorer.WalkRight.Initialize();

            }
            //Bij het indrukken van de Left knop moet de toestand van de explorer veranderen in
            // ExplorerWalkleft
            else if (Input.LevelDetectKeyDown(Keys.Left))
            {
                this.explorer.State = this.explorer.WalkLeft;
                this.explorer.WalkLeft.Initialize();
            }
            //Bij het indrukken van de down knop moet de toestand van de explorer veranderen in
            // ExplorerWalk down
            else if (Input.LevelDetectKeyDown(Keys.Down))
            {
                this.explorer.State = this.explorer.WalkDown;
                this.explorer.WalkDown.Initialize();
            }
            //Bij het indrukken van de up knop moet de toestand van de explorer veranderen in
            // ExplorerWalk up 
            else if (Input.LevelDetectKeyDown(Keys.Up))
            {
                this.explorer.State = this.explorer.WalkUp;
                this.explorer.WalkUp.Initialize();
            }
            // velocity met positie berekenen
            this.explorer.Position += this.velocity;
            // X + Y
            this.destinationRectangle.X = (int)this.explorer.Position.X;
            this.destinationRectangle.Y = (int)this.explorer.Position.Y;
            //base.Update(gameTime);
        }

        // Draw
        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
