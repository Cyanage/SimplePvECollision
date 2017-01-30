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
    class StaticObject : ICollider
    {
        private Vector2 tileAxis; //tiling is making one large sqaure out of many small square textures.
        public StaticObject(Texture2D texture, Rectangle rectangle, Vector2 tileAxis)
        {
            objectTexture = texture; //sets the texture of the object
            objectRect = rectangle; //sets the size and position of the object
            this.tileAxis = tileAxis; //sets the amount of tiles the object has
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
            set { objectTexture = value; }
        }

        public void Draw(SpriteBatch spriteBatch) //draws the texture
        {
            for (int i = 0; i > tileAxis.X; i++)
            {
                for (int i2 = 0; i2 > tileAxis.Y; i2++)
                {
                    //spriteBatch.Draw(objectTexture, new Rectangle(objectRect.X + i * 64, objectRect.Y + i2 * 64, 64, 64), Color.White);
                    spriteBatch.Draw(objectTexture, new Rectangle(objectRect.X, objectRect.Y, 640, 64), Color.White);
                }
            }

        }
    }
}
