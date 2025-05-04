
using System.Linq; // Linq kütüphanesi

using UnityEngine;
namespace LockButtonScript {
public class LockButton : MonoBehaviour
{
    public bool isLocked;


    public GameObject Door;

    public void UnlockDoor()
    {
        if (!isLocked) {
            Door.GetComponent<DoorScript.Door>().OpenDoor();
        }
        if (isLocked)
        {
            isLocked = !isLocked;
        }
    }
}

}

