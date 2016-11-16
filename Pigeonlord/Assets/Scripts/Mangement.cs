using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mangement : MonoBehaviour {

	//game manager, lots of text objects and player dead audio. also has the spawn manager attached
	public Text playerHealth;
	public Text playerScore;
	public Text pressEnter;
	public Text gameOver;
	public Text timeText;
	public GameObject highScoresPanel;
	public Text highScoresText;
	public Button highScoresButton;
	public GameObject spawnManager;
	public GameObject player;
	public GameObject pigeonLord;
	public static bool despawnStuff;
	public AudioClip playerDead;
	AudioSource audio;
	private bool playerDeadClip;
	private float gameTime = 0;
	public float GameTime { get { return gameTime; } }
	public enum GameState
	{
			Start,
			Playing,
			GameOver
	};

	private GameState gameState;
	public GameState State { get { return gameState; } }

	void Awake () 
	{
		gameState = GameState.Start;
		audio = GetComponent<AudioSource> ();
	}
	void Start () {
	
	}
	

	void Update () {

		switch (gameState)
		//sets all the appropriate UI to true or false
		{
		case GameState.Start:
			pigeonLord.SetActive (true);
			highScoresPanel.gameObject.SetActive (false);
			playerHealth.enabled = false;
			timeText.enabled = false;
			playerScore.enabled = false;
			gameOver.enabled = false;
			highScoresButton.gameObject.SetActive (false);
			//when the player clicks return, it spawns the spawnmanager(enemies) and changes to playing state
			if (Input.GetKeyUp (KeyCode.Return) == true) {
				gameState = GameState.Playing;
				GameObject spawnManager = Instantiate (Resources.Load ("Spawn Manager"), transform.position, Quaternion.identity) as GameObject;
				pressEnter.enabled = false;
				highScoresButton.gameObject.SetActive (false);
				playerHealth.enabled = true;
				playerScore.enabled = true;
			}
			break;

		case GameState.Playing:
			//sets the appropriate UI, if the player is falling (0 health) is plays the little playerDead arpeggio
			Mangement.despawnStuff = false;
			gameTime += Time.deltaTime;
			int seconds = Mathf.RoundToInt (gameTime);
			highScoresButton.gameObject.SetActive (false);
			pigeonLord.SetActive (false);
			if (PlayerHP.playerIsFalling == true && playerDeadClip == false) {
				audio.clip = playerDead;
				audio.Play ();
				playerDeadClip = true;
			}
			//once the player hits the despawn bar, the UI changes and the state changes to game over
			if (PlayerHP.thePlayerHasDied == true) {
				
				gameState = GameState.GameOver;
				gameOver.enabled = true;
				timeText.enabled = false;
				pressEnter.enabled = true;
				highScoresButton.gameObject.SetActive (true);
				playerHealth.enabled = false;
				gameOver.enabled = true;
			}
			break;

		case GameState.GameOver:
			//if the player presses enter from the game over screen, the game restarts
			//instantiates a new player and new spawn manager, plus resets UI and despawns everything
			pigeonLord.SetActive (false);
			if (Input.GetKeyUp (KeyCode.Return) == true) {
				Mangement.despawnStuff = true;
				gameTime = 0;
				PlayerHP.thePlayerHasDied = false;
				gameState = GameState.Playing;
				GameObject spawnManager = Instantiate (Resources.Load ("Spawn Manager"), transform.position, Quaternion.identity) as GameObject;
				GameObject player = Instantiate (Resources.Load ("Player"), new Vector2(-7, 0), Quaternion.identity) as GameObject;
				pressEnter.enabled = false;
				highScoresButton.gameObject.SetActive (false);
				playerHealth.enabled = true;
				playerScore.enabled = true;
				gameOver.enabled = false;
				timeText.enabled = true;
				highScoresPanel.SetActive (false);
				playerDeadClip = false;
			}
			break;

	
	}
		if (Input.GetKeyUp (KeyCode.Escape)) {
			Application.Quit ();
		}
}
	//function for clicking the high scores button. reveals the panel and adds the scores to it with a new line between each loop
	public void OnHighScores() {

		highScoresPanel.SetActive (true);
		highScoresButton.gameObject.SetActive (false);
		gameOver.enabled = false;
		timeText.enabled = false;

		string text = "\n";

		for (int i = 0; i < HighScores.scores.Length; i++) {

			int score = HighScores.scores [i];
			text += score.ToString () + ("\n");
		}
		highScoresText.text = text;

		

}
}
