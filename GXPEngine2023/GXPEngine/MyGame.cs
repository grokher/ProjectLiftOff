using System;                                   // System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;                           // System.Drawing contains drawing tools such as Color definitions

public class MyGame : Game {

    int maxEnemies;

    public MyGame() : base(1920, 1080, false)     // Create a window that's 800x600 and NOT fullscreen
	{
		Player player1  = new Player(); 

        AddChild(player1);
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
		// Empty
	}

	static void Main()                          // Main() is the first method that's called when the program is run
	{
		new MyGame().Start();                   // Create a "MyGame" and start it
	}
}