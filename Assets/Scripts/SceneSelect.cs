using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSelect : MonoBehaviour
{
    public Button playB;
    public void startGame()
    {
        if(UserSettings.playerName != "")
        {
            SceneManager.LoadScene(1);
            Debug.Log("Game Started");
        }
        else
        {
        
        }
    }

    public void titleScreen()
    {
        SceneManager.LoadScene(0);
        Debug.Log("load intro");
    }
    public void exitGame()
    {
        Application.Quit();
        Debug.Log("Game exited");
    }
}