using GXPEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Player : Sprite
    {
        enum PlayerState
        {
            Alive,
            Damaged,
            Killed
        }

        static float BlinkingRate = 500f;
        static float DamageBlinkingTime = 2000f;

        //movement
        float turnSpeed = 3f;
        float moveSpeed = 6f;

        //shooting
        const int shootInterval = 300;
        int lastShot = 0;

        // invincible frames
        PlayerState currentState = PlayerState.Alive;
        float damagedTimeOut = 0f;        
        
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

        private void SetState(PlayerState newState)
        {
            if (newState != currentState)
            {
                currentState = newState;
                //respond to changes

                switch (currentState) {
                    case PlayerState.Damaged:
                        damagedTimeOut = DamageBlinkingTime;
                        break;
                    case PlayerState.Alive:
                        alpha = 1f;
                        break;
                    case PlayerState.Killed:
                        break;
                }
            }
        }

        //shooting
        public void Shoot()
        {
            Bullet bullet = new Bullet(this, 10.5f); //instantiate
            parent.AddChild(bullet);
        }



        public void Shield()
        {
            {
                //press activates shield
                //shieldCooldown = Time.time
            }
        }

        private void HandleBlinking()
        {
            alpha = Mathf.Floor(Time.now / BlinkingRate) % 2 * 0.5f + 0.5f;
            damagedTimeOut -= Time.deltaTime;
            if (damagedTimeOut < 0f)
            {
                SetState(PlayerState.Alive);
            }
        }

        
        public void Update()
        {
            TurnSpaceShip();
            MoveSpaceShip();

            switch (currentState)
            {
                case PlayerState.Alive:
                    HandleShooting();
                    break;

                case PlayerState.Damaged:
                    HandleBlinking();
                    break;

                case PlayerState.Killed:
                    break;
            }
        }

        private void HandleShooting()
        {
            if (Input.GetKey(Key.J) && (Time.time > lastShot + shootInterval))
            {
                //play sound
                Shoot();
                lastShot = Time.time;
            }
        }

        //Collisions
        public void OnCollision(GameObject other)
        {
            if (currentState == PlayerState.Alive)
            {
                if (other is Enemy)
                {
                    //play took impact sound
                    //health--
                    Console.WriteLine("Freeze");
                    //SetColor(125, 0, 215);
                    SetState(PlayerState.Damaged);
                }
            }
        }
    }
}
