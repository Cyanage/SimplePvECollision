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
    class ColliderManager
    {
        public static ICollider playerCollider; //the collider of the player
        public static IVelocity playerVelocity; //the velocity of the player, add the moving player object to these two variables.
        public static List<ICollider> enviromentColliderList = new List<ICollider>();   //list that hold all the colliders that are part of the enviroment.  Add non-moving collider classes to this. 

        public static void Initialize(Character character) //this is static so no constructor, use this as constructor.
        {
            enviromentColliderList = Enviroment.colliderList; //setting enviroment
            playerCollider = character; //setting player
            playerVelocity = character;
            //TODO: add classes that inherit ICollider to playerCollider and envoromentColliderList.
        }

        public static void Update() //holds all the update logic.
        {
            //moving the player by its velocity.
            playerCollider.ObjectRect = new Rectangle((int)(playerCollider.ObjectRect.X + playerVelocity.ObjectVelocity.X), (int)(playerCollider.ObjectRect.Y + playerVelocity.ObjectVelocity.Y), playerCollider.ObjectRect.Width, playerCollider.ObjectRect.Height);
            Collision(); //checks object collision
        }

        private static void Collision()
        {
            foreach (ICollider col in enviromentColliderList)
            {
                if (playerCollider.ObjectRect.Intersects(col.ObjectRect)) //checks if the player is colliding with the current object in the foreach loop.
                {
                    //TODO: add distance checker
                    if (playerCollider.ObjectRect.X > col.ObjectRect.X) //finds what side of the wall the player is on
                    {
                        if (playerCollider.ObjectRect.Y > col.ObjectRect.Y) //ditto
                        {
                            if ((col.ObjectRect.Width - (playerCollider.ObjectRect.X - col.ObjectRect.X)) < (col.ObjectRect.Height - (playerCollider.ObjectRect.Y - col.ObjectRect.Y))) //Checks which direction to push the character
                            {
                                Console.WriteLine("1");
                                playerCollider.ObjectRect = new Rectangle(playerCollider.ObjectRect.X + (col.ObjectRect.Width - (playerCollider.ObjectRect.X - col.ObjectRect.X)), 
                                                                          playerCollider.ObjectRect.Y, 
                                                                          playerCollider.ObjectRect.Width, 
                                                                          playerCollider.ObjectRect.Height);
                            }
                            else
                            {
                                Console.WriteLine("2");
                                playerCollider.ObjectRect = new Rectangle(playerCollider.ObjectRect.X, 
                                                                          playerCollider.ObjectRect.Y + (col.ObjectRect.Height - (playerCollider.ObjectRect.Y - col.ObjectRect.Y)), 
                                                                          playerCollider.ObjectRect.Width, 
                                                                          playerCollider.ObjectRect.Height);
                            } 
                        }
                        else
                        {
                            if ((col.ObjectRect.Width - (playerCollider.ObjectRect.X - col.ObjectRect.X)) < (playerCollider.ObjectRect.Height + (playerCollider.ObjectRect.Y - col.ObjectRect.Y))) //Checks which direction to push the character
                            {
                                Console.WriteLine("3");
                                playerCollider.ObjectRect = new Rectangle(playerCollider.ObjectRect.X + (col.ObjectRect.Width - (playerCollider.ObjectRect.X - col.ObjectRect.X)),
                                                                          playerCollider.ObjectRect.Y,
                                                                          playerCollider.ObjectRect.Width,
                                                                          playerCollider.ObjectRect.Height);
                            }
                            else
                            {
                                Console.WriteLine("4");
                                playerCollider.ObjectRect = new Rectangle(playerCollider.ObjectRect.X,
                                                                          playerCollider.ObjectRect.Y - (playerCollider.ObjectRect.Height + (playerCollider.ObjectRect.Y - col.ObjectRect.Y)),
                                                                          playerCollider.ObjectRect.Width,
                                                                          playerCollider.ObjectRect.Height);
                            }
                        }
                    }
                    else
                    {
                        if (playerCollider.ObjectRect.Y > col.ObjectRect.Y)
                        {
                            if ((playerCollider.ObjectRect.Width + (playerCollider.ObjectRect.X - col.ObjectRect.X)) < (col.ObjectRect.Height - (playerCollider.ObjectRect.Y - col.ObjectRect.Y))) //Checks which direction to push the character
                            {
                                Console.WriteLine("5");
                                playerCollider.ObjectRect = new Rectangle(playerCollider.ObjectRect.X - (playerCollider.ObjectRect.Width + (playerCollider.ObjectRect.X - col.ObjectRect.X)),
                                                                          playerCollider.ObjectRect.Y,
                                                                          playerCollider.ObjectRect.Width,
                                                                          playerCollider.ObjectRect.Height);
                            }
                            else
                            {
                                Console.WriteLine("6");
                                playerCollider.ObjectRect = new Rectangle(playerCollider.ObjectRect.X,
                                                                          playerCollider.ObjectRect.Y + (col.ObjectRect.Height - (playerCollider.ObjectRect.Y - col.ObjectRect.Y)),
                                                                          playerCollider.ObjectRect.Width,
                                                                          playerCollider.ObjectRect.Height);
                            }
                        }
                        else
                        {
                            if((playerCollider.ObjectRect.Width + (playerCollider.ObjectRect.X - col.ObjectRect.X)) < (playerCollider.ObjectRect.Height + (playerCollider.ObjectRect.Y - col.ObjectRect.Y))) //Checks which direction to push the character
                            {
                                Console.WriteLine("7");
                                playerCollider.ObjectRect = new Rectangle(playerCollider.ObjectRect.X - (playerCollider.ObjectRect.Width + (playerCollider.ObjectRect.X - col.ObjectRect.X)),
                                                                          playerCollider.ObjectRect.Y,
                                                                          playerCollider.ObjectRect.Width,
                                                                          playerCollider.ObjectRect.Height);
                            }
                            else
                            {
                                Console.WriteLine("8");
                                playerCollider.ObjectRect = new Rectangle(playerCollider.ObjectRect.X,
                                                                          playerCollider.ObjectRect.Y - (playerCollider.ObjectRect.Height + (playerCollider.ObjectRect.Y - col.ObjectRect.Y)),
                                                                          playerCollider.ObjectRect.Width,
                                                                          playerCollider.ObjectRect.Height);
                            }
                        }
                    }
                }
            }
        }
 
        public static void Draw(SpriteBatch spriteBatch) // draws all the textures in the collider lists.
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null);//TODO: camera matrix
            foreach (ICollider col in enviromentColliderList)
            {
                spriteBatch.Draw(col.ObjectTexture, col.ObjectRect, Color.White); //draw all collider classes in enviroment list.
            }
            spriteBatch.Draw(playerCollider.ObjectTexture, playerCollider.ObjectRect, Color.White); //draw player
            spriteBatch.End();
        }
    }
}

