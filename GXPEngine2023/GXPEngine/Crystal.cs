using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

class Crystal : Sprite
{
    int health = 10;
    public Crystal() : base("CharacterDefense.png", true)
    {
        SetXY(width, height);
    }

    void OnCollision(GameObject other)
    {
        if (other is Enemy)
        {
            //HitTest(other);
            other.LateRemove();
            health--;
            Console.WriteLine("health " + health );
        }
    }
    public void Health(int healthAmount)
    {
        health -= healthAmount;

        if(health <= 0)
        {
            LateDestroy();
            //game lost
        }
    }
}
