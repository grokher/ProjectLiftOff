using System;                                   // System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;                           // System.Drawing contains drawing tools such as Color definitions
using System.IO.Ports;

public class MyGame : Game {

    Player player;
    //HealthPickup healthp;
    int maxEnemies;

    public MyGame() : base(1920, 1080, false)     // Create a window that's 800x600 and NOT fullscreen
	{
		Player player1  = new Player();
        Crystal crystal = new Crystal();
        //HealthPickup healthpick = new HealthPickup();
        //SetXY(width / 2, height / 3);
        player1.SetXY(main.width / 2, main.height / 2);
        crystal.SetXY(main.width / 2, main.height / 2);

        AddChild(player1);
        AddChild(crystal);
    }

    public void Spawn(int enemyAmount)
    {
        Enemy enemy = new Enemy();

        for (int i = 0; i < enemyAmount; i++)
        {
                LateAddChild(enemy);
            
            Console.WriteLine(enemyAmount);
        }
    }

    // For every game object, Update is called every frame, by the engine:
    void Update() {
        if(maxEnemies <= 16) //maxEnemies calculation += 2 = 2 + 1
        {
            Spawn(1);
            maxEnemies++;
        }
        
	}

	static void Main()                          // Main() is the first method that's called when the program is run
	{
		new MyGame().Start();                  // Create a "MyGame" and start it
        //arduino connection
        SerialPort port = new SerialPort();
        port.PortName = "COM4";
        port.BaudRate = 60000;
        port.RtsEnable = true;
        port.DtrEnable = true;
        port.Open();
        while (true)
        {
            string a = port.ReadExisting();
            if (a != "")
            {
                Console.WriteLine("Read from port: " + a);
            }
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                port.Write(key.KeyChar.ToString());
            }
        }
        //arduino connection ends here
    }
}