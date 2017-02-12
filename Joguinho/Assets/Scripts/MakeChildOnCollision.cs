using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeChildOnCollision : MonoBehaviour {
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(this.gameObject.transform);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            collision.gameObject.transform.SetParent(null);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
