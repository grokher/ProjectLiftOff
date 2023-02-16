using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class Enemy : Sprite
{
    Player playerlocation;
    bool gameIsPlaying = false;
    bool IsmovingX = true;
    float targetLocationX;
    float targetLocationY;
    int enemyLocationX;
    int enemyLocationY = 5;

    Random RNG = new Random();

    public Enemy() : base("triangle.png")
    {
        SetScaleXY(0.5f, 0.5f);
        SetXY(RNG.Next(0, 1920), height / 2);

        //EnemyMovement();
    }

    void Update()
    {
        EnemyMovement();
    }

    public void EnemyMovement()
    {
        targetLocationX = 1920 / 2;
        targetLocationY = 1080 / 2;

        if (!gameIsPlaying)
        {
            Console.WriteLine(x);
            if (x < targetLocationX && y < targetLocationY)
            {
                x += 0.5f * Time.deltaTime / 4;

                y += 0.5f * Time.deltaTime / 4;
            }
            else if (x > targetLocationX && y < targetLocationY)
            {
                x -= 0.5f * Time.deltaTime / 4;

                y += 0.5f * Time.deltaTime / 4;
            }
            else if (x < targetLocationX && y > targetLocationY)
            {
                x += 0.5f * Time.deltaTime / 4;

                y -= 0.5f * Time.deltaTime / 4;
            }
            else if (x > targetLocationX && y > targetLocationY)
            {
                x -= 0.5f * Time.deltaTime / 4;

                y += 0.5f * Time.deltaTime / 4;
            }
        }
    }

    public void OnCollision(GameObject target)
    {

    }
    //insert spawning

    //insert firing at Player
}
