using UnityEngine;
using System.Collections;

public class PlayerTwo : MonoBehaviour {

	public float speed = 4.0f;
	public int score = 0;

	private float screenHalfY = Screen.height / 2;
	private float screenHalfX = Screen.width / 2;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Touch touch;
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Translate (Vector3.up * speed * Time.deltaTime);
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Translate (-Vector3.up * speed * Time.deltaTime);
		} else if (Input.GetAxis ("XBox Right Joy Stick") > 0) {
			transform.Translate (Vector3.up * speed * Time.deltaTime);
		} else if (Input.GetAxis ("XBox Right Joy Stick") < 0) {
			transform.Translate (-Vector3.up * speed * Time.deltaTime);
		} else if (Input.touchCount > 0) {
			for (int i = 0; i < Input.touchCount; i++) {
				touch = Input.GetTouch (i);
				if (touch.position.y > screenHalfY && touch.position.x > screenHalfX) {
					transform.Translate (Vector3.up * speed * Time.deltaTime);
				} else if (touch.position.x > screenHalfX) {
					transform.Translate (-Vector3.up * speed * Time.deltaTime);
				}
			}
		}
	}

	public void addScore() {
		score++;
	}
}
