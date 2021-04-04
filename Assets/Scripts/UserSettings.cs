using UnityEngine;
using UnityEngine.UI;

public class UserSettings : MonoBehaviour
{
    public InputField nameInput;
    public static string playerName = "";
    public static int playerScore = 0;
    public void setPlayerName()
    {
        playerName = nameInput.text.ToString();
        Debug.Log(playerName);
    }

    public Slider speedSlider;
    public static float speedMultiplier = 1;
    public Text speedIndicator;

    public void setSpeedMultiplier()
    {
        switch (speedSlider.value)
        {
            case 1:
            speedMultiplier = 0.5f;
            speedIndicator.text = "SLOW";
            Debug.Log(speedMultiplier);
            break;
            case 2:
            speedMultiplier = 1f;
            speedIndicator.text = "NORMAL";
            Debug.Log(speedMultiplier);
            break;
            case 3:
            speedMultiplier = 1.5f;
            speedIndicator.text = "FAST";
            Debug.Log(speedMultiplier);
            break;
        }
    }
}