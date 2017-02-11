using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevadorProInferno : MonoBehaviour {
    public float timeInitial;
    [SerializeField] private float time;
    [SerializeField] private bool counting;
    [SerializeField] private bool falling;
    private float fallSpeed = 0.0f;
    public float gravity;
    public float killBlockHeight;

    void resetTime()
    {
        time = timeInitial;
        counting = false;
    }

    void OnTriggerEnter()
    {
        counting = true;
    }

    void OnTriggerExit()
    {
        if (!falling)
        {
            resetTime();
            falling = false;
        }
    }

    void Fall()
    {
        fallSpeed = fallSpeed - gravity * Time.fixedDeltaTime;
        transform.position = transform.position + new Vector3(0.0f, fallSpeed*Time.fixedDeltaTime, 0.0f);
    }
	// Use this for initialization
	void Start () {
        resetTime();
	}
	
	// Update is called once per frame
	void Update () {
        if (counting)
        {
            if (time <= 0)
            {
                falling = true;
                counting = false;
            }
            time = time - Time.deltaTime;
        }
	}
    void FixedUpdate()
    {
        if (transform.position.y < killBlockHeight)
            Destroy(this.gameObject);
        if(falling)
        {
            Fall();
        }
    }
}
