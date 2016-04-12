using UnityEngine;
using System.Collections;

public class ObjectivePointer : MonoBehaviour {

	public GameObject player;
	public GameObject target;
	public GameObject enemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		enemy = GameObject.FindGameObjectWithTag("Enemy");
		target = GameObject.FindGameObjectWithTag("Exit");
		player = GameObject.FindGameObjectWithTag("Player");

		if (enemy != null) {
			Vector3 targetScreenPosition = Camera.main.WorldToScreenPoint (enemy.transform.position);
			//Debug.Log (targetScreenPosition);
			Vector3 pointerScreenPosition = Camera.main.WorldToScreenPoint (player.transform.position);
			//Debug.Log (pointerScreenPosition);

			Vector3 distance = targetScreenPosition - pointerScreenPosition;
			//Debug.Log ("dis" + distance);
			float angle = Mathf.Atan2 (distance.y, distance.x) * Mathf.Rad2Deg;
			//Debug.Log (angle);
			transform.localEulerAngles = new Vector3 (0f, 0f, angle - 90);
		}
		if (target!= null) {
			Vector3 targetScreenPosition = Camera.main.WorldToScreenPoint (enemy.transform.position);
			//Debug.Log (targetScreenPosition);
			Vector3 pointerScreenPosition = Camera.main.WorldToScreenPoint (player.transform.position);
			//Debug.Log (pointerScreenPosition);

			Vector3 distance = targetScreenPosition - pointerScreenPosition;
			//Debug.Log ("dis" + distance);
			float angle = Mathf.Atan2 (distance.y, distance.x) * Mathf.Rad2Deg;
			//Debug.Log (angle);
			transform.localEulerAngles = new Vector3 (0f, 0f, angle - 90);
		} 

		else {

		}

	}
}
