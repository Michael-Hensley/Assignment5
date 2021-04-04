using UnityEngine.UI;
using UnityEngine;

public class ShowScore : MonoBehaviour
{
    public Text scoreBox;
        void Update()
    {
        scoreBox.text = UserSettings.playerScore.ToString();
    }
}
