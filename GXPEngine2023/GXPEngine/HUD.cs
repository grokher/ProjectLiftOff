using System;
using System.Drawing;
using System.Text;
using GXPEngine;
class HUD : GameObject
{
    EasyDraw score;
    EasyDraw healthBar;
    Sprite speedBoost;
    Sprite shootingBoost;
    Sprite shield;

    Font gameFont;
    public HUD()
    {
        gameFont = Utils.LoadFont("Galaxus-z8Mow.ttf", 40);
        score = new EasyDraw(250, 60);
        score.TextSize(40);
        score.TextAlign(CenterMode.Center, CenterMode.Center);
        score.Fill(Color.Gold);
        score.Text("Score: " /*+score*/);
        score.SetXY(game.width / 10, game.height / 10);
        AddChild(score);

        healthBar = new EasyDraw(250, 60);
        healthBar.ShapeAlign(CenterMode.Min, CenterMode.Min);
        healthBar.NoStroke();
        healthBar.Fill(Color.Aqua);
        healthBar.Rect(0, 0, 250, 60);
        healthBar.SetXY(game.width / 2, game.height / 10);
        AddChild(healthBar);

        speedBoost = new Sprite("SpeedUI.png");
        speedBoost.SetXY(game.width - 420, game.height / 10);
        speedBoost.scale = 1.3f;
        speedBoost.alpha = 0.5f;
        AddChild(speedBoost);

        shootingBoost = new Sprite("MissileUI.png");
        shootingBoost.SetXY(game.width - 350, game.height / 10);
        shootingBoost.scale = 1.3f;
        shootingBoost.alpha = 0.5f;
        AddChild(shootingBoost);

        shield = new Sprite("ShieldUI.png");
        shield.SetXY(game.width - 280, game.height / 10);
        shield.scale = 1.3f;
        shield.alpha = 0.5f;
        AddChild(shield);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="health"></param>
    public void SetHealth(float health)
    {
        healthBar.Clear(Color.Red);
        healthBar.Fill(Color.Aqua);
        healthBar.Rect(0, 0, healthBar.width * health, healthBar.height);
    }
}
