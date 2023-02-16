﻿using System;
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

    public Enemy() : base("triangle.png")
    {
        SetScaleXY(0.5f, 0.5f);
        switch (RNG.Next(1,3))
        {
            case 1:
                SetXY(RNG.Next(0, 1920), height / 2);
                break;
            case 2:
                SetXY(RNG.Next(0, 1920),RNG.Next(900,950));
                break;
            default:
                break;
        }

        //EnemyMovement();
    }

    void Update()
    {
        EnemyMovement(0.5f);
    }

    public void EnemyMovement(float basicEnemySpeed)
    {
        targetLocationX = 1920 / 2;
        targetLocationY = 1080 / 2;

        if (!gameIsPlaying)
        {
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
