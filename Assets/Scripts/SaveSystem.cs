using UnityEngine;
using System.IO;
public class SaveSystem
{
    private static SaveData _saveData = new SaveData();

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
        File.WriteAllText(SaveFileName(), JsonUtility.ToJson(_saveData, true));
    }

    private static void HandleSaveData()
    {
        GameManager.Instance.player.GetComponent<PlayerInventory>().Save(ref _saveData.PlayerData);
    }
    
    public static void Load()
    {
        string saveContent = File.ReadAllText(SaveFileName());
        _saveData = JsonUtility.FromJson<SaveData>(saveContent);
        HandleLoadData();
    }

    private static void HandleLoadData()
    {
        GameManager.Instance.player.GetComponent<PlayerInventory>().Load(_saveData.PlayerData);
    }
}
