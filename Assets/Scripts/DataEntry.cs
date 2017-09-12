using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataEntry : MonoBehaviour {
	public GUIText  gt;

	void Start()
	{
		gt = GetComponent<GUIText>();
		gt.text = "";
	}

	void Update()
	{
		foreach (char c in Input.inputString) {
			if (c == '\b') { // has backspace/delete been pressed?
				if (gt.text.Length != 0) {
					gt.text = gt.text.Substring (0, gt.text.Length - 1);
				}
			} else if ((c == '\n') || (c == '\r')) { // enter/return
				print ("User entered their name: " + gt.text);
				bool hit = false;
				if (gt.text == "42") {
					hit = true;
				}
				gt.text = "";

				GunControl gunScript = GameObject.Find("Main Camera").GetComponent<GunControl>();
				gunScript.RequestFire (hit);

			} else {
				gt.text += c;
			}
		}
	}
}
