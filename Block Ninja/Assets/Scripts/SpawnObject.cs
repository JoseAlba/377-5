using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnObject : MonoBehaviour {
    float spawnTime;
    float countdown;

    // Use this for initialization
    void Start () {
        spawnTime = 10.0f;
        countdown = spawnTime;
    }
	
	// Update is called once per frame
	void Update () {
		//simple countdown in seconds, resets upon hitting zero
        countdown -= Time.deltaTime;
        
		GetComponent<TextMesh>().text = Mathf.Round(countdown).ToString();

		if (countdown < 0) {
			countdown = spawnTime;//reset the timer

			createTarget (new Vector3 (-1f, 3f, -14f), new Vector3 (0, 600, 300));
			createTarget (new Vector3(-1f,3f,14f), new Vector3(0,600,-300));          
		}
    }

	private void createTarget(Vector3 spawnLocation, Vector3 forceApplied){
		GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		newCube.transform.position = spawnLocation;
		newCube.AddComponent<Rigidbody>();
		newCube.GetComponent<Rigidbody>().AddForce(forceApplied);
		newCube.AddComponent(System.Type.GetType("HitTarget"));//script for checking if the user hits the object
		newCube.AddComponent(System.Type.GetType("DestroyCube"));//script for destroying object off screen
	}
}