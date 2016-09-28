using UnityEngine;
using System.Collections;

public class PlayerComp: MonoBehaviour {

	public float speed = 0f;
	public int score = 0;

	private Rigidbody rb;

	void Start() {
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void LateUpdate () {
		Vector3 ballPos = GameObject.Find("Ball").GetComponent<Rigidbody>().transform.position;
		if (ballPos.y > transform.position.y + 1) {
			rb.velocity = new Vector3 (0, speed);
		} else if (ballPos.y < transform.position.y - 1) {
			rb.velocity = new Vector3 (0, -speed);
		} else {
			rb.velocity = new Vector3 (0, 0);
		}
	}

	public void addScore() {
		score++;
	}
}
