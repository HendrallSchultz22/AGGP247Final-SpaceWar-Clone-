using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LineDraw;

namespace DrawingExample
{

    class HUD
    {
        SpriteFont drawFont;
        string BigRedVector = "";
        string BigBlueVector = "";

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

            BigBlueVector = VectorToString(((PlayerClass)PlayerClass.instance).BigBlueShip.position);
            BigRedVector = VectorToString(((PlayerClass)PlayerClass.instance).BigRedShip.position);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(drawFont, "BigRedship Position: " + BigRedVector,
                new Vector2(10, 30), Color.Azure);
            spriteBatch.DrawString(drawFont, "BigBlueship Position: " + BigBlueVector
                , new Vector2(10, 5), Color.Azure);
        }
    }


}
