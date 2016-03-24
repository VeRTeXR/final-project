using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;

public class MapGenerator : MonoBehaviour {
	
	public int width;
	public int height;
	
	public string seed;
	public bool useRandomSeed;
	public GameObject[] tileArray;
	public GameObject[] altTileArray;
	public GameObject tileChoice;
	public int randIndex;
	public GameObject bg;

	[Range(0,100)]
	public int randomFillPercent;

	private Transform boardHolder;

	int[,] map;
	
	void Start() {
		boardHolder = new GameObject ("Board").transform;
		randomFillPercent = Random.Range (40,50);
		GenerateMap();
		OnDraw ();

	}

	void GenerateMap() {
		map = new int[width,height];
		RandomFillMap();
		
		for (int i = 0; i < 5; i ++) {
			SmoothMap();
		}
	}

	void DestroyMap(){
		GameObject c = GameObject.FindWithTag("Background");
		if (c != null) {
						Destroy (c);
				}
	}
	
	void RandomFillMap() {
		if (useRandomSeed) {
			seed = Time.time.ToString();
		}
		
		System.Random pseudoRandom = new System.Random(seed.GetHashCode());
		
		for (int x = 0; x < width; x ++) {
			for (int y = 0; y < height; y ++) {
				if (x == 0 || x == width-1 || y == 0 || y == height -1) {
					map[x,y] = 1;
				}
				else {
					map[x,y] = (pseudoRandom.Next(0,100) < randomFillPercent)? 1: 0; //this choose if the shit will be 0 or 1 from fill percent 
				}
			}
		}
	}
	
	void SmoothMap() {
		for (int x = 0; x < width; x ++) {
			for (int y = 0; y < height; y ++) {
				int neighbourWallTiles = GetSurroundingWallCount(x,y);
				
				if (neighbourWallTiles > 4)
					map[x,y] = 1; //if neighbour is alive > 4 therefore this tile is alive
				else if (neighbourWallTiles < 4)
					map[x,y] = 0; // else dead
				
			}
		}
	}
	
	int GetSurroundingWallCount(int gridX, int gridY) {
		int wallCount = 0;
		for (int neighbourX = gridX - 1; neighbourX <= gridX + 1; neighbourX ++) {
			for (int neighbourY = gridY - 1; neighbourY <= gridY + 1; neighbourY ++) {
				if (neighbourX >= 0 && neighbourX < width && neighbourY >= 0 && neighbourY < height) {
					if (neighbourX != gridX || neighbourY != gridY) {
						wallCount += map[neighbourX,neighbourY];
					}
				}
				else {
					wallCount ++;
				}
			}
		}
		
		return wallCount;
	}
	
	
	void OnDraw() {

		if (map != null) {

			for (int x = 0; x < width; x ++) {
				for (int y = 0; y < height; y ++) {
					Vector3 pos = new Vector3(-width/2 + x + .5f,-height/2 + y+.5f, 1);
					if(map[x,y]==1) {
						randIndex = Random.Range(0,tileArray.Length);
						tileChoice = tileArray [randIndex];
						GameObject instance = Instantiate (tileChoice, pos, Quaternion.identity) as GameObject;
						instance.transform.SetParent (boardHolder);
					}
					else {
						randIndex = Random.Range(0,altTileArray.Length);
						tileChoice = altTileArray [randIndex];
						GameObject instance = Instantiate (tileChoice, pos, Quaternion.identity) as GameObject;
						instance.transform.SetParent (boardHolder);

					}
					Instantiate (bg,pos,Quaternion.identity);


				}
			}
		}
	}
	
}
