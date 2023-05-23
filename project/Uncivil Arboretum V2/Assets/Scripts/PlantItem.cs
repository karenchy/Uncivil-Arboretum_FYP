using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantItem : MonoBehaviour
{
    public PlantObject plant;

    public Text nameTxt;
    public Image icon;

    public Text harvestNumTxt;

    public Image btnImage;
    public Text btnTxt;

    SellManager sm;

    // Start is called before the first frame update
    void Start()
    {
        sm = FindObjectOfType<SellManager>();
        InitializeUI();
    }

    void Update()
    {
        harvestNumTxt.text = "Harvest " + plant.harvestNum;
    }

    public void SellPlant()
    {
        Debug.Log("Sell " + plant.plantName);
        sm.SelectPlant(this);
        if (plant.harvestNum > 0)
        {
            sm.Transaction(plant.sellPrice);
            plant.harvestNum--;
        }
    }

    void InitializeUI()
    {
        nameTxt.text = plant.plantName;
        icon.sprite = plant.icon;
        harvestNumTxt.text = "Harvest " + plant.harvestNum;
        btnTxt.text = "Sell: +" + plant.sellPrice + " AP";
    }

}
