using UnityEngine;
using System.Collections;

public class PrefabReplicator : MonoBehaviour {

	public bool onePoint;
	public Vector3 initPoint;
	public Vector3 finalPoint;
	public float dist = 1.0f;

	private Vector3 point;

	public GameObject prefabby;

	private GameObject temp;

	public void CopyPrefab()
	{
		if(onePoint)
		{
			Instantiate(prefabby, initPoint,Quaternion.identity,this.transform);
		}
		else
		{
			point.x = (int)(finalPoint.x - initPoint.x);
			point.y = (int)(finalPoint.y - initPoint.y);
			point.z = (int)(finalPoint.z - initPoint.z);
			for(int x = 0; x < Mathf.Abs(point.x)+1; x++)
			{
				for(int y = 0; y < Mathf.Abs(point.y)+1; y++)
				{
					for(int z = 0; z < Mathf.Abs(point.z)+1; z++)
					{
						temp = Instantiate(prefabby, new Vector3(x*dist*Mathf.Sign(point.x),y*dist*Mathf.Sign(point.y),z*dist*Mathf.Sign(point.z)), 
						Quaternion.identity, this.transform) as GameObject;
					}
				}
			}
		}
	}
}
