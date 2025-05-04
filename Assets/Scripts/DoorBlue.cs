using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
namespace DoorScript
{
	[RequireComponent(typeof(AudioSource))]


public class DoorBlue: MonoBehaviour {
	public bool open;

	public GameObject LockButton;
	public float smooth = 1.0f;	
	public float autoCloseDelay = 3.0f;

	private SkinnedMeshRenderer blendShape; 
	
	//public AudioSource asource;
	//public AudioClip openDoor,closeDoor;
	// Use this for initialization
	void Start () {
		//asource = GetComponent<AudioSource> ();
		blendShape = GetComponent<SkinnedMeshRenderer>();

		SetDoorKey(0);
	}
	
	// Update is called once per frame
	void Update () {
		if (open)
		{
			SetDoorKey(1);
		}
		else
		{
			SetDoorKey(0);
		}  
	}

	public void OpenDoor(){

		if ( LockButton == null || !LockButton.GetComponent<LockButtonScript.LockButtonBlue>().isLocked) {
			open = true;
			GetComponent<Collider>().enabled = false;
			//asource.clip = open?openDoor:closeDoor;
			//asource.Play ();
			StartCoroutine(AutoCloseDoor());
		}
		else {
			Debug.Log ("Door is Locked");
		}
	}

	private void SetDoorKey(float value)
        {
            if (blendShape != null)
            {
                blendShape.SetBlendShapeWeight(0, value * 100); // 0 ile 100 arasında bir değer ayarla
            }
        }

	private IEnumerator AutoCloseDoor()
        {
            yield return new WaitForSeconds(autoCloseDelay);
			GetComponent<Collider>().enabled = true;

            open = false; // Kapıyı kapat
        }
}
}