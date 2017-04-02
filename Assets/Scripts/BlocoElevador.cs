using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoElevador : MonoBehaviour {
    public float speed;
    public float yTarget;
    private bool active;
    private Vector3 target;

    void OnTriggerEnter()
    {
        active = true;
    }

	// Use this for initialization
	void Start () {
        active = false;
        yTarget = transform.position.y + yTarget;
        target = new Vector3(transform.position.x, yTarget, transform.position.z);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(active)
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.fixedDeltaTime);
        if (transform.position == target)
            Destroy(this);
	}
}
