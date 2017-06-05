using UnityEngine;
using System.Collections;

public class RobotRandomMovement : MonoBehaviour {

	private Rigidbody robotRigibody;
	public bool _isThisRobotClicked;
	[HideInInspector] public Vector3 moveDirection;
	[HideInInspector] public LayerMask myObstacles;
	[HideInInspector] public float moveForce;
	[HideInInspector] public float maxDisFromObstacles;
	PlayerClickedCheck myPlayerClickedCheck;
	bool isPausedFromMoving = false;
	AudioSource myRobotBeep;

	void Start () {
		robotRigibody = GetComponent<Rigidbody> ();
		myObstacles = LayerMask.GetMask ("Obstacles");
		transform.position = new Vector3 (Random.Range (-20f, 20f), 0, Random.Range (-20f, 20f));
		moveDirection = RandomizeDirection ();
		transform.rotation = Quaternion.LookRotation (moveDirection);
		maxDisFromObstacles = 10f;
		moveForce = 10f;
		myPlayerClickedCheck = GameObject.Find ("MyPlayer").GetComponent<PlayerClickedCheck> ();
		myRobotBeep = GetComponent<AudioSource> ();
	}

	void Update () {
		_isThisRobotClicked = GetComponent<MouseDownDetector> ().isThisRobotClicked;

		// If this Robot is not clicked yet, then is allowed to move.
		if (!myPlayerClickedCheck.isPlayerClicked) {
			if (!_isThisRobotClicked) {
				StartCoroutine (PauseForAWhile ());

				// 5% to pause from PauseForAWhile().
				if (!isPausedFromMoving) {
					robotRigibody.velocity = moveDirection * moveForce;

					if (Physics.Raycast (transform.position, transform.forward, maxDisFromObstacles, myObstacles)) {
						moveDirection = RandomizeDirection ();
						transform.rotation = Quaternion.LookRotation (moveDirection);
					}
				}
			}
		}

		int randomPlayBeep = Random.Range (0, 500);

		if (randomPlayBeep < 1) {
			if (!myRobotBeep.isPlaying) {
				myRobotBeep.PlayOneShot (myRobotBeep.clip);
			}
		}
	}

	Vector3 RandomizeDirection () {
		int randomNum = Random.Range (0, 4);
		Vector3 nextDirection = new Vector3 ();

		// Keep Walking
		if (randomNum == 0) {
			nextDirection = transform.forward;
		} 
		// Turn Back
		else if (randomNum == 1) {
			nextDirection = -transform.forward;
		} 
		// Turn Right
		else if (randomNum == 2) {
			nextDirection = transform.right;
		} 
		// Turn Left
		else if (randomNum == 3) {
			nextDirection = -transform.right;
		}
		return nextDirection;
	}

	IEnumerator PauseForAWhile () {
		int probabilityToPause = Random.Range (0, 100);

		if (!isPausedFromMoving) {
			// 5% to pause
			if (probabilityToPause > 5) {
				isPausedFromMoving = false;
			} else {
				isPausedFromMoving = true;
				yield return new WaitForSeconds (3);
				isPausedFromMoving = false;
			}
		}
	}
}