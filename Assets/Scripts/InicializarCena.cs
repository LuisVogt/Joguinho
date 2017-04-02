using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicializarCena : MonoBehaviour {
    public Vector3 PlayerPosition;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(GameObject.FindGameObjectWithTag("Player")!=null)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = PlayerPosition;
            Destroy(this.gameObject);
        }
    }
}
