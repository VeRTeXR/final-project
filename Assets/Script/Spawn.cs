using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	public int start = 0;
	public float spawnTime;
	public float spawnDelay;
	public int enemyCount;
	public GameObject enemy;

	public GameObject heal;
	public int healCount;

	public GameObject speedUp;
	public int speedUpCount = Random.Range(1,3);

	// Use this for initialization
	void Start () {

		enemyCount = Random.Range (5,15); //random enemy count
		//Debug.Log (enemyCount);	
		InvokeRepeating ("Spawner", spawnDelay, spawnTime);

		InvokeRepeating ("SpawnerHeal", spawnDelay*100, spawnTime*Time.deltaTime*1000);

		InvokeRepeating ("SpawnSpeedUp", spawnDelay*110, spawnTime*Time.deltaTime*1000);
		//Debug.Log (start);
	}
	void Update () {
		if (start > enemyCount) {
			CancelInvoke("Spawner");
		}
		if (healCount == 0) {
			CancelInvoke("SpawnerHeal");
		}

		if (speedUpCount == 0) {
			CancelInvoke("SpawnerHeal");
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

	void SpawnerHeal () {
		var x1 = transform.position.x - GetComponent<Renderer>().bounds.size.x/2;
		var x2 = transform.position.x + GetComponent<Renderer>().bounds.size.x/2;
		var spawnPoint = new Vector2 (Random.Range (x1, x2), transform.position.y);
		
		// Create an enemy at the 'spawnPoint' position
		Instantiate(heal, spawnPoint, Quaternion.identity);

		healCount -= 1;

	}

	void SpawnSpeedUp () {
		var x1 = transform.position.x - GetComponent<Renderer>().bounds.size.x/2;
		var x2 = transform.position.x + GetComponent<Renderer>().bounds.size.x/2;
		var spawnPoint = new Vector2 (Random.Range (x1, x2), transform.position.y);
		
		// Create an enemy at the 'spawnPoint' position
		Instantiate(speedUp, spawnPoint, Quaternion.identity);
		
		speedUpCount -= 1;
		
	}

	void stopSpawn () {
		CancelInvoke("Spawner");
	}

	void OnGUI(){
		
		GUI.Label (new Rect (10, 240, 200, 60), "enemy :  " + enemyCount.ToString()); //display enemy by random	

	}

}
