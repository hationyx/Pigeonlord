using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

	private Vector2 spawnPos;
	private float spawnWait = 0.3f;
	private float spawnTime;
	// Use this for initialization
	void Start () {
	
	}


	void Update () {

		Spawn ();

	}

	private void Spawn () {

		if (Time.time > spawnTime) {

		Vector2 spawnPos;
		spawnPos.x = 10;
		spawnPos.y = Random.Range (-5, 5);
		GameObject enemy = Instantiate (Resources.Load("Enemies"), spawnPos, Quaternion.identity) as GameObject;
		spawnTime = Time.time + spawnWait;
		}
	}
}