//                    if (playerCollider.ObjectRect.X > col.ObjectRect.X)
//                    {
//                        if (playerCollider.ObjectRect.Y > col.ObjectRect.Y) //Xpos goes up to push the rect away, Ypos goes up as well, X+ Y+
//                        {
//                            Console.WriteLine(playerCollider.ObjectRect + " : Object Rect size 1");
//                            Console.WriteLine("Calculations : " + playerCollider.ObjectRect.X + " + (" + col.ObjectRect.Width + " - (" + playerCollider.ObjectRect.X + " - " + col.ObjectRect.X + ")) == " + (playerCollider.ObjectRect.X + (col.ObjectRect.Width - (playerCollider.ObjectRect.X - col.ObjectRect.X))));
//                            playerCollider.ObjectRect = new Rectangle(
//                                (playerCollider.ObjectRect.X + (col.ObjectRect.Width - (playerCollider.ObjectRect.X - col.ObjectRect.X))), 
//                                (playerCollider.ObjectRect.Y + (col.ObjectRect.Height - (playerCollider.ObjectRect.Y - col.ObjectRect.Y))), 
//                                playerCollider.ObjectRect.Width, 
//                                playerCollider.ObjectRect.Height);
//                            Console.WriteLine(playerCollider.ObjectRect + " : Object Rect size 2");
//                        }
//                        else //X+ Y-
//                        {
//                            playerCollider.ObjectRect = new Rectangle(
//                                (int)(playerCollider.ObjectRect.X + (playerCollider.ObjectRect.Width - (playerCollider.ObjectRect.X - col.ObjectRect.X))),
//                                (int)(playerCollider.ObjectRect.Y - (playerCollider.ObjectRect.Height - (playerCollider.ObjectRect.Y - col.ObjectRect.Y))),
//                                playerCollider.ObjectRect.Width,
//                                playerCollider.ObjectRect.Height);
//                        }
//                    }
//                    else
//                    {
//                        if (playerCollider.ObjectRect.Y > col.ObjectRect.Y) //X- Y+
//                        {
//                            playerCollider.ObjectRect = new Rectangle(
//                                (int)(playerCollider.ObjectRect.X - (playerCollider.ObjectRect.Width - (playerCollider.ObjectRect.X - col.ObjectRect.X))),
//                                (int)(playerCollider.ObjectRect.Y - (playerCollider.ObjectRect.Height - (playerCollider.ObjectRect.Y - col.ObjectRect.Y))),
//                                playerCollider.ObjectRect.Width,
//                                playerCollider.ObjectRect.Height);
//                        }
//                        else //X- Y-
//                        {
//                            playerCollider.ObjectRect = new Rectangle(
//                                (int)(playerCollider.ObjectRect.X - (playerCollider.ObjectRect.Width - (playerCollider.ObjectRect.X - col.ObjectRect.X))),
//                                (int)(playerCollider.ObjectRect.Y + (playerCollider.ObjectRect.Height - (playerCollider.ObjectRect.Y - col.ObjectRect.Y))),
//                                playerCollider.ObjectRect.Width,
//                                playerCollider.ObjectRect.Height);
//                        }
//                    }
