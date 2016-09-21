using UnityEngine;
using System.Collections;

public class PlayerOne: MonoBehaviour {

	public float speed = 4.0f;
	public int score = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate(Vector3.up * speed * Time.deltaTime);
		} else if (Input.GetKey (KeyCode.S)) {
			transform.Translate(-Vector3.up * speed * Time.deltaTime);
		} else if (Input.GetAxis("Vertical") > 0) {
			transform.Translate(Vector3.up * speed * Time.deltaTime);
		} else if (Input.GetAxis("Vertical") < 0) {
			transform.Translate(-Vector3.up * speed * Time.deltaTime);
		}
	}

	public void addScore() {
		score++;
	}
}
