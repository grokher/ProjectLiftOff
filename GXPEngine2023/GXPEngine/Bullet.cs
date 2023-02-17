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

        public static double Radians(double degrees)
        {
            double radians = (Math.PI / 180) * degrees;
            return (radians);
        }

        public Bullet( Player pMother, float speed) : base("triangle.png")
        {
            float distance = pMother.height;
            double angle = Radians(pMother.rotation + 90 );
            float x = (float) ( pMother.x + Math.Cos( angle ) * distance) ;
            float y = (float) ( pMother.y + Math.Sin( angle ) * distance) ;
            Console.WriteLine("r = " + pMother.rotation + "\t" + x + "," + y);
            Console.WriteLine("m = " + pMother + "\t" + pMother.width + "x" + pMother.height );
            SetScaleXY(0.4f, 0.4f);
            SetOrigin(width / 2, height / 2);
            SetXY( x, y );
            width = width / 4;
            rotation = pMother.rotation - 180;
             vx = (float) ( speed * Math.Cos( angle ) );
            vy = (float) ( speed * Math.Sin( angle ) );
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



