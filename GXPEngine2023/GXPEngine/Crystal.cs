using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class Crystal : AnimationSprite
{
    public static int health = 10;
    static public Crystal crystal;

    int animCounter;
    int animFrame;

    HUD hud = null;

    Sound damageSound;

    public Crystal() : base("Crystal.png",3,1,60,false, true)
    {
        SetXY(width / 4, height / 4);
        SetScaleXY(1f, 1f);
    }
    public void LoadGameOver()
    {
        MyGame.game.gameRunning = false;
        if (health <= 0)
        {
            GameOver gameover = new GameOver();
            MyGame.game.LateAddChild(gameover);
        }
    }

    void OnCollision(GameObject other)
    {
        damageSound = new Sound("ping.wav", false);
        if (other is Enemy)
        {
            //HitTest(other);
            other.LateRemove();
            health--;
            damageSound.Play();
            Console.WriteLine("health " + health );
        }
        if (health <= 0)
        {
            LateDestroy();
            Console.WriteLine("Dead");
            LoadGameOver();
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
        if (hud == null) hud = game.FindObjectOfType<HUD>();
        Anim();
    }
}
