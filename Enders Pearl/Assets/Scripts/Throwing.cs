using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour {

	private CharacterController2D cc;

	private GameObject ballHandler;
	public GameObject ball;

	private bool pearlReady = true;

	[SerializeField] private float throwStrength = 45.0f;

	//Controls
	public KeyCode throwKey = KeyCode.Mouse0;

	// Use this for initialization
	void Start() {
		cc = GetComponent<CharacterController2D>();
	}

	// Update is called once per frame
	void Update() {

		if (Input.GetKeyDown(throwKey) && pearlReady) {

			//Find the normalized vector pointing to the mouse
			Vector3 throwDirection = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
			throwDirection = Camera.main.ScreenToWorldPoint(throwDirection);
			throwDirection = throwDirection - transform.position;
			throwDirection = new Vector3(throwDirection.x, throwDirection.y, 0.0f);
			throwDirection = throwDirection.normalized;

			//Instantiate the ball a little away from the player
			ballHandler = Instantiate(ball, transform.position + throwDirection*.5f, Quaternion.Euler(0, 0, 0)) as GameObject;

			//Get the balls rigid body
			Rigidbody2D rb = ballHandler.GetComponent<Rigidbody2D>();

			//Set the balls player reference
			ballHandler.GetComponent<Ball>().SetPlayerTransform(cc.transform);

			//Set the balls throw speed
			rb.velocity = new Vector2(throwDirection.x, throwDirection.y) * throwStrength;

			//Put throwing on cooldown
			pearlReady = false;
		}

		//Check if pearl is off cooldown
		if(!pearlReady){
			
			//If the handler points to null, the pearl is dead, and the next one can be thrown
			if(ballHandler == null){
				pearlReady = true;
			}
		}
	} 
}
