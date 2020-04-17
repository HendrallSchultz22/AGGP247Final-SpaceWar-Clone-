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
    class PlayerClass : BaseGameObject
    {
        public float Force = 60;
        public float RotationRate = 90;
        bool  ThrustersActive = true;
        float ThrusterReactivateTime = .25f;
        float ThrusterReactivateCounter = 0f; 

        public void ShootTorpedo()
        {
            Torpedo T = new Torpedo();
            T.Position = sprite.position;
            T.Rotation = sprite.rotation;
            T.Velocity = LinePrimatives.AngleToV2(MathHelper.ToDegrees(sprite.rotation), T.MovementSpeed);
            T.owner = this; 
        }
      
        public virtual void SetupPlayer1()
        {
            sprite = new Sprite("BigBlue");
            sprite.scale = .2f;
            sprite.origin.X = sprite.texture.Width / 2;
            sprite.origin.Y = sprite.texture.Height / 2;
            sprite.rotation = Rotation; 

            Collison = new Rectangle(0, 0, (int)(sprite.texture.Width * sprite.scale), (int)(sprite.texture.Height * sprite.scale));
        }

        public virtual void SetupPlayer2()
        {
            sprite = new Sprite("BigRed");
            sprite.scale = .2f;
            sprite.origin.X = sprite.texture.Width / 2;
            sprite.origin.Y = sprite.texture.Height / 2;
            sprite.rotation = Rotation;

            Collison = new Rectangle(0, 0, (int)(sprite.texture.Width * sprite.scale), (int)(sprite.texture.Height * sprite.scale));
        }

        public void AddForce(GameTime gametime)
        {
            if (ThrustersActive)
            {
                ThrustersActive = false;
                Vector2 direction = new Vector2((float)Math.Cos(Rotation), (float)Math.Sin(Rotation));
                Velocity += direction * Force;
                // also  LinePrimatives.AngleToV2(Rotation, Force)
            }
        }

        public void AddRotation(GameTime gametime, float direction)
        {
            Rotation += direction * RotationRate * (MathHelper.Pi / 180) * (gametime.ElapsedGameTime.Milliseconds/1000.0f);
        }

        public override void Update(GameTime gameTime)
        {
            if (ThrustersActive == false)
            {
                //Console.WriteLine("milli: " + gameTime.ElapsedGameTime.Milliseconds); 
                ThrusterReactivateCounter += (gameTime.ElapsedGameTime.Milliseconds / 1000.0f); 
               
                if (ThrusterReactivateCounter > ThrusterReactivateTime )
                {
                    ThrusterReactivateCounter = 0;
                    ThrustersActive = true; 
                }
            }

            if (sprite.position.X > ScreenSize.X)
            {
                sprite.position.X = AntiScreenSize.X;
                Position.X = AntiScreenSize.X;
            }
            if (sprite.position.X < AntiScreenSize.X)
            {
                sprite.position.X = ScreenSize.X;
                Position.X = ScreenSize.X;
            }
            if (sprite.position.Y > ScreenSize.Y)
            {
                sprite.position.Y = AntiScreenSize.Y;
                Position.Y = AntiScreenSize.Y;
            }
            if (sprite.position.Y < AntiScreenSize.Y)
            {
                sprite.position.Y = ScreenSize.Y;
                Position.Y = ScreenSize.Y;
            }

            
            

        }

        protected override bool ProcessDamage(float Value)
        {
            Health -= Value;
            if (Health <= 0)
            {
                Destroy();
            }
            return true;
        }
    }
}
