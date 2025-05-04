using System.Linq;
using UnityEngine;

namespace LockButtonScript
{
    public class LockButtonPassword : MonoBehaviour
    {
        public bool isLocked = true;
        public bool password = false;
        public GameObject Door;

        public void UnlockDoor()
        {
            if (!isLocked)
            {
                Door.GetComponent<DoorScript.Door>().OpenDoor();
            }
            else if (password)
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