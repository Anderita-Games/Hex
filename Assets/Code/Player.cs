using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	void Update () {
		if (Input.GetMouseButton(0) && GameObject.Find("Canvas").GetComponent<Gamemaster>().Game_Active == true) {
			transform.RotateAround(Vector3.zero, Vector3.forward, 300 * Time.fixedDeltaTime);
		}
	}
	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.name == "Hexagon") {
			GameObject.Find("Canvas").GetComponent<Gamemaster>().Game_Active = false;
		}
	}

}
