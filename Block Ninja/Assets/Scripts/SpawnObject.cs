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
        
		GetComponent<TextMesh>().text = "" + Mathf.Round(countdown);

		if (countdown < 0)
        {
            countdown = spawnTime;

			//create a new object that will be spawned whenever the countdown hits zero
			//will randomly select which side the object will spawn on... left or right
			GameObject newCube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
			newCube1.transform.position = new Vector3(-1f,3f,-14f);//spawn point right
			newCube1.AddComponent<Rigidbody>();//Add the rigidbody
			newCube1.GetComponent<Rigidbody>().AddForce(newCube1.transform.position + new Vector3(0,600,300));
			newCube1.transform.Rotate(new Vector3(0,0,500));
		
			newCube1.AddComponent(System.Type.GetType("HitTarget"));

			GameObject newCube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
			newCube2.transform.position = new Vector3(-1f,3f,14f);//spawn point left
			newCube2.AddComponent<Rigidbody>();//Add the rigidbody
			newCube2.GetComponent<Rigidbody>().AddForce(newCube1.transform.position + new Vector3(0,600,-300));
			newCube2.transform.Rotate(new Vector3(0,0,500));
			newCube2.AddComponent(System.Type.GetType("HitTarget"));
	    }
    }
}
