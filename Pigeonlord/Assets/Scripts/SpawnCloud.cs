using UnityEngine;
using System.Collections;

public class SpawnCloud : MonoBehaviour {

	private Vector2 spawnPos;
	private float spawnWait;
	private float spawnWait2;
	private float spawnWait3;
	private float spawnWait4;
	private float spawnWait5;
	private float spawnTime;
	private float spawnTime2;
	private float spawnTime3;
	private float spawnTime4;
	private float spawnTime5;


	void Awake () {
		spawnWait = 5f;
		spawnWait2 = 8f;
		spawnWait3 = 7f;
		spawnWait4 = 9f;
		spawnWait5 = 12f;
		//make sure everything doesn't spawn at the same time at the start?
		spawnTime2 = Time.time + 2f;
		spawnTime3 = Time.time + 4f;
		spawnTime4 = Time.time + 6f;
		spawnTime5 = Time.time + 7f;
	}
	void Start () {
	}


	void Update () {

		SpawnClouds ();
	}

	private void SpawnClouds () {

		if (Time.time > spawnTime) {

			Vector2 spawnPos;
			spawnPos.x = 13;
			spawnPos.y = Random.Range (-6f, 6f);
			GameObject enemy = Instantiate (Resources.Load("Cloud1"), spawnPos, Quaternion.identity) as GameObject;
			spawnTime = Time.time + spawnWait;
		}

		if (Time.time > spawnTime2) {

			Vector2 spawnPos;
			spawnPos.x = 13;
			spawnPos.y = Random.Range (-6f, 6f);
			GameObject enemy = Instantiate (Resources.Load("Cloud2"), spawnPos, Quaternion.identity) as GameObject;
			spawnTime2 = Time.time + spawnWait2;
		}

		if (Time.time > spawnTime3) {

			Vector2 spawnPos;
			spawnPos.x = 13;
			spawnPos.y = Random.Range (-6f, 6f);
			GameObject enemy = Instantiate (Resources.Load("Cloud3"), spawnPos, Quaternion.identity) as GameObject;
			spawnTime3 = Time.time + spawnWait3;
		}


		if (Time.time > spawnTime4) {

			Vector2 spawnPos;
			spawnPos.x = 13;
			spawnPos.y = Random.Range (-6f, 6f);
			GameObject enemy = Instantiate (Resources.Load("Cloud4"), spawnPos, Quaternion.identity) as GameObject;
			spawnTime4 = Time.time + spawnWait4;
		}


		if (Time.time > spawnTime5) {

			Vector2 spawnPos;
			spawnPos.x = 13;
			spawnPos.y = Random.Range (-6f, 6f);
			GameObject enemy = Instantiate (Resources.Load("Cloud5"), spawnPos, Quaternion.identity) as GameObject;
			spawnTime5 = Time.time + spawnWait5;
		}
	}
}
