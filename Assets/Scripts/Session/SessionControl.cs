using UnityEngine;

public class SessionControl : MonoBehaviour
{
    public static SessionControl Instance;
    public bool ShouldLoadSave = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
