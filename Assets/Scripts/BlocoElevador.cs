using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoElevador : MonoBehaviour {
    public float speed;
    public float yTarget;
    private bool active;
    private Vector3 target;
    private Vector3 origem;
    void OnTriggerEnter()
    {
        active = true;
    }

    void OnTriggerExit()
    {
        active = false;
    }

	// Use this for initialization
	void Start () {
        origem = transform.position;
        active = false;
        yTarget = transform.position.y + yTarget;
        target = new Vector3(transform.position.x, yTarget, transform.position.z);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        switch (active)
        {
            case true:
                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.fixedDeltaTime);
                break;

            case false:
                transform.position = Vector3.MoveTowards(transform.position, origem, speed * Time.fixedDeltaTime);
                break;
        }

	}
}
