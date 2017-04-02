using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cutscenes : MonoBehaviour {

    public List<Texture> cutsceneImages;
    private Texture currentImage;
    public List<AudioClip> cutsceneAudio;
    public List<int> faixasPorCutscene;
    private AudioClip currentAudio;
    private int indiceAudioAtual;
    private int indiceImagemAtual;
    private int indiceAudioTotal;
    private Player playerScript;
    private AudioSource cutsceneAudioSource;
    private RawImage cutsceneDisplayImage;
    private bool iniciado;
    public GameObject PostCutscene;
    private Camera cutsceneCamera;

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            iniciarCutscene(collider.gameObject);
        }
    }

	// Use this for initialization
	void Start () {
        cutsceneAudioSource = GameObject.FindGameObjectWithTag("CutsceneAudioSource").GetComponent<AudioSource>();
        cutsceneDisplayImage = GameObject.FindGameObjectWithTag("CutsceneImage").GetComponent<RawImage>();
        currentAudio = cutsceneAudio[0];
        currentImage = cutsceneImages[0];
        indiceImagemAtual = 0;
        indiceAudioAtual = 0;
        indiceAudioTotal = 0;
        iniciado = false;
        cutsceneCamera = this.gameObject.GetComponent<Camera>();
        if(PostCutscene!=null)
            PostCutscene.SetActive(false);
	}
	
    public void iniciarCutscene(GameObject player)
    {
        playerScript = player.GetComponent<Player>();
        playerScript.enabled =false;
        cutsceneDisplayImage.enabled = true;
        //cutsceneAudioSource.enabled = true;
        cutsceneAudioSource.Stop();
        cutsceneAudioSource.PlayOneShot(currentAudio, 1.0f);
        iniciado = true;
    }

    public void finalizarCutscene()
    {
        if (PostCutscene!=null)
            PostCutscene.SetActive(true);
        playerScript.enabled = true;
        cutsceneDisplayImage.enabled = false;
        //cutsceneAudioSource.enabled = false;
        Destroy(this.gameObject);
    }

    void updateImageAndAudio()
    {
        if(indiceAudioTotal >= cutsceneAudio.Count)
        {
            finalizarCutscene();
        }
        indiceAudioAtual++;
        indiceAudioTotal++;
        //if (indiceAudioAtual < faixasPorCutscene[indiceImagemAtual])
        //{
            
            cutsceneAudioSource.Stop();
            currentAudio = cutsceneAudio[indiceAudioTotal];
            cutsceneAudioSource.PlayOneShot(currentAudio, 1.0f);
        //}
        if(indiceAudioAtual >= faixasPorCutscene[indiceImagemAtual])
        {
            indiceAudioAtual = 0;
            indiceAudioTotal++;
            indiceImagemAtual++;
            currentImage = cutsceneImages[indiceImagemAtual];
            cutsceneDisplayImage.texture = currentImage;
        }
    }

    

	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Jump") && iniciado)
        {
            updateImageAndAudio();
        }
	}
}
