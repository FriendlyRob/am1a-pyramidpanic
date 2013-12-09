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
    public class Menu
    {
        // Fields
        // Maak een variabele (reference) van het type Image
        private Image start;
        private Image load;
        private Image help;
        private Image scores;
        private Image quit;

        // Maak een variabele (reference) van het type PyramidPanic
        private PyramidPanic game;

        // Constructor
        public Menu(PyramidPanic game)
        {
            this.game = game;
            this.Initialize();          
        }

        public void Initialize()
        {
            this.LoadContent();
        }

        public void LoadContent()
        {
            this.start = new Image(this.game, @"StartScene\Button_start", new Vector2(20f, 430f));
            this.load = new Image(this.game, @"StartScene\Button_load", new Vector2(140f, 430f));
            this.help = new Image(this.game, @"StartScene\Button_help", new Vector2(260f, 430f));
            this.scores = new Image(this.game, @"StartScene\Button_scores", new Vector2(380f, 430f));
            this.quit = new Image(this.game, @"StartScene\Button_quit", new Vector2(500f, 430f));
        }

        // Update
        public void Update(GameTime gameTime)
        {

        }

        // Draw
        public void Draw(GameTime gameTime)
        {
            this.start.Draw(gameTime);
            this.load.Draw(gameTime);
            this.help.Draw(gameTime);
            this.scores.Draw(gameTime);
            this.quit.Draw(gameTime);
        }
    }
}
