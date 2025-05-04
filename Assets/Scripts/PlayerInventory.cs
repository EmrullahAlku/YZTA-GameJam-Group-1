using System;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public Items[] inventory= new Items[8]; // Array to hold the items in the inventory

    public InventoryUI inventoryUI; // Reference to the InventoryUI script

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