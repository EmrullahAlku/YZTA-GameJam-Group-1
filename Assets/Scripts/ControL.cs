using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ControlScript
{
public class ControlScript : MonoBehaviour {
	public float DistanceOpen=3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.forward, out hit, DistanceOpen)) {
			if (Input.GetKeyDown(KeyCode.E)) {
				var lockButton = hit.transform.GetComponent<LockButtonScript.LockButton>();
				if (lockButton != null) {
					lockButton.UnlockDoor();
					return;
				}

				var lockButtonRed = hit.transform.GetComponent<LockButtonScript.LockButtonRed>();
				if (lockButtonRed != null) {
					lockButtonRed.UnlockDoor();
					return;
				}

				var lockButtonBlue = hit.transform.GetComponent<LockButtonScript.LockButtonBlue>();
				if (lockButtonBlue != null) {
					lockButtonBlue.UnlockDoor();
					return;
				}

				var door = hit.transform.GetComponent<DoorScript.Door>();
				if (door != null) {
					door.OpenDoor();
					return;
				}

				var doorRed = hit.transform.GetComponent<DoorScript.DoorRed>();
				if (doorRed != null) {
					doorRed.OpenDoor();
					return;
				}

				var doorBlue = hit.transform.GetComponent<DoorScript.DoorBlue>();
				if (doorBlue != null) {
					doorBlue.OpenDoor();
					return;
				}
			}
		}
	}
}
}