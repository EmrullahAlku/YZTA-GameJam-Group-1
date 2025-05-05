
using UnityEngine;
using System.Linq;
namespace LockButtonScript {
public class LockButtonRed : MonoBehaviour
{
    public bool isLocked;

    public bool hasRedCard;

    public GameObject Door;

    public GameObject player;

    public void UnlockDoor()
    {
        hasRedCard = player.GetComponent<PlayerInventory>().inventory.Contains(Items.redCard);

        Debug.Log("Has Red Card: " + hasRedCard); // Debug log to check if the player has the red card
        if(!isLocked && player.GetComponent<PlayerInventory>().isRedCardUsed) {
            Door.GetComponent<DoorScript.DoorRed>().OpenDoor();
        } else if (hasRedCard)
        {
            isLocked = false;
            Door.GetComponent<DoorScript.DoorRed>().OpenDoor();
            player.GetComponent<PlayerInventory>().RemoveItem(Items.redCard); // Remove the red card from the inventory
        }
    }
}

}

