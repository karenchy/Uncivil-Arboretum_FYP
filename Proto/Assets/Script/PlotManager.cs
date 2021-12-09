using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlotManager : MonoBehaviour
{
    bool isPlanted = false;
    public SpriteRenderer plant;

    public Sprite[] plantStages;
    int plantStage = 0;
    float timebtwStages = 2f;
    float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlanted){
                timer -= Time.deltaTime;
                if( timer < 0 && plantStage<plantStages.Length-1 ){
                    timer = timebtwStages;
                    plantStage++;
                    updatePlant();
                }
        }
    }

    private void OnMouseDown(){
        if (isPlanted){
            if( plantStage == plantStages.Length-1){
            Harvest();}
        }
        else{
            Plant();
        }
    }

    void Harvest(){
        isPlanted = false;
        plant.gameObject.SetActive(false);
    }

    void Plant(){
        isPlanted = true;
        plant.gameObject.SetActive(true);
        plantStage = 0;
        updatePlant();
        timer = timebtwStages;
    }

    void updatePlant(){
        plant.sprite = plantStages[plantStage];
    }
}
