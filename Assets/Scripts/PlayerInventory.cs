using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem.Interactions; // TextMeshPro kullanımı

public class PlayerInventory : MonoBehaviour
{

    public Items[] inventory= new Items[8]; // Array to hold the items in the inventory

    public InventoryUI inventoryUI; // Reference to the InventoryUI script

    public float timeCounter = 0f; // Sayaç (oyuncunun hareket ettiği süre)
    private bool isTimerRunning = false; // Timer durumu
    public TextMeshProUGUI timeCounterText; // UI Text component to display the time counter

    public bool isRedCardUsed = false; // Red card durumu
    public bool isBlueCardUsed = false; // Blue card durumu

    void Start()
    {
        timeCounterText.text = "Starting Time: 0 seconds";
    }

    void Update()
    {
        // E tuşuna basıldığında sayaç başlasın
        if (Input.GetKeyDown(KeyCode.E))
        {
            isTimerRunning = true; // Sayaç çalışmaya başlar
        }

        // Sayaç çalışıyorsa zamanı artır
        if (isTimerRunning)
        {
            timeCounter += Time.deltaTime;

            // Sayaç bilgisini UI'da göster
            timeCounterText.text = "Geçen Süre: " + Mathf.FloorToInt(timeCounter) + " seconds";
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Item"))
        {
            // Check if the inventory has space
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] == Items.empty)
                {
                    // Add the item to the inventory
                    inventory[i] = collision.gameObject.GetComponent<Item>().itemType;
                    Destroy(collision.gameObject);
                    break;
                }
            }
            inventoryUI.UpdateInventoryUI(inventory); 

        }
        
    }

    public void RemoveItem(Items itemToDelete)
    {
        if (itemToDelete == Items.redCard) // Red card kullanıldıysa
        {
            isRedCardUsed = true; // Red card kullanıldı
        }
        else if (itemToDelete == Items.blueCard) // Blue card kullanıldıysa
        {
            isBlueCardUsed = true; // Blue card kullanıldı
        }
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == itemToDelete)
            {
                inventory[i] = Items.empty; // Set the slot to empty
                break;
            }
        }
        inventoryUI.UpdateInventoryUI(inventory); // Update the UI after deletion
    }

    public void Save()
    {
        PlayerSaveData saveData = new PlayerSaveData
        {
            position = transform.position,
            timeCounter = timeCounter,
            inventory = inventory,
            isRedCardUsed = isRedCardUsed,
            isBlueCardUsed = isBlueCardUsed
        };

        string json = JsonUtility.ToJson(saveData);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/playerSaveData.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/playerSaveData.json";
        if (System.IO.File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            PlayerSaveData saveData = JsonUtility.FromJson<PlayerSaveData>(json);

            transform.position = saveData.position;
            timeCounter = saveData.timeCounter;
            inventory = saveData.inventory;
            isRedCardUsed = saveData.isRedCardUsed;
            isBlueCardUsed = saveData.isBlueCardUsed;

            inventoryUI.UpdateInventoryUI(inventory); // Update the UI after loading
        }
    }

}

public enum Items
{
    empty,
    redCard,
    blueCard,
    Obj1,
    Obj2,
    Obj3,
    Obj4,
    Obj5,
}

[System.Serializable]
public struct PlayerSaveData
{
    public Vector3 position;
    public float timeCounter;
    public Items[] inventory;
    public bool isRedCardUsed;
    public bool isBlueCardUsed;
}