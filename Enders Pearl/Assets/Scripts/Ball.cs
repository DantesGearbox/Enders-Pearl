using UnityEngine;

public class Ball : MonoBehaviour {

	private Transform playerT;

	private float lifespan = 0.0f;
	[SerializeField] private float deathTimer = 1.0f;

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Terrain") {
		
			//Set the players position
			playerT.position = transform.position;
			
			//Set the players velocity to zero
			playerT.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

			Destroy (this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {

		lifespan += Time.deltaTime;
		if(lifespan > deathTimer){
			Destroy (this.gameObject);
		}
	}

	public void SetPlayerTransform(Transform t){
		playerT = t;
	}
}
