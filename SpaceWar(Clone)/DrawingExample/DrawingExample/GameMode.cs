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

        PlayerClass player;

        public Sprite Starfield;

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

            player = new PlayerClass();
            
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
            //BigRedShip Controls.
            if (IsKeyHeld(Keys.I) || IsKeyPressed(Keys.I))
            {
                PlayerClass.instance.BigRedShip.position.Y -= 10;
                PlayerClass.instance.Player2Loc.Y -= 10;
            }
            if (IsKeyHeld(Keys.K) || IsKeyPressed(Keys.K))
            {
                PlayerClass.instance.BigRedShip.position.Y += 10;
                PlayerClass.instance.Player2Loc.Y += 10;
            }
            if (IsKeyHeld(Keys.J) || IsKeyPressed(Keys.J))
            {
                PlayerClass.instance.BigRedShip.position.X -= 10;
                PlayerClass.instance.Player2Loc.X -= 10;
            }
            if (IsKeyHeld(Keys.L) || IsKeyPressed(Keys.L))
            {
                PlayerClass.instance.BigRedShip.position.X += 10;
                PlayerClass.instance.Player2Loc.X += 10;
            }
            if (IsKeyHeld(Keys.U) || IsKeyPressed(Keys.U))
            {
                PlayerClass.instance.BigRedShip.rotation -= 7 * (MathHelper.Pi / 180);
            }
            if (IsKeyHeld(Keys.O) || IsKeyPressed(Keys.O))
            {
                PlayerClass.instance.BigRedShip.rotation += 7 * (MathHelper.Pi / 180);
            }
            if (IsKeyPressed(Keys.Y))
            {
                PlayerClass.instance.TorpedoShot2(gameTime);
            }

            //BigBlueShip Controls.
            if (IsKeyHeld(Keys.W) || IsKeyPressed(Keys.W))
            {
                PlayerClass.instance.BigBlueShip.position.Y -= 10;
                PlayerClass.instance.Player1Loc.Y -= 10;
            }
            if (IsKeyHeld(Keys.S) || IsKeyPressed(Keys.S))
            {
                PlayerClass.instance.BigBlueShip.position.Y += 10;
                PlayerClass.instance.Player1Loc.Y += 10;
            }
            if (IsKeyHeld(Keys.A) || IsKeyPressed(Keys.A))
            {
                PlayerClass.instance.BigBlueShip.position.X -= 10;
                PlayerClass.instance.Player1Loc.X -= 10;
            }
            if (IsKeyHeld(Keys.D) || IsKeyPressed(Keys.D))
            {
                PlayerClass.instance.BigBlueShip.position.X += 10;
                PlayerClass.instance.Player1Loc.X += 10;
            }
            if (IsKeyHeld(Keys.Q) || IsKeyPressed(Keys.Q))
            {
                PlayerClass.instance.BigBlueShip.rotation -= 7 * (MathHelper.Pi / 180);
            }
            if (IsKeyHeld(Keys.E) || IsKeyPressed(Keys.E))
            {
                PlayerClass.instance.BigBlueShip.rotation += 7 * (MathHelper.Pi / 180);
            }
            if (IsKeyPressed(Keys.R))
            {
                PlayerClass.instance.TorpedoShot1(gameTime);
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
            player.Draw(spriteBatch);
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
