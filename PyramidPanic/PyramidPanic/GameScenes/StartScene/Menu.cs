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
        // 0    1   2   3   4
        // Maak een enumeration voor de buttons die op het scherm te zien zijn
        private enum Buttons { Start, Load, Help, Scores, Quit }

        // Maak een variabele van het type Buttons en geef hem de waarde Buttons.Start
        private Buttons buttonActive = Buttons.Start;

        // Maak een variabele (reference) van het type Image
        private Image start, load, help, scores, quit;

        // Maak een variabele (reference) van het type PyramidPanic
        private PyramidPanic game;

        // Maak een variabele aan activeColor. Dit is de kleur van de actieve knop
        private Color activeColor = Color.Gold;

        // Maak een variabele van het type list<Image>
        private List<Image> buttonList;


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
            // Maak een instantie aan van de List<Image> type en stop deze in de variabele this.buttonlist
            this.buttonList = new List<Image>();
            this.buttonList.Add(this.start = new Image(this.game, @"StartScene\Button_start", new Vector2(20f, 430f)));
            this.buttonList.Add(this.load = new Image(this.game, @"StartScene\Button_load", new Vector2(140f, 430f)));
            this.buttonList.Add(this.help = new Image(this.game, @"StartScene\Button_help", new Vector2(260f, 430f)));
            this.buttonList.Add(this.scores = new Image(this.game, @"StartScene\Button_scores", new Vector2(380f, 430f)));
            this.buttonList.Add(this.quit = new Image(this.game, @"StartScene\Button_quit", new Vector2(500f, 430f)));          
        }

        // Update
        public void Update(GameTime gameTime)
        {      
            /* Deze if - instructie checked of er op de rechterpijltoets wordt gedrukt.
             * De actie die daarop volgt is het ophogen van de variabele buttonActive
             */
            if ((Input.EdgeDetectKeyDown(Keys.Right)) && (this.buttonActive != Buttons.Quit))
            {
                this.buttonActive++;
                this.ChangeButtonColorToNormal();
            }

            /* Deze if - instructie checked of er op de linkerpijltoets wordt gedrukt.
             * De actie die daarop volgt is het verlagen van de variabele buttonActive
             */
            if ((Input.EdgeDetectKeyDown(Keys.Left)) && (this.buttonActive != Buttons.Start))
            {
                this.buttonActive--;
                this.ChangeButtonColorToNormal();
            }

            // Maak een switch case instructie voor de variabele buttonActive
            switch (this.buttonActive)
            {
                case Buttons.Start:
                    // De ternary operator: 
                    // variabele = (vergelijking) ? waarde als waar : waarde als niet waar;
                    this.game.IState = (Input.EdgeDetectKeyDown(Keys.Enter)) ? (IState)this.game.PlayScene : this.game.StartScene;
                    this.start.Color = this.activeColor;
                    break;
                case Buttons.Load:
                    if (Input.EdgeDetectKeyDown(Keys.Enter))
                    {
                        this.game.IState = this.game.LoadScene;
                    }
                    this.load.Color = this.activeColor;
                    break;
                case Buttons.Help:
                    this.help.Color = this.activeColor;
                    break;
                case Buttons.Scores:
                    if (Input.EdgeDetectKeyDown(Keys.Enter))
                    {
                        this.game.IState = this.game.ScoresScene;
                    }
                    this.scores.Color = this.activeColor;
                    break;
                case Buttons.Quit:
                    this.quit.Color = this.activeColor;
                    break;
            }  
        }

        // Draw
        public void Draw(GameTime gameTime)
        {
            foreach (Image image in this.buttonList)
            {
                image.Draw(gameTime);
            }
        }

        // Helper method voor het met wit beschijnen van de buttons
        private void ChangeButtonColorToNormal()
        {
            /* We doorlopen het this.buttonList object (type List<Image>)  met een foreach instructie
             * en we roepen voor ieder image-object de propertie Color op en geven deze de
             * waarde Color.White.
             */
            foreach (Image image in this.buttonList)
            {
                image.Color = Color.White;
            }
        }
    }
}
