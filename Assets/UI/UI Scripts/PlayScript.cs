using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour {

        
	// Use this for initialization
	public void onClick()
    {
        SceneManager.LoadScene("Lv1");
    }
}
