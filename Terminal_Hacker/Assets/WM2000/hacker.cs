using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hacker : MonoBehaviour
{
    int level;
    enum Screen { Menu, Level, Win };
    Screen currentScreen;
    // Start is called before the first frame update
    void Start()
    {
        level = 0;
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.Menu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for library");
        Terminal.WriteLine("Press 2 for police station");
        Terminal.WriteLine("Please enter your selection:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            Start();
        }
        else if (currentScreen == Screen.Menu)
        {
            MainMenu(input);
        }

    }

    void MainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Please select a Valid objective");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Level;
        Terminal.ClearScreen();
        Terminal.WriteLine("Please enter Password");

    }
}
