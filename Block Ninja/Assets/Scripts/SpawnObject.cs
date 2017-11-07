using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnObject : MonoBehaviour {
    float spawnTime;
    float countdown;
	float ranSpawnHeight;
	float ranForceY;
	float ranForceZ;
	int score;

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

		score = System.Int32.Parse(GameObject.Find ("Score Value").GetComponent<TextMesh>().text);

		if (countdown < 0) {
			if (score >= 5) {
				spawnTime = 5.0f;
			}

			countdown = spawnTime;//reset the timer
		
			if (score >= 5) {
				//spawns three targets when the users score is high enough
				ranSpawnHeight = (float) Random.Range (3, 15);
				ranForceY = (float) Random.Range (500, 600);
				ranForceZ = (float) Random.Range (200, 300);

				createTarget (new Vector3 (-1f, ranSpawnHeight, -14f), new Vector3 (0, ranForceY, ranForceZ));

				ranSpawnHeight = (float) Random.Range (3, 15);
				ranForceY = (float) Random.Range (500, 600);
				ranForceZ = (float) Random.Range (200, 300);

				createTarget (new Vector3(-1f,ranSpawnHeight,14f), new Vector3(0,ranForceY,(-1) * ranForceZ));  

				ranSpawnHeight = (float) Random.Range (3, 15);
				ranForceY = (float) Random.Range (500, 600);
				ranForceZ = (float) Random.Range (200, 300);

				createTarget (new Vector3(-1f,ranSpawnHeight,14f), new Vector3(0,ranForceY,(-1) * ranForceZ));   
			} else {
				//will only spawn two targets by default until the user gets a high enough score
				ranSpawnHeight = (float) Random.Range (3, 15);
				ranForceY = (float) Random.Range (500, 600);
				ranForceZ = (float) Random.Range (200, 300);

				createTarget (new Vector3 (-1f, ranSpawnHeight, -14f), new Vector3 (0, ranForceY, ranForceZ));

				ranSpawnHeight = (float) Random.Range (3, 15);
				ranForceY = (float) Random.Range (500, 600);
				ranForceZ = (float) Random.Range (200, 300);

				createTarget (new Vector3(-1f,ranSpawnHeight,14f), new Vector3(0,ranForceY,(-1) * ranForceZ));     
			}
		}
    }

	private void createTarget(Vector3 spawnLocation, Vector3 forceApplied) {
		GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);

		newCube.transform.position = spawnLocation;

		newCube.GetComponent<Renderer> ().material = Resources.Load ("Target", typeof(Material)) as Material;

		newCube.AddComponent(System.Type.GetType("HitTarget"));//script for checking if the user hits the object
		newCube.AddComponent(System.Type.GetType("DestroyCube"));//script for destroying object off screen

		newCube.AddComponent<Rigidbody>();
		newCube.GetComponent<Rigidbody>().AddForce(forceApplied);
	}
}