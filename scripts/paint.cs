using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paint : MonoBehaviour {

	public GameObject sphere;

	Ray myray;
	RaycastHit hit;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		myray = Camera.main.ScreenPointToRay (Input.mousePosition);

		if(Physics.Raycast(myray, out hit)){
			//left mouse button is down
			if(Input.GetKey(KeyCode.Mouse0)){
				Instantiate (sphere, hit.point, Quaternion.identity);
				Debug.Log (hit.point);
			}
		}
	}
}
