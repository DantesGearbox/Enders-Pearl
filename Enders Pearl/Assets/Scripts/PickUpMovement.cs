using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpMovement : MonoBehaviour {

	[SerializeField] Rigidbody2D rb;
	private float value = 0.0f;
	private float rotation = 2;
	
	// Update is called once per frame
	void Update () {

		transform.Rotate(new Vector3(0, 0, rotation), rotation);

		value += 0.02f;
		rb.velocity = new Vector2(0, Mathf.Sin(value)) * 2;

	}
}
