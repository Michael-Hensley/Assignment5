using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;
    private bool isPaused = false;

    void Start()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }
    public void pause()
    {
        menu.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0;
        isPaused = true;
    }
    public void Unpause()
    {
        menu.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1;
        isPaused = false;
    }
    public bool IsGamePaused()
    {
        return isPaused;
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPaused)
            {
                Unpause();
            }
            else
            {
                pause();
            }
        }
    }

    public void restartGame()
    {
        UserSettings.playerScore = 0;
        SceneManager.LoadScene(1);
    
    }
    public void quit()
    {
        Application.Quit();
    }
}
