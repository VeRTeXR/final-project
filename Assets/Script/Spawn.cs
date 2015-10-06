using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	public int start = 0;
	public float spawnTime;
	public float spawnDelay;
	public int enemyCount;
	public GameObject enemy;


	// Use this for initialization
	void Start () {

		enemyCount = Random.Range (10,30); //random enemy count
		//Debug.Log (enemyCount);	
		InvokeRepeating ("Spawner", spawnDelay, spawnTime);
			
		//Debug.Log (start);
	}
	void Update () {
		if (start > enemyCount) {
			CancelInvoke("Spawner");
		}
	}

	void Spawner () {
		var x1 = transform.position.x - GetComponent<Renderer>().bounds.size.x/2;
		var x2 = transform.position.x + GetComponent<Renderer>().bounds.size.x/2;
		var spawnPoint = new Vector2 (Random.Range (x1, x2), transform.position.y);
		
		// Create an enemy at the 'spawnPoint' position
		Instantiate(enemy, spawnPoint, Quaternion.identity);
		start = start + 1;
		Debug.Log (start);
	}

	void stopSpawn () {
		CancelInvoke("Spawner");
	}

	void OnGUI(){
		
		GUI.Label (new Rect (10, 240, 200, 60), "enemy :  " + enemyCount.ToString()); //display enemy by random	

	}

}
