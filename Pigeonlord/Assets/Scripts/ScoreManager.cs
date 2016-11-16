using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public Text scoreText;


	//finds the text object and updates the score every frame, static int so other scripts can easily access it
	void Awake ()
	{
		scoreText = GameObject.Find ("Canvas/Score: ").GetComponent<Text> ();
	}

	void Start ()
    {
        score = 0;
	}
	

	void Update ()
    {
        // Set the displayed text to be the word "Score" followed by the score value
        scoreText.text = "Score: " + score;

	}


}
