using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTarget : MonoBehaviour {
	void OnMouseDown() {
		createExplosionEyeCandy (gameObject.transform.position, new Vector3(0,0,100));
		createExplosionEyeCandy (gameObject.transform.position, new Vector3(0,0,-100));

		DestroyObject (gameObject);//destroy the main target object

		updateScore ();
	}

	private void createExplosionEyeCandy(Vector3 spawnLocation, Vector3 forceApplied) {
		GameObject subCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		subCube.GetComponent<Collider>().isTrigger = true;
		subCube.tag = "ExplosionEyeCandy";

		subCube.GetComponent<Renderer> ().material = Resources.Load ("DestroyObject", typeof(Material)) as Material;

		subCube.transform.position = spawnLocation;
		subCube.transform.localScale = new Vector3 (1f,1f,0.5f);//changing the size of explosion eye candy

		subCube.AddComponent<Rigidbody>();
		subCube.GetComponent<Rigidbody>().AddForce(forceApplied);
	}

	private void updateScore() {
		Debug.Log ("Hit Target");

		TextMesh scoreText = GameObject.Find ("Score Value").GetComponent<TextMesh>();

		int score = System.Int32.Parse(scoreText.text);
		score++;

		scoreText.text = score.ToString();
	}
}