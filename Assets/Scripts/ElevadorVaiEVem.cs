using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevadorVaiEVem : MonoBehaviour {
    public float speed;
    public float restTime;
    public GameObject pontoA;
    public GameObject pontoB;
    public GameObject Elevador;
    private float timePassed;
    enum estado
    {
        goingToA,
        goingToB,
        waitingInA,
        waitingInB
    }

    private estado estadoAtual;

	// Use this for initialization
	void Start () {
        estadoAtual = estado.waitingInA;
	}

	void FixedUpdate () {
        switch (estadoAtual)
        {
            case estado.waitingInA:
                if (timePassed <= 0)
                    estadoAtual = estado.goingToB;
                else
                    timePassed = timePassed - Time.fixedDeltaTime;
                break;
            case estado.waitingInB:
                if (timePassed <= 0)
                    estadoAtual = estado.goingToA;
                else
                    timePassed = timePassed - Time.fixedDeltaTime;
                break;
            case estado.goingToA:
                Elevador.transform.position = Vector3.MoveTowards(Elevador.transform.position, pontoA.transform.position, speed * Time.fixedDeltaTime);
                if (Elevador.transform.position == pontoA.transform.position)
                {
                    timePassed = restTime;
                    estadoAtual = estado.waitingInA;
                }
                break;
            case estado.goingToB:
                Elevador.transform.position = Vector3.MoveTowards(Elevador.transform.position, pontoB.transform.position, speed * Time.fixedDeltaTime);
                if (Elevador.transform.position == pontoB.transform.position)
                {
                    timePassed = restTime;
                    estadoAtual = estado.waitingInB;
                }
                break;
        }
	}
}
