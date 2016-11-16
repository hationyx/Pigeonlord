using UnityEngine;
using System.Collections;

public class EnemyMovementCurved : MonoBehaviour {

	private Rigidbody2D EnemyRigidbody;
	public float enemySpeed = 10f;
	void Start () {

		EnemyRigidbody = GetComponent<Rigidbody2D>();
	}

	void Update () {
		EnemyMoveFunction();

	}

	private void EnemyMoveFunction ()
	{
		Vector2 movement = transform.right * enemySpeed * Time.deltaTime;
		EnemyRigidbody.MovePosition(EnemyRigidbody.position - movement);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.gameObject.CompareTag("Despawn"))
		{
			Destroy(gameObject);
		}

		if (other.gameObject.CompareTag("EndDespawn"))
		{
			ScoreManager.score = ScoreManager.score -10;
			Destroy(gameObject);
		}

		//this enemy is different as it spawns on a random angle then bounces off the top and bottom of screen
		if (other.gameObject.CompareTag ("Turnup")) {
			transform.rotation = Quaternion.Euler (0f, 0f, 320.0f);
		}

		if (other.gameObject.CompareTag ("Turndown")) {
			transform.rotation = Quaternion.Euler (0f, 0f, 40.0f);
		}

	
	}
}
