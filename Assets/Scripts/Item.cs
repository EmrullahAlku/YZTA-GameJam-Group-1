using UnityEngine;

public class Item : MonoBehaviour
{
    public Items itemType = Items.redCard;

    void Start()
    {
        Debug.Log("Item script çalıştı, nesne aktif.");
    }
}