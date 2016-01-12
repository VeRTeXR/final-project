using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Manager : MonoBehaviour {
	
	public static Manager instance = null; 
	//private Manager managerScript;
	private BoardManager boardScript;
	public GameObject player;
	public GameObject title;

	private int level = 50000;

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
	void OnLevelWasLoaded(int level)  {
		InitGame ();	
		title = GameObject.Find ("Title");
		title.SetActive(false);
	}
		

	void InitGame() {
		boardScript.SetupScene (level);
	}
	
}
