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
        // Position propertie 
        // deze geeft ook een setter
        public Vector2 Position
        {
            get { return this.position; }
            set 
            { 
                this.position = value;
                this.state.Initialize();
            }
        }
        // ientitystate 
        // Heeft alleen maar setter want getteer is bij het veranderen van states niet nodig
        public IEntityState State
        {
            set 
            { 
                this.state = value;
                this.state.Initialize();
            }
        }
        // game propertie
        public PyramidPanic Game
        {
            get { return this.game; }
        }
        // speed propertie
        public int Speed
        {
            get { return this.speed; }
        }
        // texture propertie
        public Texture2D Texture
        {
            get { return this.texture; }
        }
        
        //Constructor
        public Explorer(PyramidPanic game, Vector2 position)
        {
            // Hier zijn alle gegevens die worden meegegeven aan de propertie van de explorer
            // game
            this.game = game;
            // positie van de explorer
            this.position = position;
            // de sprite van de exporer ( @"Explorer\Explorer" dit geeft aan de route naar het plaatje
            // dat gebruikt voort voor de explorer)
            this.texture = game.Content.Load<Texture2D>(@"Explorer\Explorer");
            // de states van de explorer
            // walkup
            this.walkUp = new ExplorerWalkUp(this);
            // walkdown
            this.walkDown = new ExplorerWalkDown(this);
            // walkleft
            this.walkLeft = new ExplorerWalkLeft(this);
            // walkright
            this.walkRight = new ExplorerWalkRight(this);
            // idle (not walk)
            this.idle = new ExplorerIdle(this);
            // idlewalk
            this.idleWalk = new ExplorerIdleWalk(this);

            // De beginstate van de explorer is idle want als je start
            // Ben je nog niks aan het doen dus dan is idle de juiste state
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
