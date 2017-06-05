using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	Rigidbody playRigibody;
	Transform myModel;
	float moveSpeed = 8f;
	PlayerClickedCheck myPlayerClickedCheck;

	void Start () {
		playRigibody = GetComponent<Rigidbody> ();
		transform.position = new Vector3 (Random.Range (-20f, 20f), 0, Random.Range (-20f, 20f));

		myModel = GameObject.Find ("MyModel").GetComponent<Transform> ();
		myPlayerClickedCheck = GameObject.Find ("MyPlayer").GetComponent<PlayerClickedCheck> ();
	}
	
	void Update () {
		if (!myPlayerClickedCheck.isPlayerClicked) {
			if (Input.GetKey (KeyCode.UpArrow)) {
				transform.position += transform.forward * Time.deltaTime;
				playRigibody.velocity = transform.forward * moveSpeed;
				myModel.rotation = Quaternion.Euler (0, 0, 0);
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				transform.position += -transform.forward * Time.deltaTime;
				playRigibody.velocity = -transform.forward * moveSpeed;
				myModel.rotation = Quaternion.Euler (0, 180, 0);		
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				transform.position += -transform.right * Time.deltaTime;
				playRigibody.velocity = -transform.right * moveSpeed;
				myModel.rotation = Quaternion.Euler (0, -90, 0);		
			}
			if (Input.GetKey (KeyCode.RightArrow)) {
				transform.position += transform.right * Time.deltaTime;
				playRigibody.velocity = transform.right * moveSpeed;
				myModel.rotation = Quaternion.Euler (0, 90, 0);		
			}
//		if (Input.GetKey (KeyCode.UpArrow) && Input.GetKey (KeyCode.RightArrow)) {
//			transform.rotation = Quaternion.Euler (0, 45f, 0);
//		}
//		if (Input.GetKey (KeyCode.UpArrow) && Input.GetKey (KeyCode.LeftArrow)) {
//			transform.rotation = Quaternion.Euler (0, -45f, 0);
//		}
//		if (Input.GetKey (KeyCode.DownArrow) && Input.GetKey (KeyCode.LeftArrow)) {
//			transform.rotation = Quaternion.Euler (0, 135f, 0);
//		}
//		if (Input.GetKey (KeyCode.DownArrow) && Input.GetKey (KeyCode.RightArrow)) {
//			transform.rotation = Quaternion.Euler (0, -135f, 0);
//		}
		}
	}
}
