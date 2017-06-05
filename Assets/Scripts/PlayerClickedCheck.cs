using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerClickedCheck : MonoBehaviour {

	public bool isPlayerClicked = false;
	float lookAtSpeed = 15f;
	GameObject powerLight;
	CustomizeTimer myCustomizeTimer;

	void Start () {
		myCustomizeTimer = GameObject.Find ("Timer").GetComponent<CustomizeTimer> ();
		isPlayerClicked = false;
		powerLight = GameObject.Find ("PowerLight");
	}
	
	void Update () {
		
		if (isPlayerClicked) {
			powerLight.GetComponent<MeshRenderer> ().enabled = true;

			if (Camera.main.fieldOfView > 4) {
				Camera.main.fieldOfView -= Time.deltaTime * lookAtSpeed;
			}
			StartCoroutine (WaitForSwitchScene ());
		}

	}


	void OnMouseDown () {
		if (!myCustomizeTimer.isCooldownStart) {
			isPlayerClicked = true;
			Camera.main.transform.LookAt (this.gameObject.transform);
		}
	}

	IEnumerator WaitForSwitchScene () {
		yield return new WaitForSeconds (5);
		SceneManager.LoadScene ("Scene-HumanWin");
	}
}
