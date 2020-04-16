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

        bool ThrustersActive1 = true;
        bool ThrustersActive2 = true;

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
            ClearScene(); 

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
                
                if(SunOn == true)
                {
                    SunOn = false;
                    player1.PlaceSun();
                    
                }
                      
            }

            
            //BigBlueShip Controls.
            if (IsKeyPressed(Keys.W))
            {
                if (ThrustersActive1)
                {
                    var direction = new Vector2((float)Math.Cos(player1.Rotation), (float)Math.Sin(player1.Rotation));
                    player1.Velocity += direction * player1.Force;
                    ThrustersActive1 = false;
                    if (ThrustersActive1 == false)
                    {
                        float currentTime = 0f;
                        currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
                        if (currentTime > 5)
                        {
                            ThrustersActive1 = true;
                            currentTime = 0;
                        }
                       
                    }
                }
            }
            if (IsKeyPressed(Keys.Q))
            {
                player1.Rotation -= 15 * (MathHelper.Pi / 180);
            }
            if (IsKeyPressed(Keys.E))
            {
                player1.Rotation += 15 * (MathHelper.Pi / 180);
            }
            if (IsKeyPressed(Keys.R))
            {
                //Console.WriteLine("P1 - Shoot");
                player1.ShootTorpedo();
            }


            //BigRedShip Controls.
            if (IsKeyPressed(Keys.I))
            {
                if (ThrustersActive2)
                {
                    var direction = new Vector2((float)Math.Cos(player2.Rotation), (float)Math.Sin(player2.Rotation));
                    player2.Velocity += direction * player2.Force;
                    ThrustersActive2 = false;
                    if(ThrustersActive2 == false)
                    {
                        int count = 0;
                        float currentTime = 0f;
                        float duration = 0f;
                        currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
                        if(currentTime >= duration)
                        {
                            count++;
                        }
                        if(count >= 5)
                        {
                            ThrustersActive2 = true;
                            count = 0;
                            
                        }
                    }
                }
                
            }
            if (IsKeyPressed(Keys.U))
            {
                player2.Rotation -= 7 * (MathHelper.Pi / 180);
            }
            if (IsKeyPressed(Keys.O))
            {
                player2.Rotation += 7 * (MathHelper.Pi / 180);
            }
            if (IsKeyPressed(Keys.Y))
            {
                //Console.WriteLine("P2 - Shoot");
                player2.ShootTorpedo();
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
            if(player1.isActive == false && player2.isActive == true)
            {
                spriteBatch.DrawString(New, "Player 2 is the Winner! " ,
                new Vector2(550, 400), Color.Azure);
                
            }
            if (player2.isActive == false && player1.isActive == true)
            {
                spriteBatch.DrawString(New, "Player 1 is the Winner! ",
                new Vector2(550, 400), Color.Azure);
            }
            if(player1.isActive == false && player2.isActive == false)
            {
                spriteBatch.DrawString(New, "Its a Tie!! ",
                new Vector2(550, 400), Color.Azure);
            }

        }
    }
}
