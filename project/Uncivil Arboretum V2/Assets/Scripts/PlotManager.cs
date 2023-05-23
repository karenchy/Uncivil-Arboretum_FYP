using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : MonoBehaviour
{
    bool isPlanted = false;
    public SpriteRenderer plant;
    BoxCollider2D plantCollider;

    public PlantObject selectedPlant;
    int plantStage = 0;
    int plantFrame = 0;
    float timer;

    [SerializeField] List<ChanceItem> items;

    SellManager sm;

    // Start is called before the first frame update
    void Start()
    {
        plant = transform.GetChild(0).GetComponent<SpriteRenderer>();
        plantCollider = transform.GetChild(0).GetComponent<BoxCollider2D>();
        sm = transform.parent.GetComponent<SellManager>();
        selectedPlant.timebtwStages = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlanted)
        {
            timer -= Time.deltaTime;
            if (timer < 0 && plantStage < selectedPlant.plantStages.Length - 1)
            {
                if (plantStage == selectedPlant.plantStages.Length - 3)
                {
                    selectedPlant.timebtwStages = 60f;
                }
                timer = selectedPlant.timebtwStages;
                plantStage++;
                updatePlant();
            }
        }
    }

    private void OnMouseDown()
    {
        if (isPlanted)
        {
            if (plantStage >= selectedPlant.plantStages.Length - 2)
            {
                Harvest();
            }
        }
        else Plant();
    }

    void Harvest()
    {
        if (plantStage == selectedPlant.plantStages.Length - 2)
        {
            selectedPlant.harvestNum++;
        }
        selectedPlant.timebtwStages = 4f;
        isPlanted = false;
        plant.gameObject.SetActive(false);
    }

    void Plant()
    {
        selectedPlant = SpawnPlant.GetChanceItem<ChanceItem>(items).plant;
        isPlanted = true;
        selectedPlant.timebtwStages = 4f;
        plant.gameObject.SetActive(true);
        plantStage = 0;
        updatePlant();
        timer = selectedPlant.timebtwStages;
    }

    void updatePlant()
    {
        plant.sprite = selectedPlant.plantStages[plantStage];
        plantCollider.size = plant.sprite.bounds.size;
        plantCollider.offset = new Vector2(0, 0);
        selectedPlant.timebtwStages = 4f;
    }
}