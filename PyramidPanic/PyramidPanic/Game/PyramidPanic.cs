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

        // Maak een variabele aan van het type StartScene
        private StartScene startScene;

        // Maak een variabele aan van het type PlayScene
        private PlayScene playScene;

        // Maak een variabele aan van het type HelpScene
        private HelpScene helpScene;

        // Maak een variabele aan van het type GameOverScene
        private GameOverScene gameOverScene;

        // Maak een variabele aan van het type IState
        private IState iState;

        #region Properties
        // Properties
        // Maak de interface variabelen iState beschikbaar buiten de class d.m.v.
        // een property IState
        public IState IState
        {
            get { return this.iState; }
            set { this.iState = value; }
        }

        // Maak het field this.startScene beschikbaar buiten de class d.m.v. een
        // property StartScene
        public StartScene StartScene
        {
            get { return this.startScene; }
        }

        // Maak het field this.playScene beschikbaar buiten de class d.m.v. een
        // property PlayScene
        public PlayScene PlayScene
        {
            get { return this.playScene; }
        }

        // Maak het field this.helpScene beschikbaar buiten de class d.m.v. een
        // property HelpScene
        public HelpScene HelpScene
        {
            get { return this.helpScene; }
        }

        // Maak het field this.gameOverScene beschikbaar buiten de class d.m.v. een
        // property GameOverScene
        public GameOverScene GameOverScene
        {
            get { return this.gameOverScene; }
        } 
        #endregion

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

            // We maken nu het object/instantie aan van het type startScene. Dit doe je door
            // de constructor aan te roepen van de StartScene class.
            this.startScene = new StartScene(this);

            // We maken nu het object/instantie aan van het type playScene. Dit doe je door
            // de constructor aan te roepen van de PlayScene class.
            this.playScene = new PlayScene(this);

            // We maken nu het object/instantie aan van het type helpScene. Dit doe je door
            // de constructor aan te roepen van de helpScene class.
            this.helpScene = new HelpScene(this);

            // We maken nu het object/instantie aan van het type gameoverScene. Dit doe je door
            // de constructor aan te roepen van de gameoverscene class.
            this.gameOverScene = new GameOverScene(this);
            
            this.iState = this.startScene;
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

            // De Update methode van het object dat toegewezen is aan het interface-object
            // this.iState wort aangeroepen
            this.iState.Update(gameTime);
            Input.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Geeft de achtergrondkleur
            GraphicsDevice.Clear(Color.Firebrick);

            // Voor een spritebatch instantie iets kan tekenen moet de Begin() methode aangeroepen worden van de spritebatch
            this.spriteBatch.Begin();

            // De Draw methode van het object dat toegewezen is aan het interface-object
            // this.iState wort aangeroepen
            this.iState.Draw(gameTime);

            // Nadat de spritebatch.Draw() is aangeroepen moet de End() methode van de
            // Spritebatch class worden aangeroepen
            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
