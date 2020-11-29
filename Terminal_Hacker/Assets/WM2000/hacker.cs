using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hacker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("What wuld you like to hack into?");
        Terminal.WriteLine("Press 1 for library");
        Terminal.WriteLine("Press 2 for police station");
        Terminal.WriteLine("Please enter your selection:");
    }
}
