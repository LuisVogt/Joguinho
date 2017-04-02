using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriarVoiceOver : MonoBehaviour {

    public AudioClip Audio;
    private AudioSource currentAudioSource;

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag=="Player")
        {
            currentAudioSource.PlayOneShot(Audio, 1.0f);
        }
        Destroy(this);
    }

    // Use this for initialization
    void Start () {
        currentAudioSource = GameObject.FindGameObjectWithTag("CutsceneAudioSource").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
