using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColectibleInventory : MonoBehaviour
{

    [SerializeField]
    List<int> collectibles;

    public void clearCollectibles()
    {
        collectibles = new List<int>();
    }

    public List<int> getCollectiblesInInventory()
    {
        return collectibles;
    }

    public void addCollectible(int collectible)
    {
        collectibles.Add(collectible);
    }
    public void addCollectibles(List<int> collectibleArray)
    {
        for (int i = 0; i < collectibleArray.Count; i++)
        {
            addCollectible(collectibleArray[i]);
        }
    }
}