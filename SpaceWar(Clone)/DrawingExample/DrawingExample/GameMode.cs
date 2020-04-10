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
//	- Extra Credit for More players
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
        Grid2D theGrid;

        // #### HUD ####
        HUD hud;

        public Sprite BigRedShip;
        public Sprite BigBlueShip;
        public Sprite Starfield;

        Vector2 Player1Loc = new Vector2(80, 500);
        Vector2 Player2Loc = new Vector2(1220, 465);
        public bool is1Filled = false;
        public bool is2Filled = false;
        public float HitBox = 86;

       // public List<BaseGameObject> InGameList;
        //public List<BaseGameObject> DestroyObjectList;

        /// <summary>
        /// Public contstructor... Does need to do anything at all. Those are the best constructors. 
        /// </summary>
        public GameMode()
        {
            //InGameList = new List<BaseGameObject>();
            //DestroyObjectList = new List<BaseGameObject>();
        }

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

            BigRedShip = new Sprite("BigRed");
            BigRedShip.scale = .2f;
            BigRedShip.position = Player2Loc;
            BigRedShip.origin.X = BigRedShip.texture.Width / 2;
            BigRedShip.origin.Y = BigRedShip.texture.Height / 2;


            BigBlueShip = new Sprite("BigBlue");
            BigBlueShip.scale = .2f;
            BigBlueShip.position = Player1Loc;
            BigBlueShip.origin.X = BigBlueShip.texture.Width / 2;
            BigBlueShip.origin.Y = BigBlueShip.texture.Height / 2;


            Starfield = new Sprite("Space");
            Starfield.scale = 2f;
            Starfield.position = new Vector2(1640, 1480);
            Starfield.origin.X = Starfield.texture.Width;
            Starfield.origin.Y = Starfield.texture.Height;
        }

        public void TorpedoShot1(GameTime gameTime)
        {
            Torpedo T = new Torpedo();
            T.Position = BigBlueShip.position;
            T.Velocity = LinePrimatives.AngleToV2(MathHelper.ToDegrees(BigBlueShip.rotation), T.MovementSpeed);
        }

        public void TorpedoShot2(GameTime gameTime)
        {
            Torpedo T = new Torpedo();
            T.Position = BigRedShip.position;
            T.Velocity = LinePrimatives.AngleToV2(MathHelper.ToDegrees(BigRedShip.rotation), T.MovementSpeed);
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
            float condition = (Player2Loc - Player1Loc).Length();
            
            if(condition < HitBox)
            {
                is1Filled = true;
                is2Filled = true;
            }
            else
            {
                is1Filled = false;
                is2Filled = false;
            }

            

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            int deltaScrollWheel = mousePrevious.ScrollWheelValue - mouseCurrent.ScrollWheelValue; 
            if (deltaScrollWheel != 0)
            {
                theGrid.GridSize += (Math.Abs(deltaScrollWheel) / deltaScrollWheel) * 2; 
            }

            //mouseCurrent.MiddleButton
            if (MouseButtonIsPressed("MiddleButton"))
            {
                theGrid.Origin = mouseCurrent.Position.ToVector2(); 
            }

            //BigRedShip Controls.
            if (IsKeyHeld(Keys.I) || IsKeyPressed(Keys.I))
            {
                BigRedShip.position.Y -= 10;
                Player2Loc.Y -= 10;
            }
            if (IsKeyHeld(Keys.K) || IsKeyPressed(Keys.K))
            {
                BigRedShip.position.Y += 10;
                Player2Loc.Y += 10;
            }
            if (IsKeyHeld(Keys.J) || IsKeyPressed(Keys.J))
            {
                BigRedShip.position.X -= 10;
                Player2Loc.X -= 10;
            }
            if (IsKeyHeld(Keys.L) || IsKeyPressed(Keys.L))
            {
                BigRedShip.position.X += 10;
                Player2Loc.X += 10;
            }
            if (IsKeyHeld(Keys.U) || IsKeyPressed(Keys.U))
            {
                BigRedShip.rotation -= 7 * (MathHelper.Pi / 180);
            }
            if (IsKeyHeld(Keys.O) || IsKeyPressed(Keys.O))
            {
                BigRedShip.rotation += 7 * (MathHelper.Pi / 180);
            }
            if (IsKeyPressed(Keys.Y))
            {
                TorpedoShot2(gameTime);
            }

            //BigBlueShip Controls.
            if (IsKeyHeld(Keys.W) || IsKeyPressed(Keys.W))
            {
                BigBlueShip.position.Y -= 10;
                Player1Loc.Y -= 10;
            }
            if (IsKeyHeld(Keys.S) || IsKeyPressed(Keys.S))
            {
                BigBlueShip.position.Y += 10;
                Player1Loc.Y += 10;
            }
            if (IsKeyHeld(Keys.A) || IsKeyPressed(Keys.A))
            {
                BigBlueShip.position.X -= 10;
                Player1Loc.X -= 10;
            }
            if (IsKeyHeld(Keys.D) || IsKeyPressed(Keys.D))
            {
                BigBlueShip.position.X += 10;
                Player1Loc.X += 10;
            }
            if (IsKeyHeld(Keys.Q) || IsKeyPressed(Keys.Q))
            {
                BigBlueShip.rotation -= 7 * (MathHelper.Pi / 180);
            }
            if (IsKeyHeld(Keys.E) || IsKeyPressed(Keys.E))
            {
                BigBlueShip.rotation += 7 * (MathHelper.Pi / 180);
            }
            if (IsKeyPressed(Keys.R))
            {
                TorpedoShot1(gameTime);
            }

            /*
            if (InGameList.Count > 0)
            {
                foreach (BaseGameObject Obj in InGameList)
                {
                    Obj.ObjectUpdate(gameTime);
                }
            }

            if (DestroyObjectList.Count > 0)
            {
                foreach (BaseGameObject Obj in DestroyObjectList)
                {
                    InGameList.Remove(Obj);
                }
                DestroyObjectList.Clear();
            }
           */
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
           
            LinePrimatives.DrawCircle(spriteBatch, 3f, Color.Transparent, Player2Loc, 60, 24);
            LinePrimatives.DrawCircle(spriteBatch, 3f, Color.Transparent, Player1Loc, 60, 24);
            BigRedShip.Draw(spriteBatch);
            BigBlueShip.Draw(spriteBatch);
            if (is1Filled)
            {
                LinePrimatives.DrawSolidCircle(spriteBatch, Color.DarkRed, Player2Loc, HitBox);
            }
            if (is2Filled)
            {
                LinePrimatives.DrawSolidCircle(spriteBatch, Color.DarkRed, Player1Loc, HitBox);
            }
            
        }

       

        protected override void HudDraw(GameTime gameTime)
        {
            // ######
            // This is where you are drawing your Hud Elements. 

            // Your Original Code 
            /*
            spriteBatch.DrawString(New, "Cartoonship Position: " + VectorToString(BigRedShip.position), new Vector2(10, 5), Color.Azure);
            spriteBatch.DrawString(New, "Rocketship Position: " + VectorToString(RocketShip.position), new Vector2(10, 30), Color.Azure);
            */
            // #### HUD ####
            // Your original code has been replaced with a call to the HUD Class... 
            hud.Draw(spriteBatch);

        }
    }
}
