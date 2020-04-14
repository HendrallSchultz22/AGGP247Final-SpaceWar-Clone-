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
    public class BaseGameObject
    {
        public Sprite sprite;
        public Vector2 ScreenSize = new Vector2(1280, 960);
        public Vector2 AntiScreenSize = new Vector2(0, 0);
        public bool isActive = true;
        public Vector2 Position = Vector2.Zero;
        public Vector2 Scale = Vector2.Zero;
        public float Rotation = 0;
        public Vector2 Velocity;
        public bool HasMaxiumVelocity = false;
        public float MaxiumVelocity = float.MaxValue;
        public Rectangle Collison;
        public BaseGameObject owner;
        
   

        public BaseGameObject()
        {
            GameApp.instance.InGameList.Add(this);

            InitalizeObject();
        }

        public virtual void InitalizeObject()
        {

        }

        public void ObjectUpdate(GameTime gameTime)
        {
            if (isActive)
            {
                if (HasMaxiumVelocity)
                {
                    ScrubVelocity();
                }

                float gT = (float)gameTime.ElapsedGameTime.TotalSeconds;
                Position += Velocity * gT;

                if (sprite != null)
                { 
                    Collison.Location = (Position - sprite.origin*sprite.scale).ToPoint();
                }

                Update(gameTime);
            }
        }

        public void ScrubVelocity()
        {
            if (Velocity.Length() > MaxiumVelocity)
            {
                Velocity.Normalize();
                Velocity *= MaxiumVelocity;
            }
        }

        public virtual void Update(GameTime gameTime)
        {


        }

        public void ObjectDraw(SpriteBatch spriteBatch)
        {
            if (isActive)
            {
                Draw(spriteBatch);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (sprite != null)
            { 
            sprite.position = Position;
            sprite.rotation = Rotation;
            sprite.Draw(spriteBatch);
            }

            // Debug
            if (Collison != null)
            { 

                LinePrimatives.DrawRectangle(spriteBatch, 5, Color.Red, Collison);
            }
        }

        public void Destroy()
        {
            OnDestroy();
            GameApp.instance.DestroyObjectList.Add(this);
        }

        public virtual void OnDestroy()
        {
            isActive = false;
        }
    }
}
