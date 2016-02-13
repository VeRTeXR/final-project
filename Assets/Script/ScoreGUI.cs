using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreGUI : MonoBehaviour {

	public Text scoreGUIText;
	string highScoreKey = "highScore";
	public int highScore;


	// Update is called once per frame
	void Start () {
		highScore = PlayerPrefs.GetInt(highScoreKey,0);

		scoreGUIText.text = highScore.ToString ();
	}

	private void Initialize() {
		//score = 0; 
		//highScore = PlayerPrefs.GetInt (highScoreKey, 0);
	}

	public void AddPoint (int point) {
		//score = score + point;
	}
		
	public void Save () {
		//PlayerPrefs.SetInt (highScoreKey, highScore);
		//PlayerPrefs.Save ();

		//Initialize ();
	}

}
