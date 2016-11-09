using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	private Rigidbody2D EnemyRigidbody;
	public float enemySpeed = 40f;
	void Start () {
	
		EnemyRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
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
		//Check the provided Collider2D parameter other to see if it is tagged "Respawn", if it is...
		if (other.gameObject.CompareTag("Despawn"))
		{
			Destroy(gameObject);
		}
	}
}
