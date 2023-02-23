using GXPEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiledMapParser;

namespace GXPEngine
{
    class Player : AnimationSprite
    {
        enum PlayerState
        {
            Alive,
            Damaged,
            SpeedBoost,
            ShootBoost,
            Killed
        }

        //private Dictionary<string, Powerup> inventory;
        //private Powerup activePowerup;

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

        //powerups
        private bool isSpeedBoostActive = false;
        private float speedMultiplier = 2f;
        private float speedBoostDuration = 5000f;
        float powerupDuration = 0f;

        int animCounter;
        int animFrame;

        public Player() : base("spaceship.png",1,2,6)
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
            if (isSpeedBoostActive && Input.GetKey(Key.A))
            {
                rotation -= turnSpeed * speedMultiplier;
            }
            else if (Input.GetKey(Key.A))
            {
                rotation -= turnSpeed;
            }

            if (isSpeedBoostActive && Input.GetKey(Key.D))
            {
                rotation += turnSpeed * speedMultiplier;
            }
            else if (Input.GetKey(Key.D))
            {
                rotation += turnSpeed;
            }
        }

        //movement
        public void MoveSpaceShip()
        {
            if (isSpeedBoostActive == true && Input.GetKey(Key.W))
            {
                Move(0, moveSpeed * speedMultiplier);
            }
            else if (Input.GetKey(Key.W))
            {
                Move(0, moveSpeed);
            }

            if(isSpeedBoostActive == true && Input.GetKey(Key.S))
            {
                Move(0, -moveSpeed * speedMultiplier);
            }
            else if (Input.GetKey(Key.S))
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
                    case PlayerState.SpeedBoost:
                        //time
                        break;
                    case PlayerState.ShootBoost:
                        //shoot interval less
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


        //disable shooting
        private void HandleBlinking()
        {
            alpha = Mathf.Floor(Time.now / BlinkingRate) % 2 * 0.5f + 0.5f;
            damagedTimeOut -= Time.deltaTime;
            if (damagedTimeOut < 0f)
            {
                SetState(PlayerState.Alive);
            }
        }

        //enable double speed
        public void SpeedBoostActivate()
        {
            powerupDuration -= Time.deltaTime;
            if (powerupDuration < 0f)
            {
                SetState(PlayerState.Alive);
            }
        }
        private void ScreenEdge()
        {
            if (x + width < 0 || x > game.width || y + height < 0 || y > game.width)
            {
                //just width is the sprite width
                int gameWidth = MyGame.main.width;
                int gameHeight = MyGame.main.height;

                if (x < width/2)
                {
                    x = width/2;
                }
                else if (x > gameWidth - width / 2)
                {
                    x = gameWidth - width / 2;
                }

                if (y < height / 2)
                {
                    y = height / 2;
                }
                else if (y > gameHeight - height / 2)
                {
                    y = gameHeight - height / 2;
                }
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


        public void Update()
        {
            TurnSpaceShip();
            MoveSpaceShip();
            ScreenEdge();
            Anim();

            switch (currentState)
            {
                case PlayerState.Alive:
                    HandleShooting();
                    break;

                case PlayerState.Damaged:
                    HandleBlinking();
                    break;

                case PlayerState.SpeedBoost:
                    SpeedBoostActivate();
                    break;

                case PlayerState.Killed:
                    break;
            }
        }

        private void HandleShooting()
        {
            if (Input.GetKey(Key.SPACE) && (Time.time > lastShot + shootInterval))
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
                    Console.WriteLine("Stunned");
                    other.LateDestroy();
                    SetState(PlayerState.Damaged);
                }
            }
            
        }
        /*public void ApplyPowerUp(Powerup powerup)
        {
            Powerup speedBoost = new Powerup(Powerup.Type.SpeedBoost, 2f, 5000f);
            player.ApplyPowerUp(speedBoost);
            switch (powerup.type)
            {
                case Powerup.Type.SpeedBoost:
                    isSpeedBoostActive = true;
                    speedMultiplier = powerup.multiplier;
                    powerupDuration = powerup.duration;
                    SetState(PlayerState.SpeedBoost);
                    break;

                case Powerup.Type.ShootBoost:
                    // TODO: Implement shoot boost
                    break;

                default:
                    // Unknown power-up type
                    break;
            }
        }


        /*public void SpeedBoostActivate()
        {
            if (isSpeedBoostActive == false)
            {
                isSpeedBoostActive = true;
                Console.WriteLine("Boost on");
                
            }
            else
            {
                speedBoostDuration 
            }
        }*/
    }
}
