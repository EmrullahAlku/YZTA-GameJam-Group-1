using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoorScript
{
    [RequireComponent(typeof(AudioSource))]
    public class Door : MonoBehaviour
    {
        public bool open = false;                    
        public GameObject LockButton;                
        public float autoCloseDelay = 3.0f;          
        public float smooth = 1.0f;

        private SkinnedMeshRenderer blendShape;

        void Start()
        {
            blendShape = GetComponent<SkinnedMeshRenderer>();
            SetDoorKey(0); 
        }

        void Update()
        {
            SetDoorKey(open ? 1 : 0);
        }

        public void OpenDoor()
        {
            if (LockButton == null)
            {
                Debug.LogWarning("LockButton GameObject atanmadı.");
                return;
            }

            var lockButton = LockButton.GetComponent<LockButtonScript.LockButton>();

            if (lockButton != null && !lockButton.isLocked)
            {
                open = true;
                GetComponent<Collider>().enabled = false;
                StartCoroutine(AutoCloseDoor());
            }
            else
            {
                Debug.Log("Kapı kilitli! Şifre veya anahtar gerekiyor.");
            }
        }

        private void SetDoorKey(float value)
        {
            if (blendShape != null)
            {
                blendShape.SetBlendShapeWeight(0, value * 100);
            }
        }

        private IEnumerator AutoCloseDoor()
        {
            yield return new WaitForSeconds(autoCloseDelay);
            open = false;
            GetComponent<Collider>().enabled = true;
        }
    }
}
