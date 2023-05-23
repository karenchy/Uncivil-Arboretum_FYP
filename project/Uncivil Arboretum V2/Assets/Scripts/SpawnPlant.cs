using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlant : MonoBehaviour
{
    public static T GetChanceItem<T>(List<T> list) where T : ChanceItem
    {
        int chanceSum = 0;
        for (int i = 0; i < list.Count; i++)
        {
            T current = list[i];
            chanceSum += current.chance;
            if (i == 0)
            {
                current.minChance = 0;
                current.maxChance = current.chance;
            }
            else
            {
                current.minChance = list[i - 1].maxChance;
                current.maxChance = current.minChance + current.chance;
            }
        }

        int rand = Random.Range(0, chanceSum);
        for (int i = 0; i < list.Count; i++)
        {
            T current = list[i];
            if (rand >= current.minChance && rand < current.maxChance)
            {
                return current;
            }
        }
        return null;
    }
}

[System.Serializable]
public class ChanceItem
{
    public PlantObject plant;
    public int chance;
    [HideInInspector] public int minChance;
    [HideInInspector] public int maxChance;
}