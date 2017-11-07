using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCube : MonoBehaviour {
	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "DestroyHitObject") {
			TextMesh missesText = GameObject.Find ("Miss Value").GetComponent<TextMesh>();
			int numberofMisses;

			numberofMisses = System.Int32.Parse(missesText.text);
			numberofMisses++;

			missesText.text = numberofMisses.ToString();

			DestroyObject (gameObject);//destroy the target the user missed

			Debug.Log ("Target not clicked on, so it was Destroyed");
		}
	}
}
