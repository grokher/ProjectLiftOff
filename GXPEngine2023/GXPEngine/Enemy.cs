using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class Enemy : Sprite
{
    int health;
    int damage;
    bool gameIsPlaying = false;
    float targetLocationX;
    float targetLocationY;

    Random RNG = new Random();

    public Enemy() : base("triangle.png", true)
    {
        enemySetup();
        //EnemyMovement();
    }

    void enemySetup()
    {
        SetScaleXY(0.5f, 0.5f);

        //setup spawnpoints RNG based
        switch (RNG.Next(1, 3))
        {
            case 1:
                SetXY(RNG.Next(-150, 2050), RNG.Next(-400,-200));
                break;
            case 2:
                SetXY(RNG.Next(-150, 2050), RNG.Next(1100, 1300));
                break;
            default:
                break;
        }
    }

    void Update()
    {
        EnemyMovement(0.25f);
    }

    public void EnemyMovement(float basicEnemySpeed)
    {
        targetLocationX = MyGame.main.width / 2; //X-axis on where to move
        targetLocationY = MyGame.main.height / 2; // Y-axis on where to move

        if (!gameIsPlaying)
        {
            //movement along the axis
            if (x <= targetLocationX && y <= targetLocationY)
            {
                x += basicEnemySpeed * Time.deltaTime / 4;

                y += basicEnemySpeed * Time.deltaTime / 4;
            }
            else if (x >= targetLocationX && y <= targetLocationY)
            {
                x -= basicEnemySpeed * Time.deltaTime / 4;

                y += basicEnemySpeed * Time.deltaTime / 4;
            }
            else if (x <= targetLocationX && y >= targetLocationY)
            {
                x += basicEnemySpeed * Time.deltaTime / 4;

                y -= basicEnemySpeed * Time.deltaTime / 4;
            }
            else if (x >= targetLocationX && y >= targetLocationY)
            {
                x -= basicEnemySpeed * Time.deltaTime / 4;

                y -= basicEnemySpeed * Time.deltaTime / 4;
            }
        }
    }


    public void OnCollision(GameObject target)
    {
        
    }

    public void Health(int healthAmount)
    {
        health -= healthAmount;
    }

    public void DealDamage(int damageAmount)
    {
        damage += damageAmount;
    }
    //insert spawning

    //insert firing at Player
}
