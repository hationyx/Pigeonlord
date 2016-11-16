using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	private Rigidbody2D EnemyRigidbody;
	public float enemySpeed = 10f;
	void Start () {
	
		EnemyRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		EnemyMoveFunction();
	}

	//standard enemy movement, they just move sideways at a certain speed
	private void EnemyMoveFunction ()
	{
		Vector2 movement = transform.right * enemySpeed * Time.deltaTime;
		EnemyRigidbody.MovePosition(EnemyRigidbody.position - movement);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//if they hit the top or bottom despawn they just get destroyed, if they hit the end one they got past the player so the player loses points
		if (other.gameObject.CompareTag("Despawn"))
		{
			Destroy(gameObject);
		}

		if (other.gameObject.CompareTag("EndDespawn"))
		{
			ScoreManager.score = ScoreManager.score -10;
			Destroy(gameObject);
		}

	}


}
