using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	[SerializeField] private Text scoreText;
	public float scoreValue = 0;
	private int pointsPerSecond = 10;

	[SerializeField] private float highestScore = 0;

	public bool increaseScore = true;

	// Use this for initialization
	void Start () {
		if(!PlayerPrefs.HasKey("highestScore")) {
			PlayerPrefs.SetFloat("highestScore", 0.0f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (increaseScore) {
			scoreValue += pointsPerSecond * Time.deltaTime;

			scoreText.text = Mathf.Round(scoreValue).ToString ();
		}
	}

	// Updates high score ranking
	public void UpdateHighScore () {
		if (scoreValue > PlayerPrefs.GetFloat("highestScore")) {
			highestScore = Mathf.Round(scoreValue);
			if(PlayerPrefs.HasKey("highestScore")) {
				PlayerPrefs.SetFloat("highestScore", highestScore);
				PlayerPrefs.Save ();
			}
		}
	}
}
