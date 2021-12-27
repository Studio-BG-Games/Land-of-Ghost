using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using PixelCrushers;

public class GameSaver : ScriptableObject
{
    [SerializeField] private InventorySO _inventorySO;
    [SerializeField] private List<LevelData> _levels;
    [SerializeField] private string _mainFolder = "/game_save_1";
    private bool IsDirectoryExist(string path)
    {
        return Directory.Exists(Application.persistentDataPath + path);
    }
    private bool IsFileExist(string path)
    {
        return File.Exists(Application.persistentDataPath + path);
    }
    private void CreateDirectory(string path)
    {
        Directory.CreateDirectory(Application.persistentDataPath + path);
    }
    public void Save()
    {
        SaveData(_inventorySO, "inventory_data", "inventory_save.save");
        var i = 0;
        foreach (var level in _levels)
        {
            i++;
            SaveData(level, "level_data", "level" + level.LvlNumber.ToString() + ".save");
        }
    }
    public void Load()
    {
        LoadData(_inventorySO, "inventory_data", "inventory_save.save");
        var i = 0;
        foreach (var level in _levels)
        {
            i++;
            LoadData(level, "level_data", "level" + level.LvlNumber.ToString() + ".save");
        }
    }
    private void SaveData(object obj,string folder,string fileName)
    {
        folder = "/" + folder;
        fileName = "/" + fileName;
        if (!IsDirectoryExist(_mainFolder + folder))
        {
            CreateDirectory(_mainFolder + folder);
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + _mainFolder + folder + fileName);
        var json = JsonUtility.ToJson(obj);
        bf.Serialize(file, json);
        file.Close();
    }
    private void LoadData(object obj,string folder,string fileName)
    {
        folder = "/" + folder;
        fileName = "/" + fileName;
        if (!IsDirectoryExist(_mainFolder + folder))
            return;
        BinaryFormatter bf = new BinaryFormatter();
        if (IsFileExist(_mainFolder + folder + fileName))
        {
            FileStream file = File.Open(Application.persistentDataPath + _mainFolder + folder + fileName, FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), obj);
            file.Close();
        }
    }
}
