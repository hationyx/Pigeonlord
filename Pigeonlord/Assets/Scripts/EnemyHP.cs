using UnityEngine;
using System.Collections;

public class EnemyHP : MonoBehaviour {

	public float health = 2f;
	private Rigidbody2D rigidbody;

	//enemy loses 1 health each time a bullet hits it, and player gets 30 points for killing these harder enemies

	void Awake () {
		rigidbody = GetComponent<Rigidbody2D> ();
	}
	void Update () 
	{
		if (health == 0f) 
		{
			//to stop you getting 30 points over and over every frame while enemy is falling...
			health = 69f;
			rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;
			rigidbody.gravityScale = 100f;
			ScoreManager.score = ScoreManager.score + 40;
		
		}

	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Bullet")) {
			health = health - 1f;
		}
	

		if (other.gameObject.CompareTag ("Despawn")) {
			
			Destroy (gameObject);
		}

		if (other.gameObject.CompareTag ("EndDespawn")) {
			ScoreManager.score = ScoreManager.score - 10;
			Destroy (gameObject);
		}

	}

}
