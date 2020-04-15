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
        public Vector2 SunPos;
    
        public PlanetObsticleClass()
        {
            
        }
        
        public override void InitalizeObject()
        {
            sprite = new Sprite("Sun");
            sprite.scale = .2f;
            sprite.origin.X = sprite.texture.Width / 2;
            sprite.origin.Y = sprite.texture.Height / 2;

            SunPos = new Vector2(ScreenSize.X / 2, ScreenSize.Y / 2);

            Collison = new Rectangle(0, 0, (int)(sprite.texture.Width  * sprite.scale), (int)(sprite.texture.Height * sprite.scale));

           

        }

        public override void Update(GameTime gameTime)
        {
            foreach (BaseGameObject go in GameApp.instance.InGameList)
            {
               

                ///Console.WriteLine("*****"); 

                if (Collison.Intersects(go.Collison))
                {
                    go.TakeDamage(1f);
                }
            }

            foreach (BaseGameObject go in GameApp.instance.InGameList)
            {
                if(go.Position.X >= this.Position.X)
                {
                    if (go.Equals(owner)||go.Equals(this))
                    {
                        go.owner.Velocity.X = 0;
                    }
                    else
                    {
                        go.Velocity += Gravity;
                    }
                    
                }

            }

        }
       
        
    }
}
