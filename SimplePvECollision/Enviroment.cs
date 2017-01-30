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
    class Enviroment
    {
        public static List<ICollider> colliderList;
        public Enviroment(Texture2D tex)
        {
            colliderList = new List<ICollider>();
            colliderList.Add(new StaticObject(tex, new Rectangle(64 * 2, 64 * 4, 64, 64), new Vector2(1, 1)));
            colliderList.Add(new StaticObject(tex, new Rectangle(64 * 3, 64, 64, 64), new Vector2(1, 1)));
            colliderList.Add(new StaticObject(tex, new Rectangle(64 * 4, 128, 64, 64 * 2), new Vector2(1, 2)));
        }
    }
}
