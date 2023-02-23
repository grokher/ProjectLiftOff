using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using GXPEngine.Core;

class Powerup : AnimationSprite
{
    //PowerUp ID
    // 0 = Speed Boost
    // 1 = Shooting Boost
    // 2 = Shield
    // 3 = Extra Lives
    private int powerUpID = 0;
    private string type;
    private bool active;

    public Powerup(string type, Vector2 position, int powerUpID, bool active, String[] pngs) : base("", 3, 3)
    {
        this.type = type;
        this.powerUpID = powerUpID;
        this.active = active;
        SetXY(position.x, position.y);
    }

    void Update()
    {
        // Rotate the powerup
    }

    void OnCollision(GameObject other)
    {
        // Check if the other GameObject is a Player
        if (other is Player player)
        {
            switch (powerUpID)
            {
                case 0:
                    player.SpeedBoostActivate();
                    break;
                case 1:
                    //player.ShootingBoostActivate();
                    break;
                case 2:
                    //player.ActivateShield();
                    break;
                case 3:
                    //player.AddLife();
                    break;
            }
            LateRemove();
        }
    }

    public void Activate()
    {
        active = true;
    }

    public void Deactivate()
    {
        active = false;
    }

    public bool IsActive()
    {
        return active;
    }

    public new string GetType()
    {
        return type;
    }
}