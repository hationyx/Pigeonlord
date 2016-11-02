using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;

    Text text;

	// Use this for initialization
	void Start ()
    {
        text = GetComponent<Text>();

        // Reset the score
        score = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Set the displayed text to be the word "Score" followed by the score value
        text.text = "Score: " + score;
	}
}
