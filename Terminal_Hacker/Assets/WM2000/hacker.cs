using UnityEngine;

public class hacker : MonoBehaviour
{
    string[] level1pass = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2pass = { "handcuffs", "criminal", "prisioner", "shotgun", "pistol", "uniform" };
    string menuhint = "You may type \"menu\" to go back";
    int attempts;
    int level;
    string password;
    enum Screen { Menu, Level, Win, Lose };
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
            ShowMainMenu();
        }
        else if (currentScreen == Screen.Menu)
        {
            MainMenu(input);
        }
        else if (currentScreen == Screen.Level)
        {
            HandlePassword(input);
        }

    }

    void HandlePassword(string input)
    {
        if (input == password)
        {
            WinScreen();
        }
        else if (attempts > 0)
        {
            attempts--;
            Terminal.WriteLine("Password is incorrect");
            Terminal.WriteLine("Hint: " + password.Anagram());
            Terminal.WriteLine("remaining attepts: " + (attempts + 1));
            Terminal.WriteLine(menuhint);
        }
        else
        {
            LoseScreen();
        }

    }

    void LoseScreen()
    {
        currentScreen = Screen.Lose;
        Terminal.WriteLine("You lost!");
        Terminal.WriteLine(menuhint);
    }
    void WinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        Terminal.WriteLine("Access granted!");
        InsertArt();
        Terminal.WriteLine(menuhint);
    }
    private void InsertArt()
    {
        Terminal.WriteLine(@"
         .-.
        (@.@) 
      '=.|m|.='
      .='` ``=.
"
                           );
    }

    void MainMenu(string input)
    {
        bool isValidLevel = (input == "1" || input == "2");
        if (isValidLevel)
        {
            level = int.Parse(input);
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Please select a Valid objective");
            Terminal.WriteLine(menuhint);
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Level;
        Terminal.ClearScreen();
        Terminal.WriteLine("You have chosen level " + level);
        SetPassword();
        Terminal.WriteLine("Enter Password");
        Terminal.WriteLine(menuhint);
        Terminal.WriteLine("Hint: " + password.Anagram());

    }

    void SetPassword()
    {
        int index;
        switch (level)
        {
            case 1:
                attempts = 5;
                index = Random.Range(0, level1pass.Length);
                password = level1pass[index];
                break;
            case 2:
                attempts = 3;
                index = Random.Range(0, level1pass.Length);
                password = level2pass[index];
                break;
            default:
                Debug.LogError("Invalid Level Number " + level);
                Start();
                break;
        }
    }
}
