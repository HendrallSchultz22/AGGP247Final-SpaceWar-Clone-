using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LineDraw;

namespace DrawingExample
{
    class PlanetObsticleClass : BaseGameObject
    {
        private Sprite SunSprite;

        public Vector2 SunPos;
    
        public PlanetObsticleClass()
        {
            
        }
        public override void InitalizeObject()
        {
            SunSprite = new Sprite("Sun");
            SunSprite.scale = .25f;
            SunSprite.origin.X = SunSprite.texture.Width / 2;
            SunSprite.origin.Y = SunSprite.texture.Height / 2;

            Collison = new Rectangle(0, 0, SunSprite.texture.Width, SunSprite.texture.Height);

            SunPos = new Vector2(ScreenSize.X / 2, ScreenSize.Y / 2);

        }

        public override void Update(GameTime gameTime)
        {
            Collison.Location = SunPos.ToPoint();
           



        }

       /* public override void Draw(SpriteBatch spriteBatch)
        {
            SunSprite.position = SunPos;
            SunSprite.Draw(spriteBatch);
        }*/
    }
}
