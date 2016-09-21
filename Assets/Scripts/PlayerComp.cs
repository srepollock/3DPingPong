using UnityEngine;
using System.Collections;

public class PlayerComp: MonoBehaviour {

	bool upwards = true;
	public float speed = 4.0f;
	public int score = 0;

	// Update is called once per frame
	void Update () {
		if (upwards) {
			transform.Translate (Vector3.up * speed * Time.deltaTime);
		} else {
			transform.Translate(-Vector3.up * speed * Time.deltaTime);
		}
	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.name == "Top Wall") {
			upwards = false;
		} else if (col.gameObject.name == "Bottom Wall") {
			upwards = true;
		}
	}

	public void addScore() {
		score++;
	}
}
