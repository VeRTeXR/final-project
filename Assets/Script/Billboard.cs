using UnityEngine;
using System.Collections;

    

public class Billboard : MonoBehaviour {


	public Animator animator;

	void Start () {
		animator = GetComponent<Animator>();
	
	}
	// Update is called once per frame
	void LateUpdate () {
	//transform.LookAt(Vector3.zero);
	transform.rotation = Quaternion.Euler(new Vector3(0,transform.rotation.eulerAngles.y,0));
	float horizontalMovement = Input.GetAxis("Horizontal");
	float vertMovement = Input.GetAxis("Vertical");
	animator.SetFloat("vertSpeed", Mathf.Abs(vertMovement));
	animator.SetFloat("speed", Mathf.Abs(horizontalMovement));

	if(Input.GetAxisRaw("Horizontal") > 0){
        transform.eulerAngles = new Vector3 (0,180,0);
        //transform.rotation = Quaternion.identity;
	}
    
    if(Input.GetAxisRaw("Horizontal") < 0) {
    	transform.eulerAngles = new Vector3 (0,0,0);
    }

    if(Input.GetAxisRaw("Vertical") > 0){
        
        transform.eulerAngles = new Vector3 (0,180,0);
	}
	if(Input.GetAxisRaw("Vertical") < 0){
        
        transform.eulerAngles = new Vector3 (0,0,0);
	}

	}
}
