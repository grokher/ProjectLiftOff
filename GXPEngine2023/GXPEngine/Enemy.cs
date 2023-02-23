using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class Enemy : AnimationSprite
{
    int animCounter;
    int animFrame;

    int health;
    int damage;
    bool gameIsPlaying = false;
    float targetLocationX;
    float targetLocationY;

    Random RNG = new Random();

    public Enemy() : base("GreenSlime.png",4,5, 20,true)
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
            case 1: //top x-axis
                SetXY(RNG.Next(-150, 1550), RNG.Next(-400,-200));
                break;
            case 2: //bottom X-axis
                SetXY(RNG.Next(-150, 1550), RNG.Next(800, 1100));
                break;
            default:
                break;
        }
    }

    void Update()
    {
        EnemyMovement(0.25f);
        Anim();
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

    private void Anim()
    {
        animCounter++;
        if (animCounter > 10)
        {
            animCounter = 0;
            animFrame++;
            if (animFrame == frameCount)
            {
                animFrame = 0;
            }
            SetFrame(animFrame);
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
