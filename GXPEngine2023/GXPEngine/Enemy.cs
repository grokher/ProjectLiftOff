using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

    class Enemy : Sprite
    {
        bool gameIsPlaying = false;
        bool IsmovingX = true;
        int enemyLocationX;
        int enemyLocationY = 5;

        Random RNG = new Random();

        public Enemy() : base("triangle.png")
        {
            SetScaleXY(0.5f, 0.5f);
            SetXY(RNG.Next(0,1920), height / 2);

            //EnemyMovement();
        }

        void Update()
        {
            EnemyMovement();
        }
    
        public void EnemyMovement()
        {

            if (!gameIsPlaying)
            {
                Console.WriteLine(enemyLocationX);
                if(x <= 1920 && IsmovingX)
                {
                    //enemyLocationX = RNG.Next(0,1920);
                    x = enemyLocationX += 1 * Time.deltaTime;
                    if(enemyLocationX >= 1920)
                    {
                        IsmovingX = false;
                    }
                    y = enemyLocationY / 4 + RNG.Next(1, 1080);
            }
                else if(x > 0 && !IsmovingX)
                {
                    x = enemyLocationX -= 1 * Time.deltaTime;
                    if(enemyLocationX <= 0)
                    {
                        IsmovingX = true;
                    }
                    y = enemyLocationY / 4 + RNG.Next(1, 1080);
            }
            }
        }
        //enemy for now is triangle.png
        //insert spawning

        //insert firing at Player
    }
