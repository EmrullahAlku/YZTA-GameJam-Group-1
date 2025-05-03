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
		if (Physics.Raycast (transform.position, transform.forward, out hit, DistanceOpen)) {
            if (hit.transform.GetComponent<LockButtonScript.LockButton> ()) {
				if (Input.GetKeyDown(KeyCode.E)) {
					hit.transform.GetComponent<LockButtonScript.LockButton> ().UnlockDoor ();
				}
			}
			else if (hit.transform.GetComponent<DoorScript.Door> ()) {
				if (Input.GetKeyDown(KeyCode.E))
					hit.transform.GetComponent<DoorScript.Door> ().OpenDoor();
				}
				
			}
		
	}
}
}