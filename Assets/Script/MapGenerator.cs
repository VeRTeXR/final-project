using UnityEngine;
using System.Collections;
using System;

public class MapGenerator : MonoBehaviour {

	public int width;
	public int height;
	public string seed;
	public bool useRandomSeed;

	[Range(0,100)]
	public int  randomFillPercent;

	int [,] map;

	// Use this for initialization
	void Start () {
		GenerateMap ();
	
	}

	void GenerateMap (){

		map = new int [width, height];
		RandomFillMap ();
	}

	void RandomFillMap() {
		if (useRandomSeed) {
			seed = Time.time.ToString ();
		}
		System.Random psudoRand = new System.Random (seed.GetHashCode ());
	
		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				if(x==0||x==width-1||y==0||y==height-1){
					map[x,y]= 1;
				}
				else {
				map [x, y] = (psudoRand.Next (0, 100) < randomFillPercent) ? 1 : 0;
				}
			}
		}
	}

	void SmoothMap() {
	}

		void onDraw () {
			if(map != null){
				
				for (int x = 0; x < width; x++) {
					for(int y = 0; y < height; y++){
						Vector3 pos = new Vector3 (-width/2+x+.5f,0,-height/2+y+.5f);
					}
				}
			}
		}

}
