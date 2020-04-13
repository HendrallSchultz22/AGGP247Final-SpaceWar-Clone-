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
    class Torpedo : BaseGameObject
    {
        private Sprite TorpedoSprite;
        
        public float MovementSpeed;

        public Torpedo()
        {
           
        }

        public override void InitalizeObject()
        {
            TorpedoSprite = new Sprite("torpedo");
            TorpedoSprite.scale = .15f;
            TorpedoSprite.origin.X = TorpedoSprite.texture.Width / 2;
            TorpedoSprite.origin.Y = TorpedoSprite.texture.Height / 2;

            MovementSpeed = 70f;

            Velocity = LinePrimatives.AngleToV2(Rotation, MovementSpeed);

            RectCollison = new Rectangle(0, 0, TorpedoSprite.texture.Width, TorpedoSprite.texture.Height);

        }

        public override void Update(GameTime gameTime)
        {
            RectCollison.Location = Position.ToPoint();

            //**** This won't work
            // check against everythign in the scene list instead. 
            foreach (BaseGameObject go in GameApp.instance.InGameList)
            {
                if (RectCollison.Contains(go.RectCollison))
                {
                    if(owner != go)
                    {
                        Destroy();
                    }
                }
            }
        

            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            TorpedoSprite.position = Position;
            TorpedoSprite.Draw(spriteBatch);
        }


    }
}
