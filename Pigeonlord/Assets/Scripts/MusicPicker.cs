using UnityEngine;
using System.Collections;

public class MusicPicker : MonoBehaviour {

	public AudioClip[] Music;
	public AudioClip gameOverMusic;
	private int random;
	AudioSource audio;
	public static bool gameOverMusicPlaying;
	public static bool gameMusicPlaying;

	void Awake () {
		audio = GetComponent<AudioSource> ();

	}

	void Start () {

	}

	//picks a random 1 of 2 songs that I made for the game. when the player dies it play the sad song, then picks another random 1 of 2 when the game restarts\
	//some booleans to stop songs restarting every frame, and to stop the game over song playing when the game restarts
	void Update () {
		if (PlayerHP.thePlayerHasDied == true && gameOverMusicPlaying == false) {
			audio.clip = gameOverMusic;
			audio.Play ();
			gameOverMusicPlaying = true;
		}

		if (PlayerHP.thePlayerHasDied == false && gameMusicPlaying == false) {
			audio.clip = Music [Random.Range (0, Music.Length)];
			audio.Play ();
			gameMusicPlaying = true;
		}


}
}
