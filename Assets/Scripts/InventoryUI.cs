using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    //public Items[] PlayerInventory; // Array to hold the items in the inventory
    public Sprite[] InventorySlots = new Sprite[8]; // Array to hold the inventory slot images
    public Sprite redCardSprite; // Assign the red card sprite in the inspector
    public Sprite blueCardSprite; // Assign the red card sprite in the inspector
    public Sprite obj1Sprite; // Assign the red card sprite in the inspector
    public Sprite obj2Sprite; // Assign the red card sprite in the inspector
    public Sprite obj3Sprite; // Assign the red card sprite in the inspector
    public Sprite obj4Sprite; // Assign the red card sprite in the inspector
    public Sprite obj5Sprite; // Assign the red card sprite in the inspector


   public void UpdateInventoryUI(Items[] PlayerInventory)
    {
        Debug.Log("Inventory UI Updated: " + PlayerInventory.Length); // Debug log to check if the function is called
        int slotCount = Mathf.Min(PlayerInventory.Length, InventorySlots.Length);
        Debug.Log("Slot Count: " + slotCount); // Debug log to check the number of slots

        for (int i = 0; i < slotCount; i++)
        {
                Debug.Log("Inventory Slot " + i + ": " + PlayerInventory[i]); // Debug log to check inventory items
                switch (PlayerInventory[i])
                {
                    case Items.redCard:
                        InventorySlots[i] = redCardSprite;
                        Debug.Log("Red Card assigned to slot " + i); // Debug log for red card
                        break;
                    case Items.blueCard:
                        InventorySlots[i] = blueCardSprite;
                        Debug.Log("Blue Card assigned to slot " + i); // Debug log for blue card
                        break;
                    case Items.Obj1:
                        InventorySlots[i] = obj1Sprite;
                        break;
                    case Items.Obj2:
                        InventorySlots[i] = obj2Sprite;
                        break;
                    case Items.Obj3:
                        InventorySlots[i] = obj3Sprite;
                        break;
                    case Items.Obj4:
                        InventorySlots[i] = obj4Sprite;
                        break;
                    case Items.Obj5:
                        InventorySlots[i] = obj5Sprite;
                        break;
                    default:   
                        InventorySlots[i] = null;
                        break;
                }
        }
        ClearImages(); // Clear previous images before creating new ones
        CreateImage(InventorySlots); // Create an image for the first slot as an example
    }

    private void CreateImage(Sprite[] sprite)
    {
        for (int i = 0; i < sprite.Length; i++)
        {
            if (sprite[i] != null)
            {
                Debug.Log("Creating image for slot " + i + ": " + sprite[i]); // Debug log for image creation
                // Create a new GameObject for the image and set its properties
                GameObject imageObject = new GameObject("InventoryImage" + i);
                Image image = imageObject.AddComponent<Image>();
                image.sprite = sprite[i];
                imageObject.transform.SetParent(this.transform); // Set parent to the inventory UI
            }
        }
    }
    private void ClearImages()
    {
        // Destroy all child objects of the inventory UI to clear previous images
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }}
}
