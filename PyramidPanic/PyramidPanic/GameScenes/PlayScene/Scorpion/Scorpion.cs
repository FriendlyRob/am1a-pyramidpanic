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

// scorpion
namespace PyramidPanic
{
    public class Scorpion : IAnimatedSprite
    {
        //Fields
        // game object
        private PyramidPanic game;
        // ientity states
        private IEntityState state;
        // texture for the sprite
        private Texture2D texture;
        // speed of the scorpion
        private int speed = 2;
        // the position of the scorpion
        private Vector2 position;
        // the 2 things that scorpion can do, walkleft and walkright
        private WalkLeft walkLeft;
        private WalkRight walkRight;

        //properties
        // walkleft
        public WalkLeft WalkLeft
        {
            get { return this.walkLeft; }
        }
        // walkright
        public WalkRight WalkRight
        {
            get { return this.walkRight; }
        }
        // postition (also has set so it can change)
        public Vector2 Position
        {
            get { return this.position; }
            set { this.position = value; }
        }
        // states
        public IEntityState State
        {
            set { this.state = value; }
        }
        // game
        public PyramidPanic Game
        {
            get { return this.game; }
        }
        // speed of scorpion
        public int Speed
        {
            get { return this.speed; }
        }
        // texture for the sprite that the scorpion uses
        public Texture2D Texture
        {
            get { return this.texture; }
        }
        
        //Constructor
        public Scorpion(PyramidPanic game, Vector2 position)
        {
            // game object
            this.game = game;
            // position of the scorpion
            this.position = position;
            // texture (@"Scorpion\Scorpion" = path to the picture used for the scrpion)
            this.texture = game.Content.Load<Texture2D>(@"Scorpion\Scorpion");
            // walkleft and right (the 2 thing he can do)
            this.walkLeft = new WalkLeft(this);
            this.walkRight = new WalkRight(this);
            //states
            this.state = this.walkLeft;
        }

        //Update
        public void Update(GameTime gameTime)
        {
           this.state.Update(gameTime);
        }

        //Draw
        public void Draw(GameTime gameTime)
        {
            this.state.Draw(gameTime);                   
        }
    }
}
