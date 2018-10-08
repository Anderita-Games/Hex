using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemaster : MonoBehaviour {
	public int Score = 0;

	public UnityEngine.UI.Text Score_Text;
	public UnityEngine.UI.Text Game_Over_Text;
	public UnityEngine.UI.Text High_Score_Text;

	public bool Game_Active = true;
	public GameObject Hexagon;

	// Use this for initialization
	void Start () {
		StartCoroutine(Generate());
	}
	
	// Update is called once per frame
	void Update () {
		Score_Text.text = Score.ToString();
		if (Game_Active == false) {
			if (Score > PlayerPrefs.GetInt("Highscore")) {
				PlayerPrefs.SetInt("Highscore", Score);
			}
			Game_Over_Text.text = "You Died";
			High_Score_Text.text = "High Score: " + PlayerPrefs.GetInt("Highscore");
			if (Input.GetMouseButton(0)) {
				SceneManager.LoadScene("Main");
			}
		}
	}

	IEnumerator Generate () {
		while (Game_Active == true) {
			GameObject Clone = Instantiate(Hexagon);
			Clone.transform.localScale = new Vector3(3.5f, 3.5f, 1);
			Clone.transform.Rotate(Vector3.forward * Random.Range(0, 360));
			Clone.name = "Hexagon";
			yield return new WaitForSeconds(5 - (Score / 50));
		}
	}
}
