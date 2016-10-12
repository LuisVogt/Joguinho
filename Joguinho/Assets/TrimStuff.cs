using UnityEngine;
using System.Collections;

public class TrimStuff : MonoBehaviour {

	void Trim()
	{
		GameObject[] child;
		child = GameObject.FindGameObjectsWithTag ("Transição");
		for (int i = 0; i < child.Length; i++) {
			for(int j = i+1; i<child.Length-1;i++){
				//if(child[i])
			}
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
