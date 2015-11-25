﻿using UnityEngine;
using System.Collections;

public class BarController : MonoBehaviour {

	public float curHp;
	public float Maxhp = 20;
	public GameObject healthBar;
	float minHP = 0;
	// Use this for initialization
	void Start () {

		curHp = Maxhp;
	
	}
	
	// Update is called once per frame
	void Update () {

		/*if (Input.GetKeyDown (KeyCode.Space)) {

			decresebar();


		}

		if (Input.GetKeyDown (KeyCode.A)) {

			decresebar2();

		}*/
	
	}

	public void decresebar(){

		if (curHp <= minHP) {
			curHp = minHP;
		} 
		else {
			curHp -= 1;
		}

		float calHpBar = curHp / Maxhp;

		sethealtbar (calHpBar);

	
	}

	public void decresebar2(){
		
		if (curHp <= minHP) {
			curHp = minHP;
		} 
		else {
			curHp -= 2;
		}
		
		float calHpBar = curHp / Maxhp;
		
		sethealtbar (calHpBar);
		
		
	}

	public void increseBar(){
		
		if (curHp >= Maxhp) {
			curHp = Maxhp;
		} 
		else {
			curHp += 5;
		}
		
		float calHpBar = curHp / Maxhp;
		
		sethealtbar (calHpBar);
		
		
	}

	public void sethealtbar(float a){

		healthBar.transform.localScale = new Vector3 (a,transform.localScale.y,transform.localScale.z);



	}
}
