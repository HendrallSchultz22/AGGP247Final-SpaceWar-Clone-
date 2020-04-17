using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LineDraw; 

namespace DrawingExample
{
// Option 2 - Space War Clone
//* Two players 
//* torpedo attacks 
//	- Touch on other object will Destroy other players or torpedoes
//* Playing field wraps
//* Must have a gravity source from the center of playfield
//* Option for placement of a planet or star in center of playfield
//	- Touch will destroy player or torpedo
//* Round ends when one player is destroyed
    class GameMode : GameApp
    {
        SpriteFont New;

        // #### HUD ####
        HUD hud;

        public PlayerClass player1;
        public PlayerClass player2;

        int P1Wins = 0;
        int P2Wins = 0;


        public Vector2 Player1StartLoc = new Vector2(80, 500);
        public Vector2 Player2StartLoc = new Vector2(1220, 465);

        public bool EndGameState = false;
        float EndGameWaitTime = 5.0f;  // in seconds 
        float EndGameWaitTimeCounter = 0f;
        string EndGameResultString = ""; 

        public Sprite Starfield;
        public bool SunOn = true;
        /// <summary>
        /// Public contstructor... Does need to do anything at all. Those are the best constructors. 
        /// </summary>
        public GameMode() :  base() { }

        protected override void Initialize()
        {
            base.Initialize();

            // Setting up Screen Resolution
            // Read more here: http://rbwhitaker.wikidot.com/changing-the-window-size
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 960;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();


            IsMouseVisible = true;


        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // TODO: use this.Content to load your game content here
            New = Content.Load<SpriteFont>("THEFONT");

            // #### HUD ####
            hud = new HUD();

            Starfield = new Sprite("Space");
            Starfield.scale = 2f;
            Starfield.position = new Vector2(1640, 1480);
            Starfield.origin.X = Starfield.texture.Width;
            Starfield.origin.Y = Starfield.texture.Height;

            SetupScene(); 
            
        }

        void SetupScene()
        {
            // Setting up Internals 
            ClearScene();
            EndGameState = false;
            EndGameWaitTimeCounter = 0f;
            EndGameResultString = "";


            player1 = new PlayerClass();
            player1.Rotation = 0;
            player1.SetupPlayer1();
            player1.Position = Player1StartLoc;

            player2 = new PlayerClass();
            player2.Rotation = 3.14f;
            player2.SetupPlayer2();
            player2.Position = Player2StartLoc;
        }
       
       
        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            // If you create textures on the fly, you need to unload them. 
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void GameUpdate(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            if (IsKeyReleased(Keys.Space))
            {

                if (SunOn == true)
                {
                    SunOn = false;
                    PlaceSun();

                }

            }


            //BigBlueShip Controls.
            if (IsKeyHeld(Keys.W))
            {
                player1.AddForce(gameTime);
            }
            if (IsKeyHeld(Keys.A))
            {
                player1.AddRotation(gameTime, -1f);
            }
            if (IsKeyHeld(Keys.D))
            {
                player1.AddRotation(gameTime, 1f);
            }
            if (IsKeyPressed(Keys.S))
            {
                //Console.WriteLine("P1 - Shoot");
                player1.ShootTorpedo();
            }


            //BigRedShip Controls.
            if (IsKeyHeld(Keys.I))
            {
                player2.AddForce(gameTime);
            }
            if (IsKeyHeld(Keys.J))
            {
                player2.AddRotation(gameTime, -1f);
            }
            if (IsKeyHeld(Keys.L))
            {
                player2.AddRotation(gameTime, 1f);
            }
            if (IsKeyPressed(Keys.K))
            {
                //Console.WriteLine("P2 - Shoot");
                player2.ShootTorpedo();
            }

            if (EndGameState)
            {
                EndGameWaitTimeCounter += (gameTime.ElapsedGameTime.Milliseconds / 1000.0f);
                if (EndGameWaitTimeCounter > EndGameWaitTime)
                {
                    
                    SetupScene();
                }
            }
            else // Check for a Winner
            {
                if (player1.isActive == false && player2.isActive == true)
                {
                    EndGameResultString = "Player 2 is the Winner! ";
                    P2Wins++; 
                    EndGameState = true;
                }

                if (player2.isActive == false && player1.isActive == true)
                {
                    EndGameResultString = "Player 1 is the Winner! ";
                    P1Wins++; 
                    EndGameState = true;
                }
            }


            // #### HUD ####
            hud.Update(gameTime); 
             

        }

        public void PlaceSun()
        {
            PlanetObsticleClass p = new PlanetObsticleClass();
            p.Position = p.SunPos;
            p.IgnoresDamage = true;
        }

        protected override void BackGroundDraw(GameTime gameTime)
        {
            Starfield.Draw(spriteBatch);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void GameDraw(GameTime gameTime)
        {
           
           
        }

       

        protected override void HudDraw(GameTime gameTime)
        {
           
            hud.Draw(spriteBatch);

            string P1 = "P1: " + P1Wins;
            string P2 = "P2: " + P2Wins;

            spriteBatch.DrawString(New, P1, new Vector2(250, 100), Color.Azure);
            spriteBatch.DrawString(New, P2, new Vector2(750, 100), Color.Azure);




            if (EndGameState)
            {
                spriteBatch.DrawString(New, EndGameResultString, new Vector2(550, 400), Color.Azure);
            }

        }
    }
}
