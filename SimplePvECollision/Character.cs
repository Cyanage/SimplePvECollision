using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace SimplePvECollision
{
    class Character : ICollider, IVelocity
    {
        public Character(Texture2D texture, Rectangle rectangle, Point textureSize)
        {
            objectTexture = texture; //sets the texture of the object
            objectRect = rectangle; //sets the size and position of the object
            this.textureSize = textureSize;
        }

        //If you try to change object rect it will not change because it outputs a return value, like vector2's
        private Rectangle objectRect; //holds the position and size.
        public Rectangle ObjectRect
        {
            get { return objectRect; }
            set { objectRect = value; }
        }

        private Texture2D objectTexture; //holds the texture value
        public Texture2D ObjectTexture
        {
            get { return objectTexture; }
            set { objectTexture = value;  }
        }

        private Point textureSize; //holds the texture's size
        public Point TextureSize
        {
            get { return textureSize; }
            set { textureSize = value; }
        }

        private Vector2 objectVelocity; //holds the velocity value
        public Vector2 ObjectVelocity
        {
            get { return objectVelocity; }
            set { objectVelocity = value; }
        }

        public void Draw(SpriteBatch spriteBatch) //draw the character
        {
            spriteBatch.Draw(objectTexture, new Rectangle(objectRect.X, objectRect.Y, textureSize.X, textureSize.Y), Color.White);
        }

        private bool isSpaceDown = false;
        public void Update()
        {
            objectVelocity += new Vector2(0, 1); //gravity
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                objectVelocity = new Vector2(-8, objectVelocity.Y);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                objectVelocity = new Vector2(8, ObjectVelocity.Y);
            }
            else
            {
                objectVelocity = new Vector2(0, ObjectVelocity.Y);
            }

            if (isSpaceDown == false & Keyboard.GetState().IsKeyDown(Keys.Space)) //jumping
            {
                Console.WriteLine("turned true");
                objectVelocity += new Vector2(0, -25);
                isSpaceDown = true;
            }
            else if (isSpaceDown == true & Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                Console.WriteLine("turned false");
                isSpaceDown = false;
            }
        }
    }
}
