using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {


    // The forces that control Pigeon X
    // Speed determines the speed of our pigeon
    public float PlayerSpeed = 12f;
    //We've decided to use a Rigidbody to control our 'characters'
	private Rigidbody2D PlayerRigidbody;

	public AudioClip upgradeShield;
	public AudioClip eat;
	public AudioClip upgradeRapidFire;
	public AudioClip upgradePenetrator;
	public AudioClip deadEnemy;
	AudioSource audio;
	//switches to make the upgrades work in another script
	public static bool rapidFireSwitch;
	public static bool penetratorSwitch;

    //setup for our keyboard inputs
    private float VerticalInputValue;
    private float HorizontalInputValue;





    //This function allows the player to move around in game space
    private void PlayerMoveFunction()
    {
        Vector2 movement = transform.up * VerticalInputValue * PlayerSpeed * Time.deltaTime;
        Vector2 movementH = transform.right * HorizontalInputValue * PlayerSpeed * Time.deltaTime;
        PlayerRigidbody.MovePosition(PlayerRigidbody.position + movement + movementH);

      

    }

	//makes the player only able to move in a certain area until they are dead
    private void Boundaries()
    {
		if (PlayerHP.playerIsFalling == false) {
        Vector2 Pos = transform.position;
        Pos.x = Mathf.Clamp(Pos.x + HorizontalInputValue, -9.6f, -4f);
        Pos.y = Mathf.Clamp(Pos.y + VerticalInputValue, -5.3f, 5.3f);
        transform.position = Pos;
    }
	}



	void Awake ()
	{
		audio = GetComponent<AudioSource>();

	}
    void Start ()
    {
        PlayerRigidbody = GetComponent<Rigidbody2D>();
	}


	void Update ()
    {
        VerticalInputValue = Input.GetAxis("Vertical");
        HorizontalInputValue = Input.GetAxis("Horizontal");
        Boundaries();
    }

    void FixedUpdate()
    {
        PlayerMoveFunction();
    }

    //OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
    void OnTriggerEnter2D(Collider2D other)
    {
        

		//unless the player is falling (dead), they can pickup certain items, this destroys them and plays sounds
		if (PlayerHP.playerIsFalling == false) {
			
			if (other.gameObject.CompareTag ("Pickup")) {
				Destroy (other.gameObject);
				audio.PlayOneShot (eat, 1f);
				ScoreManager.score = ScoreManager.score + 5;
			}

			if (other.gameObject.CompareTag ("ShieldPickup")) {
				GameObject shield = Instantiate (Resources.Load ("Shield"), transform.position, Quaternion.identity) as GameObject;
				Destroy (other.gameObject);
				audio.PlayOneShot (upgradeShield, 0.1f);
			}

			if (other.gameObject.CompareTag ("RapidFire")) {
				rapidFireSwitch = true;
				Destroy (other.gameObject);
				audio.PlayOneShot (upgradeRapidFire, 1f);
			}

			if (other.gameObject.CompareTag ("PenetratorPickup")) {
				penetratorSwitch = true;
				Destroy (other.gameObject);
				audio.PlayOneShot (upgradePenetrator, 0.3f);
			}

			if (other.gameObject.CompareTag ("TargetEnemy")) {
				audio.PlayOneShot (deadEnemy, 0.1f);
				Destroy (other.gameObject);
			}

			if (other.gameObject.CompareTag ("BigEnemy")) {
				audio.PlayOneShot (deadEnemy, 0.1f);
				Destroy (other.gameObject);
			}

			if (other.gameObject.CompareTag ("Enemy")) {
				audio.PlayOneShot (deadEnemy, 0.1f);
				Destroy (other.gameObject);
			}
		}

    }

}
