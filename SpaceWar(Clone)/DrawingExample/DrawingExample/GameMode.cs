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

        public Vector2 Player1StartLoc = new Vector2(80, 500);
        public Vector2 Player2StartLoc = new Vector2(1220, 465);

        

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

            player1 = new PlayerClass();
            player1.SetupPlayer1();
            player1.Position = Player1StartLoc;

            player2 = new PlayerClass();
            player2.SetupPlayer2();
            player2.Position = Player2StartLoc;


            


            Starfield = new Sprite("Space");
            Starfield.scale = 2f;
            Starfield.position = new Vector2(1640, 1480);
            Starfield.origin.X = Starfield.texture.Width;
            Starfield.origin.Y = Starfield.texture.Height;
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
                
                if(SunOn == true)
                {
                    SunOn = false;
                    player1.PlaceSun();
                    
                }
                      
            }


            //BigBlueShip Controls.
            if (IsKeyHeld(Keys.W) || IsKeyPressed(Keys.W))
            {
                player1.Position.Y -= 10;
            }
            if (IsKeyHeld(Keys.S) || IsKeyPressed(Keys.S))
            {
                player1.Position.Y += 10;
            }
            if (IsKeyHeld(Keys.A) || IsKeyPressed(Keys.A))
            {
                player1.Position.X -= 10;
            }
            if (IsKeyHeld(Keys.D) || IsKeyPressed(Keys.D))
            {
                player1.Position.X += 10;
            }
            if (IsKeyHeld(Keys.Q) || IsKeyPressed(Keys.Q))
            {
                player1.Rotation -= 7 * (MathHelper.Pi / 180);
            }
            if (IsKeyHeld(Keys.E) || IsKeyPressed(Keys.E))
            {
                player1.Rotation += 7 * (MathHelper.Pi / 180);
            }
            if (IsKeyPressed(Keys.R))
            {
                //Console.WriteLine("P1 - Shoot");
                player1.ShootTorpedo(0);
            }


            //BigRedShip Controls.
            if (IsKeyHeld(Keys.I) || IsKeyPressed(Keys.I))
            {
                player2.Position.Y -= 10;
            }
            if (IsKeyHeld(Keys.K) || IsKeyPressed(Keys.K))
            {   
                player2.Position.Y += 10;
            }
            if (IsKeyHeld(Keys.J) || IsKeyPressed(Keys.J))
            {
                player2.Position.X -= 10;
            }
            if (IsKeyHeld(Keys.L) || IsKeyPressed(Keys.L))
            {
                player2.Position.X += 10;
            }
            if (IsKeyHeld(Keys.U) || IsKeyPressed(Keys.U))
            {
                player2.Rotation -= 7 * (MathHelper.Pi / 180);
            }
            if (IsKeyHeld(Keys.O) || IsKeyPressed(Keys.O))
            {
                player2.Rotation += 7 * (MathHelper.Pi / 180);
            }
            if (IsKeyPressed(Keys.Y))
            {
                //Console.WriteLine("P2 - Shoot");
                player2.ShootTorpedo(15.7f);
            }

           
        
            // #### HUD ####
            hud.Update(gameTime); 
             

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
            // ######
            // This is where you are drawing your Hud Elements. 
            // #### HUD ####
            // Your original code has been replaced with a call to the HUD Class... 
            hud.Draw(spriteBatch);

        }
    }
}
