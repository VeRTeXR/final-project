using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public GUIText scoreGUIText;
	public GUIText highScoreGUIText;
	private int score;
	private int highScore;
	private string highScoreKey = "highScore";

	// Use this for initialization
	void Start () {
		Initialise ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		// If the Score is higher than the High Score…
		if (highScore < score) {
			highScore = score;
		}
		
		// Display both the Score and High Score
		scoreGUIText.text = score.ToString ();
		highScoreGUIText.text = "HighScore : " + highScore.ToString ();
	}

	private void Initialise () {
		score = 0;
		highScore = PlayerPrefs.GetInt (highScoreKey, 0);
	}

	public void AddPoint (int point) {
		score = score + point;
	}

	public void Save() {
		PlayerPrefs.SetInt (highScoreKey, highScore);
		PlayerPrefs.Save ();

		Initialise ();
	}
}

