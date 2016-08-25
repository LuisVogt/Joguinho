using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	Transform tempChild;
	Vector3 tempPointFinish;
	float tempSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < transform.childCount; i++)
		{
			tempChild = transform.GetChild(i);
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
