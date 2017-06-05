using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartClick : MonoBehaviour {

	void Update () {
		if (Input.GetKey (KeyCode.R)) {
			SceneManager.LoadScene (0);
		}
	}
}
