using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colectible : MonoBehaviour {
    public int collectibleID;    
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag=="Player")
        {
            collider.gameObject.GetComponent<ColectibleInventory>().addCollectible(collectibleID);
            Destroy(this.gameObject);
        }
    }

}