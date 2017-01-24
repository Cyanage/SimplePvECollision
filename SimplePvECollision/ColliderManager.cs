﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SimplePvECollision
{
    class ColliderManager
    {
        public static ICollider playerCollider; //the collider of the player
        public static IVelocity playerVelocity; //the velocity of the player, add the moving player object to these two variables.
        public static List<ICollider> enviromentColliderList = new List<ICollider>();   //list that hold all the colliders that are part of the enviroment.  Add non-moving collider classes to this. 

        public static void Initialize() //this is static so no constructor, use this as constructor.
        {
            //TODO: add classes that inherit ICollider to playerCollider and envoromentColliderList.
        }

        public static void Update() //holds all the update logic.
        {
            //moving the player by its velocity.
            playerCollider.objectRect = new Rectangle((int)(playerCollider.objectRect.X + playerVelocity.objectVelocity.X), (int)(playerCollider.objectRect.Y + playerVelocity.objectVelocity.Y), playerCollider.objectRect.Width, playerCollider.objectRect.Height);
            Collision(); //checks object collision
        }

        private static void Collision()
        {
            foreach (ICollider col in enviromentColliderList)
            {
                if (playerCollider.objectRect.Intersects(col.objectRect))
                {
                    if (playerCollider.objectRect.X > col.objectRect.X)
                    {
                        if (playerCollider.objectRect.Y > col.objectRect.Y) //Xpos goes up to push the rect away, Ypos goes up as well, X+ Y+
                        {
                            playerCollider.objectRect = new Rectangle(
                                (int)(playerCollider.objectRect.X + (playerCollider.objectRect.Width - (playerCollider.objectRect.X - col.objectRect.X))), 
                                (int)(playerCollider.objectRect.Y + (playerCollider.objectRect.Height - (playerCollider.objectRect.Y - col.objectRect.Y))), 
                                playerCollider.objectRect.Width, 
                                playerCollider.objectRect.Height);
                        }
                        else //X+ Y-
                        {

                        }
                    }
                    else
                    {
                        if (playerCollider.objectRect.Y > col.objectRect.Y) //X- Y+
                        {

                        }
                        else //X- Y-
                        {

                        }

                    }
                    //TODO: dev, move player by intersect vector, doing now
                }
            }
            
        }
 
        public static void Draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics) // draws all the textures in the collider lists.
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null);//TODO: camera matrix
            foreach (ICollider col in enviromentColliderList)
            {
                spriteBatch.Draw(col.objectTexture, col.objectRect, Color.White); //draw all collider classes in enviroment list.
            }
            spriteBatch.Draw(playerCollider.objectTexture, playerCollider.objectRect, Color.White); //draw player
            spriteBatch.End();
        }


    }
}
