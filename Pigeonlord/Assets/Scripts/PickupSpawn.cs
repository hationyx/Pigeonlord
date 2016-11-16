using UnityEngine;
using System.Collections;

public class PickupSpawn : MonoBehaviour {


	private Vector2 spawnPos;
	private float spawnWait;
	private float spawnTime;

	void Awake () {
		spawnTime = Time.time + 1f;
	}



	void Update () {
		
		spawnWait = Random.Range (4f, 5f);
		SpawnPickup ();
	}

	//spawns the food pickups between 4 and 5 in a random range on the Y axis
	private void SpawnPickup () {

		if (Time.time > spawnTime) {
			Vector2 spawnPos;
			spawnPos.x = 13;
			spawnPos.y = Random.Range (-5f, 5f);
			GameObject pickup = Instantiate (Resources.Load("Pickup"), spawnPos, Quaternion.identity) as GameObject;
			spawnTime = Time.time + spawnWait;
		}
	}



}
