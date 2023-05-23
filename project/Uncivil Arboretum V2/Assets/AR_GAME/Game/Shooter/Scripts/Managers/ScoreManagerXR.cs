using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using TMPro;

public class ScoreManagerXR : MonoBehaviour
{
    public static int score;

    TextMeshProUGUI text; // AR version

    static bool isScoreChanged = false;

    void Awake ()
    {

        PlayerPrefs.SetInt("gamePt", score);

        // Set up the reference.
        text = GetComponent <TextMeshProUGUI> (); // AR version

        // Reset the score.
        score = 0;
    }

    public static void Increase (int scoreValue)
    {
        score += scoreValue;

        isScoreChanged = true;
    }

    void UpdateUI()
    {
        text.text = score.ToString();

        isScoreChanged = false;
    }

    void Update()
    {
        if (isScoreChanged)
        {
            UpdateUI();
        }
    }
}