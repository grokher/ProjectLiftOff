using GXPEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Player : AnimationSprite
    {
        enum PlayerState
        {
            Alive,
            Damaged,
            Killed
        }

        private Dictionary<string, Powerup> inventory;
        private Powerup activePowerup;

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

        int animCounter;
        int animFrame;

        public Player() : base("spaceship.png",1,2,6)
        {
            SetScaleXY(0.8f, 0.8f);
            SpawnPlayer();

            inventory = new Dictionary<string, Powerup>
            {
                {"speedboost", new Powerup("speedboost") },
                {"shootingboost", new Powerup("shootingboost") },
                {"shield", new Powerup("shield") },
                {"health", new Powerup("health") }
            };
            activePowerup = null;
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

        //powerup
        public void ActivatePowerup(string powerupType)
        {
            if (activePowerup != null)
            {
                activePowerup.Deactivate();
            }
            activePowerup = inventory[powerupType];
            activePowerup.Activate();
        }
        public void UpdateActivePowerup(float deltaTime)
        {
            if (activePowerup != null && activePowerup.IsActive())
            {
                // Reduce the active time of the powerup
                float activeTime = activePowerup.GetType() == "health" ? 30f : 15f; // Health powerup lasts longer
                activeTime -= deltaTime;
                if (activeTime <= 0)
                {
                    activePowerup.Deactivate();
                    activePowerup = null;
                }
            }
        }
        public void AddHealth(int amount)
        {
            inventory["health"].Activate();
            // Add health to the player's health object here
        }

        public void HandleInput(char key)
        {
            if (key == 'j')
            {
                foreach (string powerupType in inventory.Keys)
                {
                    if (inventory[powerupType].IsActive())
                    {
                        ActivatePowerup(powerupType);
                        break;
                    }
                }
            }
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
                    //health--
                    Console.WriteLine("Stunned");
                    other.LateDestroy();
                    SetState(PlayerState.Damaged);
                }
            }
            Powerup collidedPowerup = other.Tags
            if (other.GetComponent<Powerup>() != null)
            {
                string powerupType = other.GetComponent<Powerup>().GetType();
                inventory[powerupType].Activate();
                // Remove the powerup object from the game here
            }
        }
    }
}
