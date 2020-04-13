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
        public static PlayerClass instance;
        public Sprite BigRedShip;
        public Sprite BigBlueShip;
   
        public Vector2 Player1Loc = new Vector2(80, 500);
        public Vector2 Player2Loc = new Vector2(1220, 465);

        public PlayerClass()
        {
            instance = this;
        }
        public void TorpedoShot1(GameTime gameTime)
        {
            Torpedo T = new Torpedo();
            T.Position = BigBlueShip.position;
            T.Rotation = BigBlueShip.rotation;
            T.Velocity = LinePrimatives.AngleToV2(MathHelper.ToDegrees(BigBlueShip.rotation), T.MovementSpeed);
        }

        public void TorpedoShot2(GameTime gameTime)
        {
            Torpedo T = new Torpedo();
            T.Position = BigRedShip.position;
            T.Rotation = BigRedShip.rotation;
            T.Velocity = LinePrimatives.AngleToV2(MathHelper.ToDegrees(BigRedShip.rotation), T.MovementSpeed);
        }

        public override void InitalizeObject()
        {
           
            BigRedShip = new Sprite("BigRed");
            BigRedShip.scale = .2f;
            BigRedShip.position = Player2Loc;
            BigRedShip.origin.X = BigRedShip.texture.Width / 2;
            BigRedShip.origin.Y = BigRedShip.texture.Height / 2;

            RectCollison = new Rectangle(0, 0, BigRedShip.texture.Width, BigRedShip.texture.Height);

            BigBlueShip = new Sprite("BigBlue");
            BigBlueShip.scale = .2f;
            BigBlueShip.position = Player1Loc;
            BigBlueShip.origin.X = BigBlueShip.texture.Width / 2;
            BigBlueShip.origin.Y = BigBlueShip.texture.Height / 2;

            RectCollison = new Rectangle(0, 0, BigBlueShip.texture.Width, BigBlueShip.texture.Height);
        }

        public override void Update(GameTime gameTime)
        {
            RectCollison.Location = Position.ToPoint();

            //player1
            if (BigBlueShip.position.X > ScreenSize.X)
            {
                BigBlueShip.position.X = AntiScreenSize.X;
                Player1Loc.X = AntiScreenSize.X;
            }
            if (BigBlueShip.position.X < AntiScreenSize.X)
            {
                BigBlueShip.position.X = ScreenSize.X;
                Player1Loc.X = ScreenSize.X;
            }
            if (BigBlueShip.position.Y > ScreenSize.Y)
            {
                BigBlueShip.position.Y = AntiScreenSize.Y;
                Player1Loc.Y = AntiScreenSize.Y;
            }
            if (BigBlueShip.position.Y < AntiScreenSize.Y)
            {
                BigBlueShip.position.Y = ScreenSize.Y;
                Player1Loc.Y = ScreenSize.Y;
            }

            //Player2
            if (BigRedShip.position.X > ScreenSize.X)
            {
                BigRedShip.position.X = AntiScreenSize.X;
                Player2Loc.X = AntiScreenSize.X;
            }
            if (BigRedShip.position.X < AntiScreenSize.X)
            {
                BigRedShip.position.X = ScreenSize.X;
                Player2Loc.X = ScreenSize.X;
            }
            if (BigRedShip.position.Y > ScreenSize.Y)
            {
                BigRedShip.position.Y = AntiScreenSize.Y;
                Player2Loc.Y = AntiScreenSize.Y;
            }
            if (BigRedShip.position.Y < AntiScreenSize.Y)
            {
                BigRedShip.position.Y = ScreenSize.Y;
                Player2Loc.Y = ScreenSize.Y;
            }


        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            BigBlueShip.position = Player1Loc;
            BigBlueShip.Draw(spriteBatch);
            BigRedShip.position = Player2Loc;
            BigRedShip.Draw(spriteBatch);
        }
    }
}
