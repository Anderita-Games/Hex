using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrink : MonoBehaviour {
	void Update () {
		if (GameObject.Find("Canvas").GetComponent<Gamemaster>().Game_Active == true) {
			this.transform.localScale = new Vector3(this.transform.localScale.x - .004f, this.transform.localScale.y - .004f, 1);
		}
		if (this.transform.localScale.x <= .002f) {
			GameObject.Find("Canvas").GetComponent<Gamemaster>().Score++;
			Destroy(this.gameObject);
		}
	}
}
