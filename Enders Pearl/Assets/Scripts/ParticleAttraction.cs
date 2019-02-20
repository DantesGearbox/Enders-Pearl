using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticleAttraction : MonoBehaviour {

	public ParticleSystem ps;
	public Transform target;
	public Text text;

	private bool start = false;
	private float attractTime = 1f;
	private float attractTimer = 0.0f;
	private bool attract = false;

	private float attractSpeed = 10000.0f;

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.tag == "Player") {
			start = true;
		}
	}

	void Update() {

		if(start){
			attractTimer += Time.deltaTime;
			if (attractTimer >= attractTime) {

				attract = true;
			}

			if (attract) {
				text.gameObject.SetActive(true);

				//Start the attraction
				ParticleSystem.Particle[] particles = new ParticleSystem.Particle[ps.particleCount];
				ps.GetParticles(particles);

				for (int i = 0; i < particles.Length; i++) {
					ParticleSystem.Particle p = particles[i];

					Vector3 vectorToTarget = new Vector3(target.transform.position.x, target.transform.position.y, 0.0f) - p.position;
					Vector3 particleVelocity = vectorToTarget.normalized * attractSpeed * Time.deltaTime;

					p.velocity = particleVelocity;
					particles[i] = p;
				}

				ps.SetParticles(particles, particles.Length);
			}
		}
	}
}
