using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LineDraw;

namespace DrawingExample
{

    public class HUD
    {
        SpriteFont drawFont;
        string CartoonVector = "";
        string RocketVector = "";

        public HUD()
        {
            Initalize(); 
        }

        public void Initalize()
        {
            drawFont = GameMode.instance.Content.Load<SpriteFont>("THEFONT");
        }

        // Copying from GameMode for Consistant formatting... 
        public string VectorToString(Vector2 v)
        {
            string result = "";

            result = "X: (" + v.X.ToString("F1") + ") " + ", Y: (" + v.Y.ToString("F1") + ") ";

            return result;
        }

        public void Update(GameTime gameTime)
        {

            RocketVector  = VectorToString( ((GameMode)GameMode.instance).RocketShip.position);
            CartoonVector = VectorToString( ((GameMode)GameMode.instance).BigRedShip.position);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(drawFont, "Cartoonship Position: " + CartoonVector,
                new Vector2(10, 5), Color.Azure);
            spriteBatch.DrawString(drawFont, "Rocketship Position: " + RocketVector
                , new Vector2(10, 30), Color.Azure);
        }
    }


}
