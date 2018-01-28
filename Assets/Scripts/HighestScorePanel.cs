using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighestScorePanel : MonoBehaviour {

	public Text hsText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateText() {
		hsText.text = (PlayerPrefs.GetFloat ("highestScore")).ToString();
	}

	public void ResetHighestScore() {
		PlayerPrefs.SetFloat ("highestScore", 0.0f);
		UpdateText ();
	}
}
