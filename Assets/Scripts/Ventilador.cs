using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilador : MonoBehaviour {
    static float velocity = 0;
    static Player player;

    void OnTriggerEnter(Collider col)
    {
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.2f, player.transform.position.z);
        player.setVerticalSpeed(5f);

    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
}
