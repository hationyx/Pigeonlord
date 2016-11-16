using UnityEngine;
using System.Collections;

public class PickupMovement : MonoBehaviour {

	private Rigidbody2D PickupRigidbody;
	public float pickupSpeed = 10f;
	void Start () {

		PickupRigidbody = GetComponent<Rigidbody2D>();
	}
		
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
