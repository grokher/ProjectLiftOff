using GXPEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Player : Sprite
    {
        float turnSpeed = 7f;
        float moveSpeed = 12f;

        // shield ability
        int shieldCooldown = 3000;
        int shieldDuration = 5000;
        public Player() : base("colors.png")
        {
            SetScaleXY(0.8f, 0.8f);
            SpawnPlayer();
        }

        public void SpawnPlayer()
        {
            SetXY(width / 2, height / 2);
        }


        //rotation
        public void TurnSpaceShip()
        {
            SetOrigin(width / 2, height / 2);
            if (Input.GetKey(Key.A))
            {
                rotation -= turnSpeed;
            }
            if (Input.GetKey(Key.D))
            {
                rotation += turnSpeed;
            }
        }

        //movement
        public void MoveSpaceShip()
        {
            if (Input.GetKey(Key.W))
            {
                Move(0, moveSpeed);
            }
            if (Input.GetKey(Key.S))
            {
                Move(0, -moveSpeed);
            }
        }

        //shooting
        public void Shoot()
        {
    
            Bullet bullet = new Bullet(x, y, this); //instantiate
            
            bullet.SetXY(x + 10, y); //direction

            if (Input.GetKey(Key.J))
            {
                parent.AddChild(bullet);
                //play sound
            }
        }

        public void Shield()
        {
            if (Time.time > shieldCooldown)
            {
                //press activates shield
                //shieldCooldown = Time.time
            }
        }

        public void LoseHealth()
        {
            //if (health)
        }
        public void Update()
        {
            TurnSpaceShip();
            MoveSpaceShip();
            Shoot();
            Console.WriteLine(rotation);

        }

        //Collisions
        public void OnCollision(GameObject other)
        {
            /*if (other is Slime){
                play took impact sound
                health--
            }*/
        }
    }
}
