using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	public float speed;

	void Update () {
		if(Input.GetKey(KeyCode.DownArrow)) RotateCameraOnAxis (Vector3.left, Vector3.down);
		if(Input.GetKey(KeyCode.UpArrow)) RotateCameraOnAxis (Vector3.right, Vector3.up);
	}

	void RotateCameraOnAxis(Vector3 rotateDir, Vector3 translateDir){
		transform.Rotate (rotateDir * Time.deltaTime * speed);
		transform.Translate (translateDir * Time.deltaTime * speed/10);
	}	
}
