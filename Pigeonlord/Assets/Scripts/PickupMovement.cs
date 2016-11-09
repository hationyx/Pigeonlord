using UnityEngine;
using System.Collections;

public class PickupMovement : MonoBehaviour {

	private Rigidbody2D PickupRigidbody;
	public float pickupSpeed = 10f;
	void Start () {

		PickupRigidbody = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		PickupMoveFunction();
	}

	private void PickupMoveFunction ()
	{
		Vector2 movement = transform.right * pickupSpeed * Time.deltaTime;
		PickupRigidbody.MovePosition(PickupRigidbody.position - movement);
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
