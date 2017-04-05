using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingOnIce : MonoBehaviour {
    static Player player;
    public static Vector3 velocity = Vector3.zero;
    static Vector3 preVelocity;
    void OnTriggerStay(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            player.LockMovement(true);
            if (checkVelocity())
            {
                player.setVelocity(new Vector3(velocity.x, 0f, velocity.z));
            }
            else
                player.setVelocity(Vector3.zero);
        }
    }

    bool checkVelocity()
    {
        bool resultado = true;
        //Verifica se a velocidade atual é igual a anterior e retorna sim ou não
        if (velocity != preVelocity)
        {
            resultado = false;
        }
        preVelocity = velocity;
        return resultado;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
}
