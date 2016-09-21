using UnityEngine;
using System.Collections;

public class PlayerTwo : MonoBehaviour {

	public float speed = 4.0f;
	public int score = 0;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Translate(Vector3.up * speed * Time.deltaTime);
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Translate(-Vector3.up * speed * Time.deltaTime);
		} else if (Input.GetAxis("XBox Right Joy Stick") > 0) {
			transform.Translate(Vector3.up * speed * Time.deltaTime);
		} else if (Input.GetAxis("XBox Right Joy Stick") < 0) {
			transform.Translate(-Vector3.up * speed * Time.deltaTime);
		}
	}

	public void addScore() {
		score++;
	}
}
