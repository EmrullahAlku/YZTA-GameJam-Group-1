using System.Linq;
using UnityEngine;

namespace LockButtonScript
{
    public class LockButton : MonoBehaviour
    {
        public bool isLocked = true;
        public bool redKey = false;
        public GameObject Door;

        public void UnlockDoor()
        {
            if (!isLocked)
            {
                Door.GetComponent<DoorScript.Door>().OpenDoor();
            }
            else if (redKey)
            {
                isLocked = false;
                Door.GetComponent<DoorScript.Door>().OpenDoor();
            }
            else
            {
                Debug.Log("Kapı kilitli! Anahtar veya şifre gerekli.");
            }
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                UnlockDoor();
            }
        }
    }
}

