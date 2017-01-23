using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePvECollision
{
    class ColliderManager
    {
        public static ICollider playerCollider;
        public static List<ICollider> enviromentColliderList = new List<ICollider>();

        public static void Initialize() //this is static so no constructor, use this as constructor.
        {

        }
    }
}
