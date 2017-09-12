using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public GameObject targetPrefab;
	public GameObject currentTarget = null;

	public int factor1 = 0;
	public int factor2 = 0;
	public int product = 0;

	public void triggerNewTarget() {
		Debug.Log ("Triggering new target");
		StartCoroutine(timeoutAndTriggerNew());
	}

	private IEnumerator timeoutAndTriggerNew() {
		Debug.Log ("Waiting for timeout");
		yield return new WaitForSeconds (2);
		Debug.Log ("Timed out");

		generateNewTarget ();
	}

	private void generateNewTarget() {
		Debug.Log ("Generating new target");
		if (currentTarget != null) {
			Destroy (currentTarget);
			currentTarget = null;
		}

		currentTarget = Instantiate (targetPrefab) as GameObject;
		factor1 = Random.Range (1, 13);
		factor2 = Random.Range (1, 13);
		product = factor1 * factor2;

		currentTarget.GetComponent<TargetHandler> ().setBasicFact (factor1.ToString() + "x" + factor2.ToString());
		Debug.Log ("Adjusting Bullseye");
		currentTarget.GetComponent<TargetHandler> ().adjustBullseye (factor1, factor2);
	}

	public bool checkResult(string answer) {
		return product == int.Parse (answer);
	}

	// Use this for initialization
	void Start () {
		generateNewTarget ();
	}


	public static GameController instance() {
		return GameObject.Find("GameController").GetComponent<GameController>() as GameController;
	}
}
