using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colectible : MonoBehaviour {    
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag=="Player")
        {
            collider.gameObject.GetComponent<ColectibleInventory>().addCollectible(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }

    // Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

    }
}