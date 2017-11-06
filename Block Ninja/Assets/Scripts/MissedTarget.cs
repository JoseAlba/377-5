using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissedTarget : MonoBehaviour {

	public TextMesh missesText;//linked through the unity interface 
	int numberofMisses;

	void OnMouseDown() {
		
		numberofMisses = System.Int32.Parse(missesText.text);
		numberofMisses++;

		missesText.text = numberofMisses.ToString();
		Debug.Log ("Missed Target!");

		if (numberofMisses >= 10) {
			Debug.Log ("Game Over!");
			Application.Quit ();//go back to the main menu***
		}
	}
}
