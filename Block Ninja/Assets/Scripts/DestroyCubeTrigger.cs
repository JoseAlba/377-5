using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCubeTrigger : MonoBehaviour {
	void OnTriggerEnter(Collider collider) {
		if(collider.tag == "ExplosionEyeCandy") {
			DestroyObject (collider.gameObject);//destroy the eye candy
			Debug.Log ("Eye Candy Cube Destroyed");
		}
	}
}