using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	// Use this for initialization
	private float elapsedTime = 0f;
	private bool shieldActive;
	public GameObject playerPosition;
	public AudioClip zap;
	AudioSource audio;

	void Awake () {
		playerPosition = GameObject.FindGameObjectWithTag ("Player");
		shieldActive = true;
		audio = GetComponent<AudioSource>();
	}

	void Start () {

	}
		
	void Update () {

		//destroys the shield if the player dies so it doesn't keep searching for the game object
		if (PlayerHP.playerIsFalling == true) {
			Destroy (gameObject);
		}

		//shield follows the players position and lasts for 5 seconds
		transform.position = playerPosition.transform.position;
		if (shieldActive == true) {
			elapsedTime += Time.deltaTime;
			if (elapsedTime >= 5) {
				shieldActive = false;
				Destroy (gameObject);
			}
		}
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		
		//shield makes the enemies fly upwards, the player doesn't get points for shield kills, mostly just for protection
		if (other.gameObject.CompareTag("Enemy"))
		{
			other.GetComponent<BoxCollider2D> ().enabled = false;
			other.attachedRigidbody.gravityScale = -100;
			audio.PlayOneShot(zap, 0.5f);
		}

		if (other.gameObject.CompareTag("TargetEnemy"))
		{
			other.GetComponent<BoxCollider2D> ().enabled = false;
			other.attachedRigidbody.gravityScale = -100;
			other.attachedRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;
			audio.PlayOneShot(zap, 0.5f);
		}

		if (other.gameObject.CompareTag("BigEnemy"))
		{
			other.GetComponent<BoxCollider2D> ().enabled = false;
			other.attachedRigidbody.gravityScale = -100;
			audio.PlayOneShot(zap, 0.5f);
		}
	}
}
