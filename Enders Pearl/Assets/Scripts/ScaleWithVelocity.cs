using UnityEngine;

public class ScaleWithVelocity : MonoBehaviour {

	[SerializeField] Rigidbody2D rb;

	//The speeds to reach before maximum scaling is acheived
	[SerializeField] private float maxYSpeed = 30.0f;
	[SerializeField] private float maxXSpeed = 9.0f;

	//Maximum scaling
	[SerializeField] private float minScaleX = 0.5f;
	[SerializeField] private float maxScaleX = 1.0f;

	[SerializeField] private float minScaleY = 1.0f;
	[SerializeField] private float maxScaleY = 1.0f;

	// Update is called once per frame
	void Update() {

		//How lerped will the scale be
		float xScale = Mathf.Abs(rb.velocity.x) / maxXSpeed;
		float yScale = Mathf.Abs(rb.velocity.y) / maxYSpeed;
		float xLerp = Mathf.Lerp(maxScaleX, minScaleX, yScale);
		float yLerp = Mathf.Lerp(maxScaleY, minScaleY, xScale);

		transform.localScale = new Vector2(xLerp, yLerp);
	}

	public void SetMaxYSpeed(float speed) {
		maxYSpeed = speed;
	}

	public void SetMaxXSpeed(float speed) {
		maxXSpeed = speed;
	}

	public void SetMaxScaleX(float maxScale) {
		maxScaleX = maxScale;
	}

	public void SetMinScaleX(float minScale) {
		minScaleX = minScale;
	}

	public void SetMaxScaleY(float maxScale) {
		maxScaleY = maxScale;
	}

	public void SetMinScaleY(float minScale) {
		minScaleY = minScale;
	}
}
