using UnityEngine;
using System.Collections;


public class TileScript: MonoBehaviour {

	//O enum transitionState indica de onde o bloco aparece na transição.
	public enum transitionState {DONE,UP,DOWN};
	public enum transitionSpeedType {LINEAR,ACCELERATION};
	//pointStart e pointFinish indicam onde o bloco começa e termina na transição. De modo a simplificar a edição de 
	//cenários, pointFinish é o ponto onde o bloco está no editor.
	Vector3 pointStart;
	Vector3 pointFinish;

	float transitionTime = 0;

	public float transitionSpeed = 1.0f;
	public float transitionAcceleration = 0.01f;
	public transitionState transition = transitionState.UP;
	public transitionSpeedType speedType = transitionSpeedType.ACCELERATION;
	public transitionState getTransitionState()
		{
			return transition;
		}

	public Vector3 getPointFinish()
	{
		return pointFinish;
	}

	public void finishTransition()
	{
		transition=transitionState.DONE;
	}

	public float getTransitionSpeed()
	{
		if(speedType==transitionSpeedType.LINEAR)
			{
				return transitionSpeed;		
			}
		else if (speedType==transitionSpeedType.ACCELERATION)
		{
			transitionSpeed = transitionSpeed + transitionTime * transitionAcceleration;
			return transitionSpeed;
		}
		else 
		{
			return 0;
		}
	}

	public void addTransitionTime(float t)
	{
		transitionTime += t;
	}


	void Start()
	{
		if (getTransitionState() != transitionState.DONE)
		{
			pointFinish = transform.position;
			if(getTransitionState() == transitionState.UP)
			{
				pointStart = pointFinish;
				pointStart.y = pointStart.y + 5;
			}

			transform.position = pointStart;
		}
	}

}
