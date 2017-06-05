using UnityEngine;
using System.Collections;

public class MouseDownDetector : MonoBehaviour {

	CustomizeTimer myTimer;
	public int timesBeClicked;
	public bool isThisRobotClicked;

	void Start () {
		isThisRobotClicked = false;
		myTimer = GameObject.Find ("Timer").GetComponent<CustomizeTimer> ();
	}
	
	void Update () {
	
	}

	void OnMouseDown () {
		if (myTimer.cooldownTimer == 5f) {
			transform.rotation = Quaternion.Euler (90f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
			this.GetComponent<BoxCollider> ().size = new Vector3 (0, 0, 0.1f);
			this.GetComponent<BoxCollider> ().center = new Vector3 (0, 0.85f, 0.7f);

			if (!isThisRobotClicked) {
				timesBeClicked++;
				isThisRobotClicked = true;
			}
		}
	}
}
