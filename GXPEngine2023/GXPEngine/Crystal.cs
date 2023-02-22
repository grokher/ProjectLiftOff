using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

class Crystal : AnimationSprite
{
    int health = 10;

    int animCounter;
    int animFrame;

    public Crystal() : base("Crystal.png",3,1,60,false, true)
    {
        SetXY(width / 4, height / 4);
        SetScaleXY(1f, 1f);
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

    void Update()
    {
        Anim();
    }
}
