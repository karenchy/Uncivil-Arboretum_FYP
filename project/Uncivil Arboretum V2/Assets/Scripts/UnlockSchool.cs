using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UnlockSchool : MonoBehaviour
{
    public GameObject requirement;
    public Button reqButton;
    public GameObject button;

    int buyPrice = 2000;
    int arGamePt = 20;
    int unlockStatus;

    int scoreGet;

    SellManager sm;

    // Start is called before the first frame update
    void Start()
    {
        Load();
        GameObject Script = GameObject.Find("Script");
        sm = Script.GetComponent<SellManager>();
        reqButton.interactable = false;
    }

    public void Load()
    {
        unlockStatus = PlayerPrefs.GetInt("unlockSchool", 0);
    }

    public void Save()
    {
        PlayerPrefs.SetInt("unlockSchool", unlockStatus);
    }

    void Update()
    {
        scoreGet = PlayerPrefs.GetInt("gamePt", ScoreManagerXR.score);

        if (sm.money >= buyPrice)
        {
            reqButton.interactable = true;
        }

        if (unlockStatus >= 1)
        {
            Active();
        }
    }

    public void Unlock()
    {
        scoreGet = PlayerPrefs.GetInt("gamePt", ScoreManagerXR.score);
        if (sm.money >= buyPrice && scoreGet >= arGamePt && unlockStatus == 0)
        {
            sm.Transaction(-buyPrice);
            Active();
            unlockStatus++;
            Save();
        }
    }

    void Active()
    {
        Destroy(requirement);
        button.gameObject.SetActive(true);
    }
}