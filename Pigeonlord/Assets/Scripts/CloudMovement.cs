using UnityEngine;
using System.Collections;

public class CloudMovement : MonoBehaviour {

	private Rigidbody2D CloudRigidbody;
	public float cloudSpeed = 6f;
	void Start () {

		CloudRigidbody = GetComponent<Rigidbody2D>();
	}

	void Update () {
		CloudMoveFunction();

	}

	private void CloudMoveFunction ()
	{
		Vector2 movement = transform.right * cloudSpeed * Time.deltaTime;
		CloudRigidbody.MovePosition(CloudRigidbody.position - movement);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//destroys the objects if the player doesn't pick them up
		if (other.gameObject.CompareTag("Despawn"))
		{
			Destroy(gameObject);
		}

		if (other.gameObject.CompareTag("EndDespawn"))
		{
			Destroy(gameObject);
		}


	}
}
