using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

class HealthPickup : Sprite
{
    public HealthPickup() : base("colors.png")
    {

    }

    public void Collect()
    {
        Console.WriteLine("More Life");

        LateDestroy();
        //pick up aniamtion and sound
    }

    public void Update()
    {

    }

}
