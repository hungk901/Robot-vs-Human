using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CustomizeTimer : MonoBehaviour {

	float timeLeft;
	string timerText;
	Text countdownTimerText;

	public float cooldownTimer;
	string cooldownText;
	public bool isCooldownStart;
	Text cooldownTimerText;

	PlayerClickedCheck myPlayerClickedCheck;
	GameObject myMyPlayer;

	float lookAtSpeed = 15f;

	void Start () {
		timeLeft = 75f;
		cooldownTimer = 5f;
		countdownTimerText = GameObject.Find ("Countdown").GetComponent<Text> ();
		cooldownTimerText = GameObject.Find ("Cooldown").GetComponent<Text> ();
		myMyPlayer = GameObject.Find ("MyPlayer");
		myPlayerClickedCheck = myMyPlayer.GetComponent<PlayerClickedCheck> ();
	}
	
	void Update () {

		if (!myPlayerClickedCheck.isPlayerClicked) {
			if (timeLeft > 0) {
				timeLeft -= Time.deltaTime;
			} else {
				timeLeft = 0;
			}
			timerText = timeLeft.ToString ("f2");
			countdownTimerText.text = "Time Left: " + timerText;
		}

		if (Input.GetMouseButtonDown (0)) {
			if (!isCooldownStart) {
				isCooldownStart = true;
			}
		}

		if (isCooldownStart) {
			cooldownTimer -= Time.deltaTime;
			cooldownText = cooldownTimer.ToString ("f1");
			cooldownTimerText.text = "EMP available in " + cooldownText + "s";
			cooldownTimerText.color = Color.gray;

			if (cooldownTimer < 0) {
				isCooldownStart = false;
				cooldownTimer = 5f;
			}
		} else {
			cooldownTimerText.text = "EMP: ON";
			cooldownTimerText.color = Color.white;
		}

		if (timeLeft < 1) {
			Camera.main.transform.LookAt (myMyPlayer.transform);
			if (Camera.main.fieldOfView > 4) {
				Camera.main.fieldOfView -= Time.deltaTime * lookAtSpeed;
			}
			StartCoroutine (WaitForSwitchScene ());
		}
	}

	IEnumerator WaitForSwitchScene () {
		yield return new WaitForSeconds (5);
		SceneManager.LoadScene ("Scene-RobotWin");
	}
}
