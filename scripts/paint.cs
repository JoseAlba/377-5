using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paint : MonoBehaviour {

	public GameObject sphere;

	public int objects_spawned;

	Ray myray;
	RaycastHit hit;

	// Use this for initialization
	void Start () {
		objects_spawned = 0	;
		sphere.GetComponent<Renderer> ().material = Resources.Load("red",typeof(Material)) as Material;
	}

	// Update is called once per frame
	void Update () {
		myray = Camera.main.ScreenPointToRay (Input.mousePosition);

		if(Physics.Raycast(myray, out hit)){
			//left mouse button is down
			if (Input.GetKey (KeyCode.Mouse0)) {
				if (hit.collider.name.Equals ("red")) {
					sphere.GetComponent<Renderer> ().material = Resources.Load("red",typeof(Material)) as Material;
				} else if (hit.collider.name.Equals ("blue")) {
					sphere.GetComponent<Renderer> ().material = Resources.Load("blue",typeof(Material)) as Material;
				} else if (hit.collider.name.Equals ("green")) {
					sphere.GetComponent<Renderer> ().material = Resources.Load("green",typeof(Material)) as Material;
				} else if (hit.collider.name.Equals ("yellow")) {
					sphere.GetComponent<Renderer> ().material = Resources.Load("yellow",typeof(Material)) as Material;
				} else if (hit.collider.name.Equals ("board")) {
					Instantiate (sphere, hit.point, Quaternion.identity);
					objects_spawned++;
//				Debug.Log(objects_spawned);	
					Debug.Log (hit.collider.name);
				}
			}

			else if(Input.GetKey(KeyCode.Mouse1)){
				if (hit.collider.name.Equals ("sphere 1(Clone)")) {
					Destroy (hit.collider.gameObject);
					objects_spawned--;
				}
			}
		}
	}
}
