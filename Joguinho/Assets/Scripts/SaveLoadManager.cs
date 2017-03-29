using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadManager : MonoBehaviour {
    public GameObject PlayerPrefab;
	public void SaveGame()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Save_Load.Save(player.GetComponent<ColectibleInventory>(), player.GetComponent<StageChecker>());
    }

    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void LoadGame()
    {
        Data loadData = Save_Load.Load();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player == null)
        {
            player = Instantiate(PlayerPrefab);
        }
        ColectibleInventory CI = player.GetComponent<ColectibleInventory>();
        CI.clearCollectibles();
        CI.addCollectibles(loadData.collectibles);
        DontDestroyOnLoad(player);
        SceneManager.LoadScene(loadData.level);
    }
}
