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
        public Player() : base("colors.png")
        {
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
        }

        public void Update()
        {
            TurnSpaceShip();
            MoveSpaceShip();
        }

        //Collisions
        public void OnCollision(GameObject other)
        {
            /*if (other is Slime){
                health--
            }*/
        }
    }
}
