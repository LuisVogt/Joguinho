using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {
	public float playerDistanceToFall = 5.0f;
	Transform tempChild;
	GameObject[] TransicaoVector;
	GameObject Player;
	Vector3 tempPointFinish;
	float tempSpeed;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");

	}
	
	// Update is called once per frame
	void Update () {
		TransicaoVector = GameObject.FindGameObjectsWithTag("Transição");
		if(TransicaoVector.Length > 0)
		{
			foreach(GameObject go in TransicaoVector)
			{
				tempChild = go.transform;
				if((Vector3.Distance(tempChild.position,Player.transform.position) < playerDistanceToFall))
				{
					tempChild.GetComponent<TileScript>().startFall();
				}
				if(tempChild.GetComponent<TileScript>().isFalling())
				{
					if(tempChild.GetComponent<TileScript>().getTransitionState()!=TileScript.transitionState.DONE)
					{
						tempPointFinish = tempChild.GetComponent<TileScript>().getPointFinish();
						tempSpeed = tempChild.GetComponent<TileScript>().getTransitionSpeed() * Time.deltaTime;
					}
					if(tempChild.GetComponent<TileScript>().getTransitionState() == TileScript.transitionState.UP)
					{
						if(tempChild.transform.position.y <= tempPointFinish.y)
						{
							tempChild.transform.position = tempPointFinish;
							tempChild.GetComponent<TileScript>().finishTransition();
							go.tag="Untagged";
						}
						else
						{
							tempChild.transform.position = Vector3.MoveTowards(tempChild.transform.position,tempPointFinish,tempSpeed);	
							tempChild.GetComponent<TileScript>().addTransitionTime(Time.deltaTime);
							tempChild.GetComponent<TileScript>().setPercentageTransparency();
						}
					}
				}
			}
		}
	}
}
