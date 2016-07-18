using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {

	// Update is called once per frame
	void Update () {
	
        transform.LookAt(Camera.main.transform.position, Vector3.up);
    
    if(Input.GetKeyDown(KeyCode.S)) {
    	//transform.LookAt(Camera.main.transform.position, -Vector3.up);	
    }
	}
}
