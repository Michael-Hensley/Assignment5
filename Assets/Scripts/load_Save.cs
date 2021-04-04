using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class load_Save : MonoBehaviour
{


    //public Button checkbtn;
    //public WordManager wordManager;
    // public void seeWord()
    // {
    //     int count = 0;

    //     foreach (Word element in wordManager.words)
    //     {
    //         Debug.Log(element.word);
    //         Debug.Log(transform.position);
    //         count++;
    //     }
    // }
    public void saveGame()
    {
        PlayerPrefs.SetString("Name", UserSettings.playerName);
        PlayerPrefs.SetInt("Score", UserSettings.playerScore);
        PlayerPrefs.SetFloat("Speed", UserSettings.speedMultiplier);
        PlayerPrefs.Save();
        Debug.Log("Saved");
    }
    public void loadGame()
    {
        UserSettings.playerName = PlayerPrefs.GetString("Name", "Patient 0");
        UserSettings.playerScore = PlayerPrefs.GetInt("Score", 0);
        UserSettings.speedMultiplier = PlayerPrefs.GetFloat("Speed", 1);
        SceneManager.LoadScene(1);

        Debug.Log("Loaded");
    }
    public void saveJson()
    {
        jsonSave mySave = new jsonSave();
        mySave.PlayerName = UserSettings.playerName;
        mySave.SpeedSetting = UserSettings.speedMultiplier;
        string json = JsonUtility.ToJson(mySave);

        File.WriteAllText(Application.dataPath + "/saveSettings.json", json);
    }

    private class jsonSave
    {
        public string PlayerName;
        public float SpeedSetting;
    }
}
