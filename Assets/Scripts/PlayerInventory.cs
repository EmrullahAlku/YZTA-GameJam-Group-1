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

    public bool isPuzzle1Completed = false; // Puzzle 1 durumu
    public bool isPuzzle2Completed = false; // Puzzle 2 durumu
    public bool isPuzzle3Completed = false; // Puzzle 3 durumu
    public bool isPuzzle4Completed = false; // Puzzle 4 durumu
    public bool isPuzzle5Completed = false; // Puzzle 5 durumu
    public bool isPuzzle6Completed = false; // Puzzle 6 durumu
    public bool isPuzzle7Completed = false; // Puzzle 7 durumu

    private static PlayerInventory instance;


    private void Awake()
    {
if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Oyuncu nesnesini sahneler arasında koru
        }
        else
        {
            Destroy(gameObject); // Zaten bir oyuncu nesnesi varsa, yenisini yok et
        }    }

    void Start()
    {
        timeCounterText.text = "Starting Time: 0 seconds";
        Debug.Log("Persistent Data Path: " + Application.persistentDataPath);
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
    
        data.isPuzzle1Completed = isPuzzle1Completed;
        data.isPuzzle2Completed = isPuzzle2Completed;
        data.isPuzzle3Completed = isPuzzle3Completed;
        data.isPuzzle4Completed = isPuzzle4Completed;
        data.isPuzzle5Completed = isPuzzle5Completed;
        data.isPuzzle6Completed = isPuzzle6Completed;
        data.isPuzzle7Completed = isPuzzle7Completed;
    }

    public void Load(PlayerSaveData data)
    {
        transform.position = data.position; // Load the player's position
        timeCounter = data.timeCounter; // Load the time counter
        inventory = data.inventory; // Load the inventory items
        isRedCardUsed = data.isRedCardUsed; // Load red card status
        isBlueCardUsed = data.isBlueCardUsed; // Load blue card status

        isPuzzle1Completed = data.isPuzzle1Completed;
        isPuzzle2Completed = data.isPuzzle2Completed;
        isPuzzle3Completed = data.isPuzzle3Completed;
        isPuzzle4Completed = data.isPuzzle4Completed;
        isPuzzle5Completed = data.isPuzzle5Completed;
        isPuzzle6Completed = data.isPuzzle6Completed;
        isPuzzle7Completed = data.isPuzzle7Completed;

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

    public bool isPuzzle1Completed;
    public bool isPuzzle2Completed; 
    public bool isPuzzle3Completed;
    public bool isPuzzle4Completed;
    public bool isPuzzle5Completed;
    public bool isPuzzle6Completed;
    public bool isPuzzle7Completed;
}