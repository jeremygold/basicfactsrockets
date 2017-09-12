using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHandler : MonoBehaviour {
	
	public void setBasicFact(string basicFact) {
		gameObject.GetComponentInChildren<TextMesh> ().text = basicFact;
	}

	public void adjustBullseye(int x, int y) {
		Debug.Log ("Default position = " + transform.Find ("Bullseye").transform.position);
		transform.Find ("Bullseye").transform.position += new Vector3 ((float)x * 0.1f - 0.5f, (float)y * 0.1f - 0.5f);
		Debug.Log ("Updated position = " + transform.Find ("Bullseye").transform.position);
	}

	void OnCollisionEnter (Collision other)
	{
		if(other.gameObject.name == "Projectile(Clone)")
		{
			Debug.Log ("Hit the target!!!");
			Destroy(other.gameObject);

			GameController gameController = GameController.instance();
			gameController.triggerNewTarget ();
		}
	}
}
