using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FLNextLevel : MonoBehaviour
{
    
    public string secondLevel;
    public string mainMenu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SecondLevel()
    {
        SceneManager.LoadScene(secondLevel);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
    

}
