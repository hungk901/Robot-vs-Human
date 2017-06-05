using UnityEngine;
using System.Collections;

public class ClickingChecker : MonoBehaviour {

	GameObject[] myAutoRobots;
	int[] _timesBeClicked;
	public int totalTimesClicked;

	void Start () {
		myAutoRobots = GameObject.FindGameObjectsWithTag ("AutoRobots");
		_timesBeClicked = new int[myAutoRobots.Length];
	}

	void Update () {
		totalTimesClicked = 0;

		for (int i = 0; i < myAutoRobots.Length; i++) {
			_timesBeClicked [i] = myAutoRobots [i].GetComponent<MouseDownDetector> ().timesBeClicked;
			totalTimesClicked += _timesBeClicked [i];
		}
	}
}
