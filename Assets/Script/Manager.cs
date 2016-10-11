using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {
	
	public static Manager instance = null; 
	//private Manager managerScript;
	private BoardManager boardScript;
	public GameObject ExitTest;
	public GameObject[] enemy;
	public GameObject player;

	//public GameObject ExitTest;
	public float levelStartDelay = 0.3f;
	public float levelStartCountdown;
	public float HP = 20;
	public int level;
	public int score;



	private GameObject levelImage;
	private Text levelText;
	private bool doingSetup = true;

	// Title

	void Start () {
		HP = 20;
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		
		DontDestroyOnLoad (gameObject);
		boardScript = GetComponent<BoardManager> ();
		InitGame ();

	}
	void OnLevelWasLoaded(int index)  {
		level++;
		InitGame ();	

	}


	void InitGame() {
		doingSetup = true;
		//levelStartCountdown += Time.unscaledTime;
		Time.timeScale = 0;
		levelImage = GameObject.Find ("LevelImage");
		levelText = GameObject.Find ("LevelText").GetComponent<Text> ();
		levelText.text = "Dive " + level;
		levelImage.SetActive (true);
		Invoke ("HideLevelImage", 1);
		boardScript.SetupScene (level);
	}

	void Update () {

//		Debug.Log (levelStartCountdown);

		if (doingSetup) {
			levelStartCountdown += Time.unscaledTime;
			if (levelStartCountdown > 2)
				Time.timeScale = 1;
			return;
		}

        if (level < 1)
        {
            HP = 20;
			score = 0;
			 //check score, health, reset it! 
        }
		if (Input.GetKeyDown (KeyCode.Z)) {
			SceneManager.LoadScene("StartScn", LoadSceneMode.Single);
			//Application.LoadLevel("StartScn");
			level = -1;
			score = 0;
			HP = 20;
			//Debug.Log(level);
			//	reload will actually reload from beginning
		}


        if (levelImage.activeSelf) {
			if (Input.GetKeyDown (KeyCode.R)) {
				SceneManager.LoadScene("StartScn", LoadSceneMode.Single);
				level = -1;
				score = 0;
				HP = 20;
				//Debug.Log(level);
				//	reload will actually reload from beginning
			}
		}
	}

	void HideLevelImage () {
		levelImage.SetActive (false);
		doingSetup = false;
	}
	
	public void GameOver() {
		FindObjectOfType<Score> ().Save ();
		levelText.text = "You survived " + level + " levels";
		levelImage.SetActive (true);
	}

}
