using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	public int start = 0; //enemy counter
	public float spawnTime;
	public float spawnDelay;
	public int enemyCount;
	public GameObject enemy;

	public float randomHealtime ;
	public GameObject heal;
	public int healCount;

	public GameObject speedUp;
	public int speedUpCount = Random.Range(1,3);
	public float randomSpeedUptime ;

	public GameObject maxHpUp;
	public int maxHpUpCount = Random.Range(1,3);
	public float randommaxHpUptime ;

	// Use this for initialization
	void Start () {


		randomHealtime = Random.Range(100,300);

		randomSpeedUptime = Random.Range(200,400);

		randommaxHpUptime = Random.Range(300,600);



		enemyCount = Random.Range (10,30); //random enemy count

		//Debug.Log (enemyCount);	
		InvokeRepeating ("Spawner", spawnDelay, spawnTime);

		InvokeRepeating ("SpawnerHeal", spawnDelay*randomHealtime, spawnTime*Time.deltaTime*1000);

		InvokeRepeating ("SpawnSpeedUp", spawnDelay*randomSpeedUptime, spawnTime*Time.deltaTime*1000);

		InvokeRepeating ("SpawnerMaxHpUp", spawnDelay*randommaxHpUptime, spawnTime*Time.deltaTime*1000);
		//Debug.Log (start);
	}
	void Update () {
		if (start > enemyCount) {
			CancelInvoke("Spawner"); // start spawn till enemy count
		}
		if (healCount == 0) {
			CancelInvoke("SpawnerHeal");
		}

		if (speedUpCount == 0) {
			CancelInvoke("SpawnerHeal");
		}

		if (maxHpUpCount == 0) {
			CancelInvoke("SpawnerMaxHpUp");
		}

	}

	void Spawner () {
		var x1 = transform.position.x - GetComponent<Renderer>().bounds.size.x/2;
		var x2 = transform.position.x + GetComponent<Renderer>().bounds.size.x/2;
		var y1 = transform.position.y - GetComponent<Renderer> ().bounds.size.y / 2;
		var y2 = transform.position.y + GetComponent<Renderer> ().bounds.size.y / 2;  
		var spawnPoint = new Vector2 (Random.Range (x1, x2), Random.Range (y1,y2));
		
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

	void SpawnerMaxHpUp(){

		var x1 = transform.position.x - GetComponent<Renderer>().bounds.size.x/2;
		var x2 = transform.position.x + GetComponent<Renderer>().bounds.size.x/2;
		var spawnPoint = new Vector2 (Random.Range (x1, x2), transform.position.y);
		
		// Create an enemy at the 'spawnPoint' position
		Instantiate(maxHpUp, spawnPoint, Quaternion.identity);
		
		maxHpUpCount -= 1;

	}

	void stopSpawn () {
		CancelInvoke("Spawner");
	}

	void OnGUI(){
		
		GUI.Label (new Rect (10, 240, 200, 60), "enemy :  " + enemyCount.ToString()); //display enemy by random	

	}

}
