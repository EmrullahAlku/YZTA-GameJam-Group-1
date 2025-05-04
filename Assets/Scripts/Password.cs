using UnityEngine;

namespace LockButtonScript
{
    public class PasswordPanel : MonoBehaviour
    {
        public LockButtonPassword lockButton;
        public string correctPassword = "1234";
        private bool playerInRange = false;

        void Update()
        {
            if (playerInRange && Input.GetKeyDown(KeyCode.E))
            {
                OpenPasswordPrompt();
            }
        }

        void OpenPasswordPrompt()
        {
            string enteredPassword = "1234";

            if (enteredPassword == correctPassword)
            {
                Debug.Log("Password correct. Unlocking...");
                lockButton.password = true;
                lockButton.UnlockDoor();
            }
            else
            {
                Debug.Log("Wrong password!");
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
