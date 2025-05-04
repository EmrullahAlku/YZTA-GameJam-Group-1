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

    public void Save(ref PlayerSaveData data)
    {
        data.position = transform.position; // Save the player's position
        data.timeCounter = timeCounter; // Save the time counter
        data.inventory = inventory; // Save the inventory items
        data.isRedCardUsed = isRedCardUsed; // Save red card status
        data.isBlueCardUsed = isBlueCardUsed; // Save blue card status
    }

    public void Load(PlayerSaveData data)
    {
        transform.position = data.position; // Load the player's position
        timeCounter = data.timeCounter; // Load the time counter
        inventory = data.inventory; // Load the inventory items
        isRedCardUsed = data.isRedCardUsed; // Load red card status
        isBlueCardUsed = data.isBlueCardUsed; // Load blue card status

        inventoryUI.UpdateInventoryUI(inventory); // Update the UI after loading
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