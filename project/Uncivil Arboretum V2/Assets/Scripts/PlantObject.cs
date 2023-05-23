using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Plant", menuName ="Plant")]
public class PlantObject : ScriptableObject
{
    public string plantName;
    public Sprite[] plantStages;
    public float timebtwStages;
    public int sellPrice;
    public Sprite icon;
    public Sprite[] plantFrames;
    public float timebtwFrames;
    public int harvestNum;
}
