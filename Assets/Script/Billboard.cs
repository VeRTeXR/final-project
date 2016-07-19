using UnityEngine;
using System.Collections;

    

public class Billboard : MonoBehaviour {

	public Animator animator;

	void Start () {
		animator = GetComponent<Animator>();
	}
	// Update is called once per frame
	void Update () {
		transform.LookAt(Camera.main.transform.position, Vector3.up);
	animator.SetFloat("speed", Mathf.Abs(Input.GetAxis ("Horizontal")));
	if(Input.GetAxisRaw("Horizontal") > 0){
        
        transform.eulerAngles = new Vector3 (0,180,0);
	}
    
    if(Input.GetAxisRaw("Horizontal") < 0) {
    	
    	transform.eulerAngles = new Vector3 (0,0,0);
    	//transform.LookAt(Camera.main.transform.position, -Vector3.up);	
    }
	}
}
