using UnityEngine;
using System.Collections;

public class CilckForOpen : MonoBehaviour {

	/*void OnMouseDown(){

		Application.LoadLevel ("mission");

	}*/

    void Update() {

        if (Input.GetKeyDown(KeyCode.Space)) {

            Application.LoadLevel("mission");

        }



    }

}
