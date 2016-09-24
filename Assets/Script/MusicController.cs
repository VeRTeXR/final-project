using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {
	public static MusicController instance = null;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
