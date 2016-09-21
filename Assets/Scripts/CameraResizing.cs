using UnityEngine;
using System.Collections;

public class CameraResizing : MonoBehaviour {

	const float KEEP_ASPECT = 16/9f;

	// Use this for initialization
	void Start () {
		float aspectRatio = Screen.width / ((float)Screen.height);
		float percentage = 1 - (aspectRatio / KEEP_ASPECT);

		GetComponent<Camera>().rect = new Rect(0f, (percentage / 2), 1f, (1 - percentage));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
