using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour {
	public Rigidbody projectile;
	public Transform shotPos;
	public float shotForce=1000f;
	public Transform hitTarget;
	public Transform missTarget;

	private bool firePending = false;
	private bool onTarget = false;

	void Update () {
		if (firePending) {
			Fire ();
			firePending = false;
		}
	}
	void Fire() {
		Rigidbody shot = Instantiate(projectile, shotPos.position, shotPos.rotation) as Rigidbody;
		if (onTarget) {
			transform.LookAt (hitTarget);
			shot.transform.LookAt (hitTarget);
		} else {
			transform.LookAt (missTarget);
			shot.transform.LookAt (missTarget);
		}
			
		for (int i = 0; i < 50; i++) {
			shot.AddForce (shot.transform.forward * shotForce);
		}
	}

	public void RequestFire(bool _onTarget) {
		firePending = true;
		onTarget = _onTarget;
	}
}
