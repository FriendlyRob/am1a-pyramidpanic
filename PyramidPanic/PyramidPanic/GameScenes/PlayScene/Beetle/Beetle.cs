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
    public class Beetle : IAnimatedSprite
    {
        //Fields

        private PyramidPanic game;
        private Texture2D texture;
        private int speed = 2;
        private IEntityState state;
        private Vector2 position;

        //Properties
        public Vector2 Position
        {
            get { return this.position; }
            set { this.position = value; }
        }

        public IEntityState State
        {
            set { this.state = value; }
        }

        public PyramidPanic Game
        {
            get { return this.game; }
        }

        public Texture2D Texture
        {
            get { return this.texture; }
        }

        public int Speed
        {
            get { return this.speed; }
        }

        //Constructor
        public Beetle (PyramidPanic game , Vector2 position)
        {
            this.game = game;
            this.position = position;
            this.texture = game.Content.Load<Texture2D>(@"Beetle\Beetle");
            this.state = new WalkUp(this);
            //this.state = new WalkDown(this);
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
