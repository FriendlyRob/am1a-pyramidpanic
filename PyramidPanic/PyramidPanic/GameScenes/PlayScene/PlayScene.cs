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
    public class PlayScene : IState
    {
        //Fields van de class PlayScene
        private PyramidPanic game;
        // 2 beetle objecten aangemaakt (gesepereert door ee nkomma on het netter te laten uitzien)
        private Beetle beetle, beetle1;
        // 2 scorpion objecten aangemaakt (gesepereert door ee nkomma on het netter te laten uitzien)  
        private Scorpion scorpion, scorpion1;
        // De exporer is de main character die je bestuurt
        private Explorer explorer;
        // 2 block objecten aangemaakt (gesepereert door ee nkomma on het netter te laten uitzien)
        private Block block1, block2;

        // Constructor van de StartScene-class krijgt een object game mee van het type PyramidPanic
        public PlayScene(PyramidPanic game)
        {
            this.game = game;
            this.Initialize();
        }

        // Initialize methode. Deze methode initialiseert (geeft startwaarden aan variabelen).
        // Void wil zeggen dat er niets teruggegeven wordt.
        public void Initialize()
        {
            this.LoadContent();
        }

        // LoadContent methode. Deze methode maakt nieuwe objecten aan van de verschillende
        // classes.
        public void LoadContent()
        {
            //hier is een lijst met alle gegevens van alle objecten en de bijbehoorende gegevens
            // van : beetle + beetle1+scorpion+scorpion+scorpion1+explorer+block1+block2
            this.beetle = new Beetle(this.game, new Vector2(100f, 300f));
            this.beetle1 = new Beetle(this.game, new Vector2(400f, 100f));
            this.scorpion = new Scorpion(this.game, new Vector2(300f, 188f));
            this.scorpion1 = new Scorpion(this.game, new Vector2(188f, 300f));
            this.explorer = new Explorer(this.game, new Vector2(304f, 240f));
            this.block1 = new Block(this.game, @"Block\Block", new Vector2(0f, 0f));
            this.block2 = new Block(this.game, @"Block\Block", new Vector2(64f, 64f));
        }

        // Update methode. Deze methode wordt normaal 60 maal per seconde aangeroepen.
        // en update alle variabelen, methods enz.......
        public void Update(GameTime gameTime)
        {
            // Hier is het indrukken van de B knop het switchen naar de Istate startscene
            if (Input.EdgeDetectKeyDown(Keys.B))
            {
                this.game.IState = this.game.StartScene;
            }
            // hier roep ik alle update methods aan mooi in een rijtje onder elkaar, deze zullen updaten in de playscene
            this.beetle.Update(gameTime);
            this.beetle1.Update(gameTime);
            this.scorpion.Update(gameTime);
            this.scorpion1.Update(gameTime);
            this.explorer.Update(gameTime);
            
        }

        // Draw methode. Deze methode wordt normaal 60 maal per seconde aangeroepen en
        // tekent de textures op het canvas
        public void Draw(GameTime gameTime)
        {
            // Hier zijn alle draw methods (zonder de draw methods komt er niks in beeld te staan tijdens de playscene)
            this.game.GraphicsDevice.Clear(Color.Pink);
            // Alle individuele beetles draw methods moeten appart worden aangeroepen. 
            this.beetle.Draw(gameTime);
            this.beetle1.Draw(gameTime);
            // Alle individuele scorpion draw methods moeten appart worden aangeroepen. 
            this.scorpion.Draw(gameTime);
            this.scorpion1.Draw(gameTime);
            // Hier is de draw method van de main char
            this.explorer.Draw(gameTime);
            // Alle individuele block draw methods moeten appart worden aangeroepen. 
            this.block1.Draw(gameTime);
            this.block2.Draw(gameTime);
        }
    }
}
