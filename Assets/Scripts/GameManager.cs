using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            SaveSystem.Save();
            Debug.Log("Game Saved");
        }
        if (Keyboard.current.f1Key.wasPressedThisFrame)
        {
            SaveSystem.Load();
            Debug.Log("Game Loaded");
        }
    }

    private void Awake()
    {
    }


}
