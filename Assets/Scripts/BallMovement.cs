using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BallMovement : MonoBehaviour {

	public float iSpeed;
	public float cSpeed;
	public float sFactor;

	private Rigidbody rb;
	private float curSpeed;
	private PlayerOne playerOne;
	private PlayerTwo playerTwo;
	private Text p1Text;
	private Text p2Text;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		if (rb != null) {
			rb.velocity = Vector3.right * iSpeed;
			curSpeed = iSpeed;
		}
		GameObject p1Score = GameObject.Find ("P1Score");
		p1Text = p1Score.GetComponent<Text> ();
		playerOne = GameObject.Find ("Player").GetComponent<PlayerOne>();
		GameObject p2Score = GameObject.Find ("P2Score");
		p2Text = p2Score.GetComponent<Text> ();
		playerTwo = GameObject.Find ("PlayerTwo").GetComponent<PlayerTwo>();
		clearScore ();
	}
	
	// Update is called once per frame
	void Update () {
//		Vector3 cval = rb.velocity;
//		Vector3 tval = cval.normalized * cSpeed;
//		rb.velocity = Vector3.Lerp (cval, tval, Time.deltaTime * sFactor);
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.name == "Player") {
			float y = hitRacketFactor (transform.position, 
				          col.transform.position, 
				          col.collider.bounds.size.y);
			Vector3 dir = new Vector3 (1, y).normalized;
			curSpeed += sFactor;
			rb.velocity = dir * curSpeed;
		} else if (col.gameObject.name == "PlayerTwo") {
			float y = hitRacketFactor (transform.position,
				          col.transform.position,
				          col.collider.bounds.size.y);
			Vector3 dir = new Vector3 (-1, y).normalized;
			curSpeed += sFactor;
			rb.velocity = dir * curSpeed;
		} else if (col.gameObject.name == "Right Wall") {
			playerOne.addScore ();
			p1Text.text = "Score: " + playerOne.score;
			respawn ();
		} else if (col.gameObject.name == "Left Wall") {
			playerTwo.addScore ();
			p2Text.text = "Score: " + playerTwo.score;
			respawn ();
		}
	}

	float hitRacketFactor(Vector3 ballPos, Vector3 racketPos, float racketHeight) {
		return (ballPos.y - racketPos.y) / racketHeight;
	}

	void respawn() {
//		Instantiate (gameObject, new Vector3(0f, 0f, 0f), transform.rotation);
//		Destroy(gameObject);
		transform.position = new Vector3(0f, 0f, 0f);
		rb.velocity = Vector3.right * iSpeed;
		curSpeed = iSpeed;
	}

	void clearScore() {
		playerOne.score = 0;
		playerTwo.score = 0;
		p1Text.text = "Score: 0";
		p2Text.text = "Score: 0";
	}
}
