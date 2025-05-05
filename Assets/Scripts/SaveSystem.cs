using UnityEngine;
using System.IO;
using Unity.VisualScripting;
public class SaveSystem
{
    private static SaveData _saveData = new SaveData();

    [System.Serializable]
    
    public struct SaveData
    {
        public PlayerSaveData PlayerData;
    }

    public static void Save()
{
        HandleSaveData();
        File.WriteAllText(GenerateSaveFileName(), JsonUtility.ToJson(_saveData, true));
    }

    public static void SaveFirst()
    {
        HandleSaveData();
        File.WriteAllText(FirstSaveFileName(), JsonUtility.ToJson(_saveData, true));
    }

    private static void HandleSaveData()
    {
        GameManager.Instance.player.GetComponent<PlayerInventory>().Save(ref _saveData.PlayerData);
    }

    public static string[] GetAllSaveFiles()
{
    string[] saveFiles = Directory.GetFiles(Application.persistentDataPath, "save_*.json");
    System.Array.Sort(saveFiles); // Dosyaları alfabetik olarak sıralar (tarih sırasına göre)
    return saveFiles;
}

    public static string GenerateSaveFileName()
{
    string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"); // Tarih ve saat damgası
    string saveFile = Application.persistentDataPath + $"/save_{timestamp}.json";
    return saveFile;
}

public static string FirstSaveFileName()
{
    string saveFile = Application.persistentDataPath + "/save_1.json";
        return saveFile;
}
    
    public static void Load()
{
    string[] saveFiles = GetAllSaveFiles();
    
    if (saveFiles.Length > 0)
    {
        string latestSaveFile = saveFiles[saveFiles.Length - 1]; // En son kaydı al
        string saveContent = File.ReadAllText(latestSaveFile);
        _saveData = JsonUtility.FromJson<SaveData>(saveContent);
        HandleLoadData();
        Debug.Log($"Game loaded from: {latestSaveFile}");

        // Son yüklenen dosya dışındaki tüm kayıt dosyalarını sil
        foreach (string saveFile in saveFiles)
        {
            if (saveFile == latestSaveFile)
            {
                File.Delete(saveFile);
                Debug.Log($"Deleted new save file: {saveFile}");
                string[] afterDeleteSaveFiles = GetAllSaveFiles();
                if (afterDeleteSaveFiles.Length == 0)
        {
            SaveFirst(); // İlk kaydı yap
        }
                
            }
        }
    }
    
    
}

    private static void HandleLoadData()
    {
        GameManager.Instance.player.GetComponent<PlayerInventory>().Load(_saveData.PlayerData);
    }
}
