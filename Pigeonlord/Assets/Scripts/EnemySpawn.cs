using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

	private Vector2 spawnPos;
	private Vector2 spawnPos2;
	private Vector2 spawnPos3;
	private Vector2 spawnPos4;
	private Vector2 spawnPos5;
	private float spawnWait;
	private float spawnWait2;
	private float spawnWaitLonger;
	private float spawnWaitLonger2;
	private float spawnTime;
	private float spawnTime2;
	private float spawnTimeLonger;
	private float spawnTimeLonger2;


	private float gameTime = 0f;

	void Awake () {
		
	}

	void Start () {
	
	}


	void Update () {

		//the game gets harder as the time goes on, engaging different spawn rates and enemy types
		gameTime += Time.deltaTime;
		if (gameTime < 15f) {
		SpawnEnemy ();
		}

		if (gameTime > 15f && gameTime < 30f) {
			SpawnEnemy2 ();
		}

		if (gameTime > 30f && gameTime < 45f) {
			SpawnEnemy3 ();
		}

		if (gameTime > 45f && gameTime < 65f) {
			SpawnEnemy4 ();
		}

		if (gameTime > 65f && gameTime < 85f) {
			SpawnEnemy5 ();
		}

		if (gameTime > 85f && gameTime < 40000f) {
			SpawnEnemy6 ();
		}
	
	}

	//these are the different spawn rates, they change a bit each time and more enemies come in, some on the same timer some on different timers
	private void SpawnEnemy () {

		if (Time.timeSinceLevelLoad > spawnTime) {
		spawnWait = Random.Range (2f, 6f);
		spawnPos.x = 13;
		spawnPos.y = Random.Range (-5f, 5f);
		GameObject enemy = Instantiate (Resources.Load("Enemy"), spawnPos, Quaternion.identity) as GameObject;
		spawnTime = Time.timeSinceLevelLoad + spawnWait;
		}
	}

	private void SpawnEnemy2 () {

		if (Time.timeSinceLevelLoad > spawnTime) {
			spawnWait = Random.Range (1f, 5f);
			spawnPos2.x = 13;
			spawnPos2.y = Random.Range(-5f, 5f);
			spawnPos.x = 13;
			spawnPos.y = Random.Range (-5f, 5f);
			GameObject enemy = Instantiate (Resources.Load("Enemy"), spawnPos, Quaternion.identity) as GameObject;
			GameObject enemy2 = Instantiate (Resources.Load("Enemy2"), spawnPos2, Quaternion.identity) as GameObject;
			spawnTime = Time.timeSinceLevelLoad + spawnWait;
		}
	}

	private void SpawnEnemy3 () {
		//easy enemy spawn rates
		if (Time.timeSinceLevelLoad > spawnTime) {
			spawnWait = Random.Range (0.5f, 4f);
			spawnPos2.x = 13;
			spawnPos2.y = Random.Range(-5f, 5f);
			spawnPos.x = 13;
			spawnPos.y = Random.Range (-5f, 5f);
			GameObject enemy = Instantiate (Resources.Load("Enemy"), spawnPos, Quaternion.identity) as GameObject;
			GameObject enemy2 = Instantiate (Resources.Load("Enemy2"), spawnPos2, Quaternion.identity) as GameObject;
			spawnTime = Time.timeSinceLevelLoad + spawnWait;
		}

		//bouncey enemy spawn rates
		if (Time.timeSinceLevelLoad > spawnTime2) {
			spawnWait2 = Random.Range (1f, 4f);
			spawnPos3.x = 13;
			spawnPos3.y = Random.Range (-5f, 5f);
			GameObject enemy3 = Instantiate (Resources.Load("Enemy3"), spawnPos3, Quaternion.Euler(0.0f, 0.0f, (Random.Range(0f, 40f)))) as GameObject;
			spawnTime2 = Time.timeSinceLevelLoad + spawnWait2;
		}
	}

	private void SpawnEnemy4 () {

		if (Time.timeSinceLevelLoad > spawnTime) {
			spawnWait = Random.Range (0.1f, 3.8f);
			spawnPos2.x = 13;
			spawnPos2.y = Random.Range (-5f, 5f);
			spawnPos.x = 13;
			spawnPos.y = Random.Range (-5f, 5f);
			GameObject enemy = Instantiate (Resources.Load ("Enemy"), spawnPos, Quaternion.identity) as GameObject;
			GameObject enemy2 = Instantiate (Resources.Load ("Enemy2"), spawnPos2, Quaternion.identity) as GameObject;
			spawnTime = Time.timeSinceLevelLoad + spawnWait;
		}

		if (Time.timeSinceLevelLoad > spawnTime2) {
			spawnWait2 = Random.Range (1f, 4f);
			spawnPos3.x = 13;
			spawnPos3.y = Random.Range (-5f, 5f);
			GameObject enemy3 = Instantiate (Resources.Load("Enemy3"), spawnPos3, Quaternion.Euler(0.0f, 0.0f, (Random.Range(0f, 40f)))) as GameObject;
			spawnTime2 = Time.timeSinceLevelLoad + spawnWait2;
		}

		//targeted enemy spawn rates
		if (Time.timeSinceLevelLoad > spawnTimeLonger) {
			spawnWaitLonger = Random.Range (7f, 10f);
			spawnPos4.x = 13;
			spawnPos4.y = Random.Range (-5f, 5f);
			GameObject enemy4 = Instantiate (Resources.Load ("Enemy4"), spawnPos4, Quaternion.identity) as GameObject;
			spawnTimeLonger = Time.timeSinceLevelLoad + spawnWaitLonger;
		}


	}

	private void SpawnEnemy5 () {

		if (Time.timeSinceLevelLoad > spawnTime) {
			spawnWait = Random.Range (0.1f, 3.8f);
			spawnPos2.x = 13;
			spawnPos2.y = Random.Range (-5f, 5f);
			spawnPos.x = 13;
			spawnPos.y = Random.Range (-5f, 5f);
			GameObject enemy = Instantiate (Resources.Load ("Enemy"), spawnPos, Quaternion.identity) as GameObject;
			GameObject enemy2 = Instantiate (Resources.Load ("Enemy2"), spawnPos2, Quaternion.identity) as GameObject;
			spawnTime = Time.timeSinceLevelLoad + spawnWait;
		}

		if (Time.timeSinceLevelLoad > spawnTime2) {
			spawnWait2 = Random.Range (0.5f, 3f);
			spawnPos3.x = 13;
			spawnPos3.y = Random.Range (-5f, 5f);
			GameObject enemy3 = Instantiate (Resources.Load("Enemy3"), spawnPos3, Quaternion.Euler(0.0f, 0.0f, (Random.Range(0f, 40f)))) as GameObject;
			spawnTime2 = Time.timeSinceLevelLoad + spawnWait2;
		}


		if (Time.timeSinceLevelLoad > spawnTimeLonger) {
			spawnWaitLonger = Random.Range (8f, 12f);
			spawnPos4.x = 13;
			spawnPos4.y = Random.Range (-5f, 5f);
			GameObject enemy4 = Instantiate (Resources.Load ("Enemy4"), spawnPos4, Quaternion.identity) as GameObject;
			spawnTimeLonger = Time.timeSinceLevelLoad + spawnWaitLonger;
		}
		//big enemy spawn rates
		if (Time.timeSinceLevelLoad > spawnTimeLonger2) {
			spawnWaitLonger2 = Random.Range (8f, 12f);
			spawnPos5.x = 13;
			spawnPos5.y = Random.Range (-5f, 5f);
			GameObject enemy5 = Instantiate (Resources.Load ("Enemy5"), spawnPos4, Quaternion.identity) as GameObject;
			spawnTimeLonger2 = Time.timeSinceLevelLoad + spawnWaitLonger2;
		}
	}

	private void SpawnEnemy6 () {

		if (Time.timeSinceLevelLoad > spawnTime) {
			spawnWait = Random.Range (0f, 2f);
			spawnPos2.x = 13;
			spawnPos2.y = Random.Range (-5f, 5f);
			spawnPos.x = 13;
			spawnPos.y = Random.Range (-5f, 5f);
			GameObject enemy = Instantiate (Resources.Load ("Enemy"), spawnPos, Quaternion.identity) as GameObject;
			GameObject enemy2 = Instantiate (Resources.Load ("Enemy2"), spawnPos2, Quaternion.identity) as GameObject;
			spawnTime = Time.timeSinceLevelLoad + spawnWait;
		}

		if (Time.timeSinceLevelLoad > spawnTime2) {
			spawnWait2 = Random.Range (0.5f, 3f);
			spawnPos3.x = 13;
			spawnPos3.y = Random.Range (-5f, 5f);
			GameObject enemy3 = Instantiate (Resources.Load("Enemy3"), spawnPos3, Quaternion.Euler(0.0f, 0.0f, (Random.Range(0f, 40f)))) as GameObject;
			spawnTime2 = Time.timeSinceLevelLoad + spawnWait2;
		}


		if (Time.timeSinceLevelLoad > spawnTimeLonger) {
			spawnWaitLonger = Random.Range (5f, 8f);
			spawnPos4.x = 13;
			spawnPos4.y = Random.Range (-5f, 5f);
			GameObject enemy4 = Instantiate (Resources.Load ("Enemy4"), spawnPos4, Quaternion.identity) as GameObject;
			spawnTimeLonger = Time.timeSinceLevelLoad + spawnWaitLonger;
		}

		if (Time.timeSinceLevelLoad > spawnTimeLonger2) {
			spawnWaitLonger2 = Random.Range (1f, 10f);
			spawnPos5.x = 13;
			spawnPos5.y = Random.Range (-5f, 5f);
			GameObject enemy5 = Instantiate (Resources.Load ("Enemy5"), spawnPos4, Quaternion.identity) as GameObject;
			spawnTimeLonger2 = Time.timeSinceLevelLoad + spawnWaitLonger2;
		}
	}
}



