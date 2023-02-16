using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    class Bullet : Sprite
    {
        float vx;
        float vy;

        GameObject mother;

        public Bullet(float pVx, float pVy, GameObject pMother) : base("triangle.png")
        {
            SetOrigin(width / 2, height / 2);
            vx = pVx;
            vy = pVy;
            mother = pMother;
        }

        void BulletTravel()
        {
            x += vx;
            y += vy;
        }

        void OffScreen()
        {
            if(x + width < 0 || x > game.width || y + height < 0 || y > game.width)
            {
                LateDestroy();
                Console.WriteLine("Bullet Gone");
            }
        }

        void Update()
        {
            OffScreen();
            BulletTravel();
        }
    }
}
