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
            colliderList.Add(new StaticObject(tex, new Rectangle(64 * 2, 64 * 4, 64 * 4, 64), new Point(4, 1), new Point(64, 64)));
            colliderList.Add(new StaticObject(tex, new Rectangle(64 * 3, 64, 64 * 2, 64), new Point(2, 1), new Point(64, 64)));
            colliderList.Add(new StaticObject(tex, new Rectangle(0, 64 * 8, 64 * 24, 64), new Point(24, 1), new Point(64, 64)));
            colliderList.Add(new StaticObject(tex, new Rectangle(64 * 10, 64 * 6, 64 * 12, 64), new Point(12, 1), new Point(64, 64)));
            colliderList.Add(new StaticObject(tex, new Rectangle(0, -64, 64 * 24, 64), new Point(0, 0), new Point(64, 64))); // two zeros in tile axis varibale means don't draw it.
            colliderList.Add(new StaticObject(tex, new Rectangle(-64, 0, 64, 64 * 8), new Point(0, 0), new Point(64, 64))); // two zeros in tile axis varibale means don't draw it.
        }
    }
}
