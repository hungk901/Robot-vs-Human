using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartClick : MonoBehaviour {

	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			SceneManager.LoadScene ("Scene-Main");
		}
	}
}
