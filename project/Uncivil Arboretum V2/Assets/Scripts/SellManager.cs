using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellManager : MonoBehaviour
{
    public PlantItem selectPlant;
    public int money;
    public Text APTxt;

    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    public void Load()
    {
        money = PlayerPrefs.GetInt("money", 0);
        APTxt.text = "AP: " + money;
    }

    public void Save()
    {
        PlayerPrefs.SetInt("money", money);
    }

    void Update()
    {
        APTxt.text = "AP: " + money;
    }

    public void SelectPlant(PlantItem newPlant)
    {
        selectPlant = newPlant;
    }

    public void Transaction(int value)
    {
        money += value;
        APTxt.text = "AP: " + money;
        Save();
    }

}
