using UnityEngine;
using System.Collections;

public class EnemyMovementTargeted : MonoBehaviour {

	private Rigidbody2D EnemyRigidbody;
	public float enemySpeed = 10f;
	public GameObject playerPosition;

	void Awake () {
		playerPosition = GameObject.FindGameObjectWithTag ("Player");
	}

	void Start () {

		EnemyRigidbody = GetComponent<Rigidbody2D>();
	}
		
	void Update () {
		if (PlayerHP.playerIsFalling == false) {
			EnemyMoveFunction ();
		}
	}

	//enemy moves towards the players position every frame
	private void EnemyMoveFunction ()
	{
		EnemyRigidbody.transform.position = Vector2.MoveTowards (EnemyRigidbody.transform.position, playerPosition.transform.position, enemySpeed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//Despawn enemies if they fall or hit the player, give points if they get past
		if (other.gameObject.CompareTag("Despawn"))
		{
			Destroy(gameObject);
		}

		if (other.gameObject.CompareTag("EndDespawn"))
		{
			ScoreManager.score = ScoreManager.score -10;
			Destroy(gameObject);
		}
			

		if (other.gameObject.CompareTag ("Player")) {

			Destroy (gameObject);
		}


	}
}
