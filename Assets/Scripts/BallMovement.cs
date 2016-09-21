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
	private PlayerComp playerComp;
	private Text p1Text;
	private Text p2Text;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		if (rb != null) {
			rb.velocity = new Vector3(-1f,-0.15f) * iSpeed;
			curSpeed = iSpeed;
		}
		GameObject p1Score = GameObject.Find ("P1Score");
		p1Text = p1Score.GetComponent<Text> ();
		playerOne = GameObject.Find ("Player").GetComponent<PlayerOne>();
		GameObject p2Score = GameObject.Find ("P2Score");
		p2Text = p2Score.GetComponent<Text> ();
		playerTwo = GameObject.Find ("PlayerTwo").GetComponent<PlayerTwo>();
		if (playerTwo == null) {
			playerComp = GameObject.Find ("PlayerTwo").GetComponent<PlayerComp> ();
			playerTwo = new PlayerTwo ();
		} else {
			playerComp = new PlayerComp ();
		}
		clearScore ();
	}
	
	// Update is called once per frame
	void Update () {
		
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
			if (playerTwo != null) {
				playerTwo.addScore ();
				p2Text.text = "Score: " + playerTwo.score;
			} else if (playerComp != null) {
				playerComp.addScore ();
				p2Text.text = "Score: " + playerComp.score;
			}
			respawn ();
		}
		// Check scores
	}

	float hitRacketFactor(Vector3 ballPos, Vector3 racketPos, float racketHeight) {
		return (ballPos.y - racketPos.y) / racketHeight;
	}

	void respawn() {
//		Instantiate (gameObject, new Vector3(0f, 0f, 0f), transform.rotation);
//		Destroy(gameObject);
		transform.position = new Vector3(0f, 0f, 0f);
		rb.velocity = new Vector3(-1f,-0.15f) * iSpeed;
		curSpeed = iSpeed;
	}

	void clearScore() {
//		playerOne.score = 0;
//		playerTwo.score = 0;
//		playerComp.score = 0;
		p1Text.text = "Score: 0";
		p2Text.text = "Score: 0";
	}

	void checkScores() {

	}
}
