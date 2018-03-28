using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraThrow : MonoBehaviour {

	public float force;
	public float maxForce;
	public Slider slider;
	private Rigidbody rb;
	private bool throwed;
	private float finalForce;

	void Start () {
		rb = GetComponent<Rigidbody>();
		throwed = false;
		finalForce = 0;
	}

	void FixedUpdate () {
		if(Input.GetKey(KeyCode.Space) && !throwed && finalForce < maxForce){
			finalForce += Time.deltaTime * force;
		}

		if (Input.GetKeyUp (KeyCode.Space) && !throwed) {
			throwed = true;
			ApplyForce (rb, finalForce);
		}

		if (throwed && finalForce > 0) {
			finalForce -= Time.deltaTime * force * 2;
		}
		UpdateSliderValue (finalForce, 0 , maxForce);
	}

	float Map (float value, float fromSource, float toSource, float fromTarget, float toTarget){
        return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
    }

	void ApplyForce(Rigidbody rb, float force){
		rb.useGravity = true;
		rb.AddForce(this.transform.forward * force);
	}

	void UpdateSliderValue (float value, float min, float max){
		value = Map (value, min, max, 0, 1);
		slider.value = value;
	}
}
