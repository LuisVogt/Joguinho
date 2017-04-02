using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StageChecker:MonoBehaviour{
    private string currentLevel;

    public string GetCurrentLevel()
    {
        return currentLevel;
    }

    public void RefreshCurrentLevel()
    {
        currentLevel = SceneManager.GetActiveScene().name;
    }
}
