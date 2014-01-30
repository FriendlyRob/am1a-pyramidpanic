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
    public class Beetle : IAnimatedSprite
    {
        //Fields
        private PyramidPanic game;
        // Ientety variabele
        private IEntityState state;
        // Texture variabele (nodig voor de sprite)
        private Texture2D texture;
        // Speed = snelheid van de beetle
        private int speed = 2;
        // De positie van de beetle
        private Vector2 position;

        //Maak van iedere toestand (state) een field 
        // In dit geval zijn de toestanden: walkUp en walkDown
        private WalkUp walkUp;
        private WalkDown walkDown;

        //properties
        // WalkUP
        public WalkUp WalkUp
        {
            get { return this.walkUp; }
        }
        // WalkDown
        public WalkDown WalkDown
        {
            get { return this.walkDown; }
        }
        // Position hier is ook een setter bij
        public Vector2 Position
        {
            get { return this.position; }
            set { this.position = value; }
        }
        // Ientety (state)
        public IEntityState State
        {
            set { this.state = value; }
        }
        // game
        public PyramidPanic Game
        {
            get { return this.game; }
        }
        // Speed (snelheid die de beetle beweegt)
        public int Speed
        {
            get { return this.speed; }
        }
        // Texture (voor de sprite)
        public Texture2D Texture
        {
            get { return this.texture; }
        }
        
        //Constructor
        public Beetle(PyramidPanic game, Vector2 position)
        {
            // Hier zijn alle dingen die met de constructor van de beetle worden meegegeven
            this.game = game;
            this.position = position;
            // @"Beetle\Beetle" is de weg naar het plaatje
            this.texture = game.Content.Load<Texture2D>(@"Beetle\Beetle");
            // Walkup en walkdown:
            // De beetle loopt alleen omhoog en omlaag
            this.walkUp = new WalkUp(this);
            this.walkDown = new WalkDown(this);
            // De beginstate van de beetle is walkup in dit geval
            // Het maakt niet uit in welke state het begint maar er moet wel een als startwaarde worden opgegeven
            this.state = this.walkUp;
        }

        //Update
        public void Update(GameTime gameTime)
        {
           // De updatefunctie can de state
           this.state.Update(gameTime);
        }

        //Draw
        public void Draw(GameTime gameTime)
        {
            // Draw (zonder drag geen beetle te zien)
            this.state.Draw(gameTime);                   
        }
    }
}
