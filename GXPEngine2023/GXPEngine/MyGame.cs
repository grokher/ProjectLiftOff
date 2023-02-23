using System;                                   // System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;                           // System.Drawing contains drawing tools such as Color definitions
using System.IO.Ports;
using System.Collections.Generic;



public class MyGame : Game
{
    static public MyGame game;
    int maxEnemies = 6;
    int currentEnemies;
    public bool gameRunning = false;   
    float timer;
    float nextWave = 15000f;

    public MyGame() : base(1366, 768, true , false)     // Create a window that's 1366x768 and IS fullscreen and NOT using Vsync
    {
        ShowMouse(false);

        MainMenu mainMenu = new MainMenu();

        AddChild(mainMenu);
        game = this;

    }

    void DestoryAll()
    {
        List<GameObject> children = GetChildren();
        foreach (GameObject child in children)
        {
            child.Destroy();
        }
    }
    public void LoadLevel()
    {

        Player player1 = new Player();
        Crystal crystal = new Crystal();
        BackGround bg = new BackGround();
        //HealthPickup healthpick = new HealthPickup();
        //SetXY(width / 2, height / 3);
        player1.SetXY(main.width / 2, main.height / 2);
        crystal.SetXY(main.width / 2, main.height / 2);
        //bg.SetXY(main.width, main.height);

        AddChild(bg);
        AddChild(player1);
        AddChild(crystal);
        AddChild(new HUD());
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
    void Update()
    {
        if (gameRunning)
        {
            timer += Time.deltaTime;

            if (currentEnemies <= maxEnemies) //maxEnemies calculation += 2 = 2 + 1
            {
                Spawn(1);
                currentEnemies++;
            }

            if (timer >= nextWave)
            {
                currentEnemies = 0;
                timer = 0f;
                maxEnemies += 2;
            }
        }

        if (Input.GetMouseButtonUp(0) || Input.GetKey(Key.J) && gameRunning == false)
        {
            DestoryAll();
            LoadLevel();
            timer = 10000;
            gameRunning = true;
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