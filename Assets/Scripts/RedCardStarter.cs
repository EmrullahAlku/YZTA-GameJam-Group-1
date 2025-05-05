using UnityEngine;

public class RedCardStarter : MonoBehaviour
{
    public GameObject itemToActivate;

    void Start()
    {
        itemToActivate.SetActive(true); // Sahnedeki inaktif objeyi aktif eder
        Debug.Log("Item aktif yapıldı.");
    }
}