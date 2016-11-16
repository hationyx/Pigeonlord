using UnityEngine;
using System.Collections;

public class SpawnRapidFire : MonoBehaviour {
	
	private Vector2 spawnPos;
	private float spawnWait;
	private float spawnTime;


	void Awake () {
		spawnTime = Time.time + 5f;
	}


	void Update () {
		spawnWait = Random.Range (20f, 40f);
		SpawnRapidFireUpgrade ();
	}

	private void SpawnRapidFireUpgrade () {

		if (Time.time > spawnTime) {

			Vector2 spawnPos;
			spawnPos.x = 13;
			spawnPos.y = Random.Range (-5f, 5f);
			GameObject enemy = Instantiate (Resources.Load("RapidFirePickup"), spawnPos, Quaternion.identity) as GameObject;
			spawnTime = Time.time + spawnWait;
		}
	}
}
