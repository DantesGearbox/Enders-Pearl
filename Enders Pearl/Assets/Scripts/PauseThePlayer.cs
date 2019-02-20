using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseThePlayer : MonoBehaviour {

	[SerializeField] CharacterController2D cc;
	public ParticleSystem ps;
	public GameObject visualization;

	private void OnTriggerEnter2D(Collider2D collision) {
		if(collision.gameObject.tag == "Player"){
			cc.PauseThePlayer();
			ps.Emit(60);
			visualization.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Mouse0)){
			cc.UnpauseThePlayer();
		}
	}
}
