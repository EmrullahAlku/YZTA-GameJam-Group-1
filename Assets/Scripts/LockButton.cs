using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;
using UnityEngine;
namespace LockButtonScript {
public class LockButton : MonoBehaviour
{
    public bool isLocked;

    public bool redKey = true;

    public GameObject Door;

    public void UnlockDoor()
    {
        if (isLocked && redKey)
        {
            isLocked = !isLocked;
            Door.GetComponent<DoorScript.Door>().OpenDoor();
        }
    }
}

}

