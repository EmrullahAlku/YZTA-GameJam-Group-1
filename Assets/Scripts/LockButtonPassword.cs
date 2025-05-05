using System.Linq;
using UnityEngine;

namespace LockButtonScript
{
    public class LockButtonPassword : MonoBehaviour
    {
        public bool isLocked = true;
        public PasswordUI passwordUI; // PasswordUI scriptine referans
        private bool playerInRange = false;
        public GameObject Door;

        public string correctPassword; // Doğru şifre

        public void UnlockDoor()
        {
            isLocked = false;
            Door.GetComponent<DoorScript.DoorPassword>().OpenDoor();
        }

        void Update()
        {
            if (playerInRange && Input.GetKeyDown(KeyCode.E))
            {
                passwordUI.OpenPasswordPanel();
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                playerInRange = true;
        }

        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
                playerInRange = false;
        }
    }

    }
