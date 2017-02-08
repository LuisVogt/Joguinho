using UnityEngine;
using System.Collections;

public class MakeSides : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		Instantiate(this.gameObject.transform.GetChild(1),this.transform.position- new Vector3(0,0,-0.5f),Quaternion.identity,this.gameObject.transform);
		Instantiate(this.gameObject.transform.GetChild(1),this.transform.position- new Vector3(0.5f,0,0),Quaternion.Euler(new Vector3(0,90,0)),this.gameObject.transform);
		Instantiate(this.gameObject.transform.GetChild(1),this.transform.position- new Vector3(-0.5f,0,0),Quaternion.Euler(new Vector3(0,90,0)),this.gameObject.transform);
		Destroy(this);
	}
}
