using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class highScoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    //private List<HighScoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;

    private void Awake() 
    {
        entryContainer = transform.Find("highScoreContainer");
        entryTemplate = entryContainer.Find("highScoreTemplate");

        entryTemplate.gameObject.SetActive(false);

        //AddHighscoreEntry(UserSettings.playerScore, UserSettings.playerName.Substring(0,3));


        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if(highscores == null)
        {
            string json1 = JsonUtility.ToJson(highscores);
            PlayerPrefs.SetString("highscoreTable", json1);
        }

        for(int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for(int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if(highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    HighScoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }

        for (int i = 10; i < highscores.highscoreEntryList.Count; i++)
        {
            highscores.highscoreEntryList.RemoveAt(i);
            Debug.Log(i);
        }

        

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighScoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighScoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }

    private void CreateHighScoreEntryTransform(HighScoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 30f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight *transformList.Count);
        entryTransform.gameObject.SetActive(true);

        
        int rank = transformList.Count +1;
        string rankString;
        switch (rank) 
        {
            default: rankString = rank+ "TH"; break;
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("Rank (1)").GetComponent<Text>().text = rankString;
        entryTransform.Find("Name (1)").GetComponent<Text>().text = highscoreEntry.name;
        entryTransform.Find("Score (1)").GetComponent<Text>().text = highscoreEntry.score.ToString();

        transformList.Add(entryTransform);
        
    }

    private void AddHighscoreEntry(int score, string name)
    {
        HighScoreEntry highScoreEntry = new HighScoreEntry {score = score, name = name};
        
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        //Debug.Log(jsonString);
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        highscores.highscoreEntryList.Add(highScoreEntry);

        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    public void deleteHighscores()
    {
        PlayerPrefs.SetString("highscoreTable", null);
        SceneManager.LoadScene(2);
    }

    private class Highscores 
    {
        public List<HighScoreEntry> highscoreEntryList;
    }
    [System.Serializable]
    private class HighScoreEntry
    {
        public int score;
        public string name;

    }
}
