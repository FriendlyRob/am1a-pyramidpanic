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
    public class Explorer : IAnimatedSprite
    {
        //Fields
        private PyramidPanic game;
        // entitystate zorgt voor de states
        private IEntityState state;
        // texture voor de sprite
        private Texture2D texture;
        // speed = snelheid van de explorer
        private int speed = 2;
        // positie van explorer wordt ook gebruikt (zeer belangrijk)
        private Vector2 position;

        //Maak van iedere toestand (state) een field
        // Hier zijn alle states waar de explorer aan kan voldoen
        // walkup
        private ExplorerWalkUp walkUp;
        //Walkdown
        private ExplorerWalkDown walkDown;
        // Walksleft
        private ExplorerWalkLeft walkLeft;
        // Walkright
        private ExplorerWalkRight walkRight;
        // idle (niet aan het walken)
        private ExplorerIdle idle;
        // idle (wel walken)
        private ExplorerIdleWalk idleWalk;

        //properties
        // Walkup propertie
        public ExplorerWalkUp WalkUp
        {
            get { return this.walkUp; }
        }       
        // Walkdown proppertie
        public ExplorerWalkDown WalkDown
        {
            get { return this.walkDown; }
        }
        // Walkleft Propertie
        public ExplorerWalkLeft WalkLeft
        {
            get { return this.walkLeft; }
        }
        // Walkright propertie
        public ExplorerWalkRight WalkRight
        {
            get { return this.walkRight;}
        }
        // Idle propertie
        public ExplorerIdle Idle
        {
            get { return this.idle; }
        }
        // Idlewalk propertie
        public ExplorerIdleWalk IdleWalk
        {
            get { return this.idleWalk; }
        }
        public Vector2 Position
        {
            get { return this.position; }
            set { this.position = value;
            this.state.Initialize();
            }
        }
        public IEntityState State
        {
            set { 
                    this.state = value;
                    this.state.Initialize();
                }
        }
        public PyramidPanic Game
        {
            get { return this.game; }
        }
        public int Speed
        {
            get { return this.speed; }
        }
        public Texture2D Texture
        {
            get { return this.texture; }
        }
        
        //Constructor
        public Explorer(PyramidPanic game, Vector2 position)
        {
            this.game = game;
            this.position = position;
            this.texture = game.Content.Load<Texture2D>(@"Explorer\Explorer");
            this.walkUp = new ExplorerWalkUp(this);
            this.walkDown = new ExplorerWalkDown(this);
            this.walkLeft = new ExplorerWalkLeft(this);
            this.walkRight = new ExplorerWalkRight(this);
            this.idle = new ExplorerIdle(this);
            this.idleWalk = new ExplorerIdleWalk(this);
            this.state = this.idle;
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
