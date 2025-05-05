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
            Debug.Log("Yeni oyun ba�lat�ld�, kay�t y�klenmedi.");
        }
    }
}
