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
    public class StartScene : IState //de class startscene implementeert de interface IState
    {
        //FieldAccessException van decimal class StartScene
        private PyramidPanic game;

        // twee nieuwe instaties Background, title Gemaakt.
        private Image background;
        private Image title;

        //Maak een variabele (reference) aan van de Menu class genaamd menu
        private Menu menu;

        // Constructor van StartScene-class krijgt een object game mee van het type PyramidPanic
        public StartScene(PyramidPanic game)
        {
            this.game = game;

            //roep de initialize method aan
            this.initialize();
        }

        //initialize methode. Deze methode initialiseert (geeft startwaarden aan variabelen)
        //void wil zeggen dat er niets teruggegeven wordt.
        public void initialize()
        {
            //roep de loadcontent method aan
            this.LoadContent();
        }

        //loadcontent methode. Deze methode maakt nieuwe objecten aan van de verschillende
        //classes.
        public void LoadContent()
        {
            // nu maken we een object aan (instantie van de class Image)
            this.background = new Image(this.game, @"StartScene\Background", Vector2.Zero);
            this.title = new Image(this.game, @"StartScene\Title", new Vector2(100f, 30f));
            this.menu = new Menu(this.game);
        }

        //update methode. Deze methode wordt normaal 60 maal per seconde aangeroepen.
        //en update alle variabelen, methods enz...
        public void Update(GameTime gameTime)
        {
            this.menu.Update(gameTime);
        }

        //draw methode. Deze methode wordt normaal 60 maal per seconde aangeroepen en 
        // tekent de textures op het canvas
        public void Draw(GameTime gameTime)
        {
            this.game.GraphicsDevice.Clear(Color.DarkOrange);

            //Roep de draw method aan van het beackground object
            this.background.Draw(gameTime);

            //rRoep de Draw method aan van het title object
            this.title.Draw(gameTime);

            //Roep de draw method aan van het menu object
            this.menu.Draw(gameTime);
        }

    }
}