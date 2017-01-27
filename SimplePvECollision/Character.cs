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
        public Character(Texture2D texture, Rectangle rectangle)
        {
            objectTexture = texture; //sets the texture of the object
            objectRect = rectangle; //sets the size and position of the object
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

        private Vector2 objectVelocity; //holds the velocity value
        public Vector2 ObjectVelocity
        {
            get { return objectVelocity; }
            set { objectVelocity = value; }
        }

        public void Draw(SpriteBatch spriteBatch) //draw the character
        {
            spriteBatch.Draw(objectTexture, objectRect, Color.White);
        }

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                objectVelocity = new Vector2(objectVelocity.X, -8);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                objectVelocity = new Vector2(-8, objectVelocity.Y);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                objectVelocity = new Vector2(objectVelocity.X, 8);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                objectVelocity = new Vector2(8, objectVelocity.Y);
            }
            else
            {
                objectVelocity = new Vector2(0, 0);
            }
            //TODO: add movement logic here.
        }
    }
}
