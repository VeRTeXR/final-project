using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Manager : MonoBehaviour {
	
	public static Manager instance = null; 
	//private Manager managerScript;
	private BoardManager boardScript;
	public GameObject ExitTest;
	public GameObject[] enemy;
	public GameObject player;
	public GameObject title;
	//public GameObject ExitTest;
	public float levelStartDelay = 0.3f;
	public int HP;



	private GameObject levelImage;
	private Text levelText;
	private int level;
	private bool doingSetup = true;

	// Title

	void Start () {

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
		title = GameObject.Find ("Title");
		title.SetActive(false);
	}


	void InitGame() {
		doingSetup = true;
		levelImage = GameObject.Find ("LevelImage");
		levelText = GameObject.Find ("LevelText").GetComponent<Text> ();
		levelText.text = "Dive " + level;
		levelImage.SetActive (true);
		Invoke ("HideLevelImage", levelStartDelay);
		boardScript.SetupScene (level);
	}

	void update () {
		if(doingSetup)
			
			//If any of these are true, return and do not start MoveEnemies.
			return;

		enemy = GameObject.FindGameObjectsWithTag("Enemy");
		if (enemy.Length <= 0) {
			Instantiate (ExitTest, transform.position, transform.rotation);	
		}
		/*if (enemyCount <= 0)
			Instantiate (ExitTest, transform.position, transform.rotation);*/

	}

	void HideLevelImage () {
		levelImage.SetActive (false);
		doingSetup = false;
	}



	public void GameOver() {
		FindObjectOfType<Score> ().Save ();
		levelText.text = "After " + level + " your shite is done.";
		levelImage.SetActive (true);

		enabled = false;
	}

}
