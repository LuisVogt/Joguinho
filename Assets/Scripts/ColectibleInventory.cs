using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColectibleInventory : MonoBehaviour {

    [SerializeField]List<string> colectibles;

    public void addCollectible(GameObject colectible)
    {
        colectibles.Add(colectible.name);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
