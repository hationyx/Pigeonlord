using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public AudioClip hit;
	AudioSource audio;

	void Start ()
    {
        Destroy(gameObject, 2f);
	}
	void Awake () {
		audio = GetComponent<AudioSource>();
	}

	void Update ()
    {
    }
		

    //OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "Enemy", if it is...
		//plays sound clip for hitting enemy, makes the enemy freeze and fall
		//player gets 10 points for killing one-hit enemies
		if (other.gameObject.CompareTag("Enemy"))
        {
			AudioSource.PlayClipAtPoint (hit, new Vector3(0, 0, -14));
			other.attachedRigidbody.gravityScale = 100;
			other.attachedRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;
			ScoreManager.score = ScoreManager.score + 10;
			//if the penetrator upgrade is on, the bullet goes through enemies instead of being destroyed
			if (PlayerMovement.penetratorSwitch == false) {
				Destroy (gameObject);
			} else {
				return;
			}
        }
			

		if (other.gameObject.CompareTag ("DespawnBullets")) 
		{
			Destroy (gameObject);
		}

		if (other.gameObject.CompareTag ("TargetEnemy")) 
		{
			AudioSource.PlayClipAtPoint (hit, transform.position);
			if (PlayerMovement.penetratorSwitch == false) {
				Destroy (gameObject);
			} else {
				return;
			}
			Destroy (gameObject);
		}

		if (other.gameObject.CompareTag ("BigEnemy")) 
		{
			AudioSource.PlayClipAtPoint (hit, transform.position);
			Destroy (gameObject);
		}
    }
}
