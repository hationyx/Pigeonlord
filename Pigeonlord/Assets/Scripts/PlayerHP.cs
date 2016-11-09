using UnityEngine;
using System.Collections;

public class PlayerHP : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//Check the provided Collider2D parameter other to see if it is tagged "Enemy", if it is...
		if (other.gameObject.CompareTag("Enemy"))
		{
			other.attachedRigidbody.gravityScale = 100;
		}
	}
}
