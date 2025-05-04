using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (!Application.isPlaying) return null;
            if (instance == null)
            {
                Instantiate(Resources.Load<GameManager>("GameManager"));
            }
            return instance;
        }
    }
    public GameObject player;
   
   private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (Keyboard.current.numpad0Key.wasPressedThisFrame)
        {
            SaveSystem.Save();
            Debug.Log("Game Saved");
        }
        if (Keyboard.current.numpad1Key.wasPressedThisFrame)
        {
            SaveSystem.Load();
            Debug.Log("Game Loaded");
        }
    }


}
