using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaveHandler : MonoBehaviour
{
    public static SaveHandler instance;
    private Data data;

    private void Awake()
    {
        data = GetComponent<Data>();
        SaveSystem.Init();
        instance = this;

        Load();
    }

    public void Save()
    {
        // Save
        SaveData saveData = new SaveData
        {
            Name = data.Name,
            LV = data.LV,
            HP = data.HP,
            maxHP = data.maxHP,
            G = data.G
        };
        string json = JsonUtility.ToJson(saveData);
        SaveSystem.Save(json);

        Debug.Log("Saved!");
    }

    public void Load()
    {
        // Load
        string saveString = SaveSystem.Load();
        if (saveString != "")
        {
            Debug.Log("Loaded: " + saveString);

            SaveData saveData = JsonUtility.FromJson<SaveData>(saveString);

            data.Name = saveData.Name;
            data.LV = saveData.LV;
            data.HP = saveData.HP;
            data.maxHP = saveData.maxHP;
            data.G = saveData.G;
        }
        else
        {
            Debug.Log("No save");
        }
    }

    private class SaveData
    {
        public string Name;
        public int LV, HP, maxHP, G;
    }
}