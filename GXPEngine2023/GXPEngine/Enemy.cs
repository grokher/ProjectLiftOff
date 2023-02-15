using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    

    class Enemy : Sprite
    {
        bool gameIsPlaying = false;
        bool IsmovingX = true;
        int enemyLocationX;

        public Enemy() : base("triangle.png")
        {
            SetScaleXY(0.5f, 0.5f);
            SetXY(1920 / 2, 1080 / 2);
            
            //EnemyMovement();
        }

        void Update()
        {
            EnemyMovement();
            Console.WriteLine(enemyLocationX);
        }
    
        public void EnemyMovement()
        {
            
            if (!gameIsPlaying)
            {
                if(enemyLocationX <= 1200 && IsmovingX)
                {
                    x = enemyLocationX += 1 * Time.deltaTime / 2;
                    if(enemyLocationX > 1080)
                    {
                        IsmovingX = false;
                        Console.WriteLine(IsmovingX);
                        if (!IsmovingX)
                        {
                            x = enemyLocationX += -2 * Time.deltaTime / 2;
                        }
                    }
                }

                /*if(enemyLocationX >= 1080 && !IsmovingX)
                {
                    Console.WriteLine("moving Left");
                    x = enemyLocationX -= 1 * Time.deltaTime;
                    if(enemyLocationX < 0)
                    {
                        IsmovingX = false;
                    }
                }*/

            }
            //x++ * Time.deltaTime;
        }
        //enemy for now is triangle.png
        //insert spawning

        //insert firing at Player
    }
}
