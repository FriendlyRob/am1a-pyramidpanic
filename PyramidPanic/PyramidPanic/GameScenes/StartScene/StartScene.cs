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
    public class StartScene : IState // De class StartScene implementeert de interface IState
    {
        // Fields can de class StartScene
        private PyramidPanic game;

        // Maak een variabele (reference) aan van de Image class genaamd background
        private Image background;

        // Maak een variabele (reference) aan van de Image class genaamd title
        private Image title;

        // Maak een variabele (reference) aan van de Menu class genaamd menu
        private Menu menu;

        // Contructor van de StartScene-class krijgt een object mee van het type PyramidPanic
        public StartScene(PyramidPanic game)
        {
            this.game = game;

            // Roep de Initialize method aan
            this.Initialize();
        }

        // Initialize mehode. Deze methode initialiseert (geeft startwaarden aan variabelen)
        // Void will zeggen dat er niets teruggegeven wordt
        public void Initialize()
        {
            // Roep de LoadContent methode aan
            this.LoadContent();
        }

        // LoadContent methode. Deze methode maakt nieuwe objecten aan van de verschillende classes
        public void LoadContent()
        {
            // Nu maken we twee objecten (instantie) van de class Image
            this.background = new Image(this.game, @"StartScene\Background", Vector2.Zero);
            this.title = new Image(this.game, @"StartScene\Title", new Vector2(100f, 30f));
            this.menu = new Menu(this.game);
        }

        // Update methode. Deze methode wordt normaal 60 keer per seconde aangeroepen.
        // en update alle variabelen, methods enz......
        public void Update(GameTime gametime)
        {
            if (Input.EdgeDetectKeyDown(Keys.Right) || Input.EdgeDetectMousePressLeft())
            {
                this.game.IState = this.game.PlayScene;
            }
            if (Input.EdgeDetectKeyDown(Keys.Left))
            {
                this.game.IState = this.game.GameOverScene;
            }
            menu.Update(gametime);
        }

        // Draw methode. Deze methode word normaal 60 keer per seconde aangeroepen.
        // En tekent de textures op het canvas.
        public void Draw(GameTime gametime)
        {
            this.game.GraphicsDevice.Clear(Color.YellowGreen);

            // Roep de Draw methode aan van het background object
            this.background.Draw(gametime);

            // Roep de Draw methode aan van het title object
            this.title.Draw(gametime);

            // Roep de Draw methode aan van het menu object
            this.menu.Draw(gametime);
        }
    }
}
