using UnityEngine;

public class Load : MonoBehaviour
{
    void Start()
    {
        if (SessionControl.Instance != null && SessionControl.Instance.ShouldLoadSave)
        {
            SaveSystem.Load();
        }
        else
        {
            Debug.Log("Yeni oyun baþlatýldý, kayýt yüklenmedi.");
        }
    }
}
