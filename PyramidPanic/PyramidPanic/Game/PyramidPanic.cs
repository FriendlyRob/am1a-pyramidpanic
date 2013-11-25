// met using kan je een XNA codebibliotheek gebruiken in je class
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
    public class PyramidPanic : Microsoft.Xna.Framework.Game
    {
        // Fields (altijd private)
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        // Dit is de contructor. Heeft altijd dezelfde naam als de class
        public PyramidPanic()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // Verandert de titel van het canvas
            Window.Title = "Pyramid Panic Beta 00.00.00.01";

            // Maak de muis zichtbaar
            IsMouseVisible = true;
            
            // Verandert de breedte van het canvas
            this.graphics.PreferredBackBufferWidth = 640;
           
            // Verandert de hoogte van het canvas
            this.graphics.PreferredBackBufferHeight = 480;

            // Past de nieuwe hoogte en breedte toe.
            this.graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Een spritebatch is nodig voor het tekenen van textures op het canvas
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            // Zorgt dat het spel stopt wanneer je  op de gamepad button back indrukt
            if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) || 
                (Keyboard.GetState().IsKeyDown(Keys.Escape)))
                this.Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Geeft de achtergrondkleur
            GraphicsDevice.Clear(Color.Firebrick);
            base.Draw(gameTime);
        }
    }
}
