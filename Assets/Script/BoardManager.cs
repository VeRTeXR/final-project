using UnityEngine;
using System;
using Random = UnityEngine.Random;
using System.Collections;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour {

	[Serializable]
	public class Count {
		public int minimum;
		public int maximum;

		public Count (int min, int max) {
			minimum = min;
			maximum = max;
		}

	}

	public int columns = 30;
	public int rows = 30;
	public Count wallCount = new Count (5,5);
	public GameObject exit;
	public GameObject[] floorTiles;
	public GameObject[] enemyTiles;
	public GameObject[] outerWallTiles;
	public int enemyCount;

	private Transform boardHolder;
	private List <Vector3> gridPositions = new List <Vector3>();

	void InitialiseList () {
		gridPositions.Clear();
		for (int x=1; x<columns-1; x++) {
			for (int y=1; y<rows-1; y++) {
				gridPositions.Add(new Vector3(x,y,0f));

			}
		}
	}

	void BoardSetup ()
	{
		//Instantiate Board and set boardHolder to its transform.
		boardHolder = new GameObject ("Board").transform;
		
		//Loop along x axis, starting from -1 (to fill corner) with floor or outerwall edge tiles.
		for(int x = -1; x < columns + 1; x++)
		{
			//Loop along y axis, starting from -1 to place floor or outerwall tiles.
			for(int y = -1; y < rows + 1; y++)
			{
				//Choose a random tile from our array of floor tile prefabs and prepare to instantiate it.
				GameObject toInstantiate = floorTiles[Random.Range (0,floorTiles.Length)];

				if(x == -1 || x == columns || y == -1 || y == rows)
					toInstantiate = outerWallTiles [Random.Range (0, outerWallTiles.Length)];

				
				//Instantiate the GameObject instance using the prefab chosen for toInstantiate at the Vector3 corresponding to current grid position in loop, cast it to GameObject.
				GameObject instance =
					Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
				
				//Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
				instance.transform.SetParent (boardHolder);
			}
		}
	}
	

	
	Vector3 RandomPos() {
		int randomIndex = Random.Range (0, gridPositions.Count);
		Vector3 randomPosition = gridPositions [randomIndex];
		gridPositions.RemoveAt (randomIndex);
		return randomPosition;
	}
	
	void LayoutObjectAtRandom (GameObject[] tileArray, int minimum, int maximum) {
		int objectCount = Random.Range (minimum, maximum + 1);
		for (int i = 0; i < objectCount; i++) {
			Vector3 randompPos = RandomPos();
			GameObject tileChoice = tileArray [Random.Range(0, tileArray.Length)];
			Instantiate (tileChoice, randompPos, Quaternion.identity);
		}
	}

	public void SetupScene(int level) {
		BoardSetup ();
		InitialiseList ();
		enemyCount = (int)Mathf.Log (level, 2f);
		//Instantiate a random number of enemies based on minimum and maximum, at randomized positions.
		LayoutObjectAtRandom (enemyTiles, enemyCount, enemyCount);
		
		//Instantiate the exit tile in the upper right hand corner of our game board
		Instantiate (exit, new Vector3 (columns - 1, rows - 1, 0f), Quaternion.identity);
		
	}
	
	
}
