using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class Save_Load{
    public static void Save(ColectibleInventory CI, StageChecker SC)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/slot1.sav", FileMode.Create);
        Data saveData = new Data(CI, SC);

        bf.Serialize(stream, saveData);
        stream.Close();
    }

    public static Data Load()
    {
        if(File.Exists(Application.persistentDataPath + "/slot1.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/slot1.sav", FileMode.Open);

            Data loadData = bf.Deserialize(stream) as Data;

            stream.Close();
            return loadData;
        }
        else
        {
            Debug.LogError("Erro, save não existe");
            return new Data();
        }
    }
}

[Serializable]
public class Data
{
    public string level;
    public List<int> collectibles;

    public Data(ColectibleInventory CI, StageChecker SC)
    {
        level = SC.GetCurrentLevel();
        collectibles = CI.getCollectiblesInInventory();
        //List<int> tempCollectibleList = CI.getCollectiblesInInventory();
        /*for (int i = 0; i < tempCollectibleList.Count; i++)
        {
            collectibles[i] = tempCollectibleList[i];
        }*/
    }

    public Data()
    {
        level = "Error";
        collectibles = new List<int>();
    }
}
