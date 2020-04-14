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
       
        public float MovementSpeed;
        
        public override void InitalizeObject()
        {
            sprite = new Sprite("torpedo");
            sprite.scale = .15f;
            sprite.origin.X = sprite.texture.Width / 2;
            sprite.origin.Y = sprite.texture.Height / 2;

            MovementSpeed = 70f;

            Velocity = LinePrimatives.AngleToV2(Rotation, MovementSpeed);

            Collison = new Rectangle(0, 0,(int) (sprite.texture.Width * sprite.scale), (int)(sprite.texture.Height * sprite.scale));

        }

        public override void Update(GameTime gameTime)
        {

            // check against everythign in the scene list instead. 
            foreach (BaseGameObject go in GameApp.instance.InGameList)
            {
                if ( go.Equals(owner) || go.Equals(this) )
                {
                    continue; 
                }

                ///Console.WriteLine("*****"); 
                        
                if (Collison.Intersects(go.Collison))
                {
                        Destroy();
                   
                }
            }
        

            
        }

        /*
        public override void Draw(SpriteBatch spriteBatch)
        {
            sprite.position = Position;
            sprite.rotation = Rotation;
            sprite.Draw(spriteBatch);

            // Debug
            LinePrimatives.DrawRectangle(spriteBatch, 5, Color.Red, Collison);

        }
        */


    }
}
