
using UnityEngine;
using System.Linq;
namespace LockButtonScript {
public class LockButtonBlue : MonoBehaviour
{
    public bool isLocked;

    public bool hasBlueCard;

    public GameObject Door;

    public GameObject player;

    public void UnlockDoor()
    {

        hasBlueCard = player.GetComponent<PlayerInventory>().inventory.Contains(Items.blueCard);

        Debug.Log("Has Blue Card: " + hasBlueCard); // Debug log to check if the player has the red card
        if(!isLocked && player.GetComponent<PlayerInventory>().isBlueCardUsed) {
            Door.GetComponent<DoorScript.DoorBlue>().OpenDoor();
        }else if (hasBlueCard)
        {
            isLocked = false;
            Door.GetComponent<DoorScript.DoorBlue>().OpenDoor();
            player.GetComponent<PlayerInventory>().RemoveItem(Items.blueCard); // Remove the red card from the inventory
        }
    }
}

}

