using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour {
	public Rigidbody projectile;
	public Transform shotPos;
	public float shotForce=100f;

	private bool firePending = false;
	private bool onTarget = false;

	void FixedUpdate () {
		if (firePending) {
			Fire ();
			firePending = false;
		}
	}
	void Fire() {
		Rigidbody shot = Instantiate(projectile, shotPos.position, shotPos.rotation) as Rigidbody;

		GameObject target = GameController.instance ().currentTarget;
		Transform aim; 
		if (onTarget) {
			aim = target.transform.Find ("Bullseye").transform;
		} else {
			aim = target.transform.Find ("Miss").transform;		
		}

		transform.LookAt (aim);
		shot.transform.LookAt (aim);
			
		for (int i = 0; i < 10; i++) {
			shot.AddForce (shot.transform.forward * shotForce);
		}
	}

	public void RequestFire(bool _onTarget) {
		firePending = true;
		onTarget = _onTarget;
	}
}
