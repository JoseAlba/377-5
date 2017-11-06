using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCube : MonoBehaviour {
	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "DestroyHitObject") {
			DestroyObject (gameObject);//destroy the target the user missed
			Debug.Log ("Target not clicked on, so it was Destroyed");
		}
	}
}
