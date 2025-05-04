using UnityEngine;
using System.IO;
public class SaveSystem
{
    private static SaveData saveData = new SaveData();

    [System.Serializable]
    
    public struct SaveData
    {
        public PlayerSaveData PlayerData;
    }

    public static string SaveFileName(){
        string saveFile = Application.persistentDataPath + "/saveData.json";
        return saveFile;
    }

    public static void Save()
{
        HandleSaveData();
        string json = JsonUtility.ToJson(saveData, true);
    }

    private static void HandleSaveData()
    {
        //GameManager.Instance.Player.Save(ref saveData.PlayerData);
    }
    
    public static void Load()
    {
        string saveContent = File.ReadAllText(SaveFileName());
        saveData = JsonUtility.FromJson<SaveData>(saveContent);
        HandleLoadData();
    }

    private static void HandleLoadData()
    {
        //GameManager.Instance.Player.Load(ref saveData.PlayerData);
    }
}
