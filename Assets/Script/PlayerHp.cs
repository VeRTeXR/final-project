using UnityEngine;
using System.Collections;

public class PlayerHp : MonoBehaviour {
	

	public float max_Hp = 10f;
	public float cur_Hp = 0f;
	public GameObject healthBar;
	
	
	
	// Use this for initialization
	void Start () {
		
		cur_Hp = max_Hp;
		//InvokeRepeating ("decreasehelth",1f,1f);
		//Decreasehelth ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
	}
	
	public void decreaseHp(){
		
		cur_Hp -= 15f;
		float calc_Hp = cur_Hp / max_Hp;
		SetHealthBar (calc_Hp);
	}
	
	void SetHealthBar(float myHp){
		
		healthBar.transform.localScale = new Vector3 (myHp , healthBar.transform.localScale.y,healthBar.transform.localScale.z);
		
		
	}
	
}