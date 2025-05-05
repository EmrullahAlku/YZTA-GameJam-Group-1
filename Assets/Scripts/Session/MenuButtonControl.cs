using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonControl : MonoBehaviour
{
    public Button LoadButton;

    private void Start()
    {
        if (!File.Exists(SaveSystem.SaveFileName()))
        {
            LoadButton.interactable = false;
        }
    }
    public void OnNewGameClicked()
    {
        SessionControl.Instance.ShouldLoadSave = false;
        SceneManager.LoadScene(0); // Baþlangýç sahnesi
    }

    public void OnLoadClicked()
    {
        string json = File.ReadAllText(SaveSystem.SaveFileName());
        SaveSystem.SaveData data = JsonUtility.FromJson<SaveSystem.SaveData>(json);

        SessionControl.Instance.ShouldLoadSave = true;
        SceneManager.LoadScene(0);
    }
}
