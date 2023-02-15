using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Player : Sprite
    {
        float turnSpeed = 5f;
        float moveSpeed = 7f;
        public Player() : base("barry.png")
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
            if (Input.GetKey(Key.A))
            {
                rotation -= turnSpeed;
            }
            if (Input.GetKey(Key.D))
            {
                rotation += turnSpeed;
            }
        }
        //insert movement

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
