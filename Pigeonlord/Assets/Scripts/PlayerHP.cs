using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerHP : MonoBehaviour {

	public HighScores highScores;
	public Text healthText;
	public float currentHealth;
	private Rigidbody2D rigidbody;
	public static bool playerIsFalling;
	public static bool thePlayerHasDied;



	void Start () {
		
		currentHealth = 100f;
	
	}

	//the public static bools help to change the music and make sure all the other parts of the game reset properly when the player gets instantiated after death
	void Awake () {
		PlayerHP.thePlayerHasDied = false;
		PlayerHP.playerIsFalling = false;
		healthText = GameObject.Find ("Canvas/HP").GetComponent<Text> ();
		MusicPicker.gameMusicPlaying = false;
		MusicPicker.gameOverMusicPlaying = true;
		rigidbody = GetComponent<Rigidbody2D>();
	

	}

	void Update () {
		if (currentHealth > 100f) {
			currentHealth = 100f;
		}

		if (currentHealth <= 0) {
			currentHealth = 0f;
		}
			
		//if player health gets to 0 they fall straight down
		if (currentHealth <= 0) {
			rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;
			rigidbody.gravityScale = 60f;
			PlayerHP.playerIsFalling = true;
		}
			
		healthText.text = (currentHealth.ToString () + (" HP"));
	}
	 	
	void OnTriggerEnter2D(Collider2D other)
	{
		//if the player is falling they no longer interact with the enemies
		if (PlayerHP.playerIsFalling == false) {
			
			if (other.gameObject.CompareTag ("Enemy")) {
				currentHealth = currentHealth - 20f;
			}

			if (other.gameObject.CompareTag ("TargetEnemy")) {
				currentHealth = currentHealth - 30f;
			}

			if (other.gameObject.CompareTag ("BigEnemy")) {
				currentHealth = currentHealth - 50f;
			}

			if (other.gameObject.CompareTag ("Pickup")) {
				currentHealth = currentHealth + 10f;
			}

		}

		//when the player falls they reach the bottom despawn and die, this triggers the game over in the manager
		//also switch to the game over music and see if the score is high enough to be added to the scores file
		if (other.gameObject.CompareTag ("Despawn")) 
		{
			healthText.text = ("");
			highScores.AddScore (ScoreManager.score);
			highScores.SaveScoresToFile ();
			PlayerHP.thePlayerHasDied = true;
			MusicPicker.gameOverMusicPlaying = false;
			MusicPicker.gameMusicPlaying = true;
			Destroy (gameObject);
		}
	}


}
