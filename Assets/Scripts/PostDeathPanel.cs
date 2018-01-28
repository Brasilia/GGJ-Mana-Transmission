using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PostDeathPanel : MonoBehaviour {

	public ScoreManager scoreManager;
	public Text score;
	public Text hsText;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void Awake () {
		UpdateTexts ();
	}

	public void UpdateTexts() {
		score.text =  Mathf.Round(scoreManager.scoreValue).ToString ();
		hsText.text = (PlayerPrefs.GetFloat ("highestScore")).ToString();
	}
}
