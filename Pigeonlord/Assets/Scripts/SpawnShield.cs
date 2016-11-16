using UnityEngine;
using System.Collections;

public class SpawnShield : MonoBehaviour {

	private Vector2 spawnPos;
	private float spawnWait;
	private float spawnTime;

	//upgrades spawn at a specific time at the start to give the player a go straight away
	void Awake () {
		spawnTime = Time.time + 3f;
	}


	void Update () {
		
		spawnWait = Random.Range (20f, 40f);
		SpawnShieldUpgrade ();
	}

	//spawns the upgrades, possibly different times for each one (rapid fire is overpowered!), don't know yet
	private void SpawnShieldUpgrade () {

		if (Time.time > spawnTime) 
		{
			Vector2 spawnPos;
			spawnPos.x = 13;
			spawnPos.y = Random.Range (-5f, 5f);
			GameObject enemy = Instantiate (Resources.Load("ShieldPickup"), spawnPos, Quaternion.identity) as GameObject;
			spawnTime = Time.time + spawnWait;
		}
	}
}
