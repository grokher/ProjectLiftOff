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
    private bool active;

    public Powerup(Vector2 position, int powerUpID) : base( getTiledImage(powerUpID), 3, 3)
    {
        this.powerUpID = powerUpID;
        this.active = false;
        SetXY(position.x, position.y);
        SetCycle(0, 8);
    }

    static string getTiledImage( int powerUpID ) {
        switch( powerUpID ) {
            case 0: return "SpeedPowerup.png";
            case 1: return "ShootPowerup.png";
            case 2: return "ShieldPowerup.png";
            case 3: return "HealthPowerup.png";
        }
        return "";  // crashes so maybe an empty image
    }

    void OnCollision(GameObject other)
    {
        // Check if the other GameObject is a Player
        if (other is Player player)
        {
            switch (powerUpID)
            {
                case 0: player.ActivateSpeedBoost();    break;
                case 1: player.ActivateShootingBoost(); break;
                case 2: player.ActivateShield();        break;
                case 3: player.AddLife();               break;
            }
            LateRemove();
        }
    }

    public void Update()
    {
        Animate(0.2f);
    }

    public void Activate()
    {
        active = true;
    }

    public bool IsActive()
    {
        return active;
    }

    public new string GetType()
    {
        return getTiledImage(powerUpID);
    }
}