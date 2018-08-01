using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithVelocity : MonoBehaviour {

	[SerializeField] Rigidbody2D rb;

	//Rotation variables
	[SerializeField] private float rotationSpeed = 125.0f;
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed * rb.velocity.magnitude);
	}
}
