using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OtherScripts : MonoBehaviour {

    public Canvas controlMenu;
    public Canvas aboutMenu;
    public Canvas startCanvas;
    
    

	// Use this for initialization
	void Start () {
        controlMenu = controlMenu.GetComponent<Canvas>();
        aboutMenu = aboutMenu.GetComponent<Canvas>();
        startCanvas = startCanvas.GetComponent<Canvas>();
        controlMenu.enabled = false;
        aboutMenu.enabled = false;
	}
	
    public void aboutClick()
    {
        aboutMenu.enabled = true;
        controlMenu.enabled = false;
    }

    public void controlClick()
    {
        Debug.Log("Lol");
        aboutMenu.enabled = false;
        controlMenu.enabled = true;
    }

    public void returnClick()
    {
        aboutMenu.enabled = false;
        controlMenu.enabled = false;
    }
}
